using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Domain.Const.Code;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class NuplEventDetectorService : IDataProcessorService<Nupl>
    {
        private const float CAPITULATION_LEVEL = 0;
        private const float BELIEFE_LEVEL = 0.25f;
        private const float OPTIMISM_LEVEL = 0.5f;
        private const float HOPE_LEVEL = 0.75f;


        public Task<StockEvent<Nupl>> DetectEventAsync(Nupl data)
        {
            return Task.Run(() => 
            {
                var eventCode = "";
               
                if(data.PreviousValue > data.Value)
                {

                }
                else if (data.Value > data.PreviousValue)
                {

                }

                return (StockEvent<Nupl>)null;
            });
        }
    }
}
