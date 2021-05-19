using ProofOfConcept.Domain.Entity.Relation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Data
{
    public class IndicatorAssetCollection : IEnumerable<IndicatorAsset>
    {
        private IEnumerable<IndicatorAsset> _indicatorAssets = new List<IndicatorAsset>();

        public IEnumerator<IndicatorAsset> GetEnumerator()
        {
            return _indicatorAssets.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}