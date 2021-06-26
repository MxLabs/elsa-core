﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Elsa.Models;
using Elsa.Server.Api.Endpoints.WorkflowRegistry;
using Elsa.Server.Api.Mapping;
using Elsa.Services;
using Elsa.Services.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Elsa.Server.Api.Services
{
    public class WorkflowBlueprintMapper : IWorkflowBlueprintMapper
    {
        private readonly IWorkflowBlueprintReflector _workflowBlueprintReflector;
        private readonly IActivityTypeService _activityTypeService;
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public WorkflowBlueprintMapper(IWorkflowBlueprintReflector workflowBlueprintReflector, IActivityTypeService activityTypeService, IMapper mapper, IServiceScopeFactory serviceScopeFactory)
        {
            _workflowBlueprintReflector = workflowBlueprintReflector;
            _activityTypeService = activityTypeService;
            _mapper = mapper;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async ValueTask<WorkflowBlueprintModel> MapAsync(IWorkflowBlueprint workflowBlueprint, CancellationToken cancellationToken = default)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var wrapper = await _workflowBlueprintReflector.ReflectAsync(scope.ServiceProvider, workflowBlueprint, cancellationToken);
            var activityProperties = await Task.WhenAll(wrapper.Activities.Select(async x => (x.ActivityBlueprint.Id, await GetActivityPropertiesAsync(wrapper, x, cancellationToken))));
            var activityPropertyDictionary = activityProperties.ToDictionary(x => x.Id, x => x.Item2);
            return _mapper.Map<WorkflowBlueprintModel>(workflowBlueprint, options => options.Items[ActivityBlueprintConverter.ActivityPropertiesKey] = activityPropertyDictionary);
        }

        private async ValueTask<Variables> GetActivityPropertiesAsync(IWorkflowBlueprintWrapper workflowBlueprintWrapper, IActivityBlueprintWrapper activityBlueprintWrapper, CancellationToken cancellationToken)
        {
            var activityBlueprint = activityBlueprintWrapper.ActivityBlueprint;
            var activityType = await _activityTypeService.GetActivityTypeAsync(activityBlueprint.Type, cancellationToken);
            var activityDescriptor = await _activityTypeService.DescribeActivityType(activityType, cancellationToken);
            var activityId = activityBlueprint.Id;
            var activityWrapper = workflowBlueprintWrapper.GetActivity(activityId)!;
            var properties = new Variables();

            foreach (var property in activityDescriptor.InputProperties)
            {
                var value = await TryEvaluatePropertyAsync(activityWrapper, property.Name, cancellationToken);
                properties.Set(property.Name, value);
            }

            foreach (var property in activityDescriptor.OutputProperties)
            {
                // Declare output properties to have at least a complete schema. 
                properties.Set(property.Name, null);
            }

            return properties;
        }

        private async Task<object?> TryEvaluatePropertyAsync(IActivityBlueprintWrapper activityWrapper, string propertyName, CancellationToken cancellationToken)
        {
            try
            {
                return await activityWrapper.EvaluatePropertyValueAsync(propertyName, cancellationToken);
            }
            catch
            {
                // ignored
            }

            return null;
        }
    }
}