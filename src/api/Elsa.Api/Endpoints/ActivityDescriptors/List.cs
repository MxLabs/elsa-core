using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Elsa.Contracts;
using Elsa.Management.Contracts;
using Elsa.Serialization.Converters;
using Microsoft.AspNetCore.Http;

namespace Elsa.Api.Endpoints.ActivityDescriptors;

public static partial class ActivityDescriptors
{
    public static IResult ListAsync(IActivityRegistry registry, IWellKnownTypeRegistry wellKnownTypeRegistry)
    {
        var descriptors = registry.ListAll().ToList();

        var model = new
        {
            ActivityDescriptors = descriptors
        };

        return Results.Json(model, new JsonSerializerOptions
        {
            Converters =
            {
                new JsonStringEnumConverter(),
                new TypeJsonConverter(wellKnownTypeRegistry)
            },
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        });
    }
}