using System.Threading.Channels;
using Elsa.ServiceConfiguration.Services;
using Elsa.Workflows.Runtime.Configuration;
using Elsa.Workflows.Runtime.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Elsa.Workflows.Runtime.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceConfiguration UseRuntime(this IServiceConfiguration serviceConfiguration, Action<WorkflowRuntimeConfigurator>? configure = default)
    {
        serviceConfiguration.Configure(configure);
        return serviceConfiguration;
    }

    public static IServiceCollection CreateChannel<T>(this IServiceCollection services) =>
        services
            .AddSingleton(CreateChannel<T>())
            .AddSingleton(CreateChannelReader<T>)
            .AddSingleton(CreateChannelWriter<T>);

    private static Channel<T> CreateChannel<T>() => Channel.CreateUnbounded<T>(new UnboundedChannelOptions());
    private static ChannelReader<T> CreateChannelReader<T>(IServiceProvider serviceProvider) => serviceProvider.GetRequiredService<Channel<T>>().Reader;
    private static ChannelWriter<T> CreateChannelWriter<T>(IServiceProvider serviceProvider) => serviceProvider.GetRequiredService<Channel<T>>().Writer;

    public static IServiceCollection AddWorkflowDefinitionProvider<T>(this IServiceCollection services) where T : class, IWorkflowDefinitionProvider => services.AddSingleton<IWorkflowDefinitionProvider, T>();
    public static IServiceCollection AddStimulusHandler<T>(this IServiceCollection services) where T : class, IStimulusHandler => services.AddSingleton<IStimulusHandler, T>();
    public static IServiceCollection AddInstructionInterpreter<T>(this IServiceCollection services) where T : class, IWorkflowInstructionInterpreter => services.AddSingleton<IWorkflowInstructionInterpreter, T>();
}