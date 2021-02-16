using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Abstract.Domain;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProofOfConcept.Domain.Helper;
using System.Linq;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class StfDeflectionEventDetectorService : IDataProcessorService<StfDeflection>
    {
        private const float LEVEL_0 = 0f;
        private readonly Dictionary<string, Range> _eventLevels = new Dictionary<string, Range>();

        public StfDeflectionEventDetectorService()
        {
            _eventLevels.Add("acceptable", Range.And(x => x >= double.MinValue, y => y <= LEVEL_0));
            _eventLevels.Add("unacceptable", Range.And(x => x > LEVEL_0, y => y <= double.MaxValue));
        }

        public Task<StockEvent<StfDeflection>> DetectEventAsync(StfDeflection data)
        {
            return Task.Run(() =>
            {
                var result = _eventLevels.First(lvl => lvl.Value.IsInRange(data.Value)).Key;
                var differenceCheck = _eventLevels.First(lvl => lvl.Value.IsInRange(data.PreviousValue)).Key;

                return !result.Equals(differenceCheck) ? new StockEvent<StfDeflection>(data, result) : null;
            });
        }
    }
}
