using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Common.Extensions;
using ProofOfConcept.Domain.Enum;
using Quartz;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Job.EventDetectionPipeline
{
    internal abstract class FullPipelineJobBase : IJob
    {
        protected const int RETRY_MAX_COUNT = 1;
        protected readonly IZoneChangeEventPipeline _pipeline;
        protected readonly ILogger<FullPipelineJobBase> _logger;

        protected abstract IndicatorId IndicatorId { get; }

        protected abstract IEnumerable<AssetId> Assets { get; }

        protected FullPipelineJobBase(
            IZoneChangeEventPipeline pipeline,
            ILogger<FullPipelineJobBase> logger)
        {
            _pipeline = pipeline;
            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            for (int i = 0; i <= RETRY_MAX_COUNT; i++)
            {
                try
                {
                    await ExecutePipeline(context);
                    break;
                }
                catch (Exception e)
                {
                    _logger.LogError($"{context.JobDetail.Key.Group}:{context.JobDetail.Key.Name} - Error at attempt no. {i} - {e}");
                }
            }
        }

        private async Task ExecutePipeline(IJobExecutionContext context)
        {
            if (Assets.IsNullOrEmpty())
            {
                _logger.LogWarning($"{context.JobDetail.Key.Group}:{context.JobDetail.Key.Name} - Job's Assets collection is null or contains no elements.");

                return;
            }

            foreach (var asset in Assets)
            {
                await _pipeline.ExecutePipelineAsync(IndicatorId, asset, context.CancellationToken);
            }
        }
    }
}