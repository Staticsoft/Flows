﻿using Staticsoft.Contracts.Abstractions;
using Staticsoft.Flow;

namespace Staticsoft.TestServer;

public class CalculateSumOfSquaresEndpoint(
    Job<CalculateSumOfSquaresInput, CalculateSumOfSquaresOutput> job,
    IServiceProvider provider
) : HttpEndpoint<CalculateSumOfSquaresRequest, CalculateSumOfSquaresResponse>
{
    readonly Job<CalculateSumOfSquaresInput, CalculateSumOfSquaresOutput> Job = job;
    readonly IServiceProvider Provider = provider;

    public async Task<CalculateSumOfSquaresResponse> Execute(CalculateSumOfSquaresRequest request)
    {
        var jobId = await Job.Create(new() { Numbers = request.Numbers });
        return new() { JobId = jobId };
    }
}