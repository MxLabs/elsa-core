﻿using System.Threading;
using System.Threading.Tasks;

namespace Elsa.Activities.Signaling.Services
{
    public interface ISignaler
    {
        /// <summary>
        /// Runs all workflows that start with or are blocked on the <see cref="SignalReceived"/> activity.
        /// </summary>
        Task<bool> TriggerSignalTokenAsync(string signalToken, object? input = default, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Runs all workflows that start with or are blocked on the <see cref="SignalReceived"/> activity.
        /// </summary>
        Task TriggerSignalAsync(string signal, object? input = default, string? workflowInstanceId = default, string? correlationId = default, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Dispatches all workflows that start with or are blocked on the <see cref="SignalReceived"/> activity.
        /// </summary>
        Task<bool> DispatchSignalTokenAsync(string token, object? input = default, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Dispatches all workflows that start with or are blocked on the <see cref="SignalReceived"/> activity.
        /// </summary>
        Task DispatchSignalAsync(string signal, object? input = default, string? workflowInstanceId = default, string? correlationId = default, CancellationToken cancellationToken = default);
    }
}