using ProofOfConcept.Domain.Entity;
using System;

namespace ProofOfConcept.Domain.Extension
{
    public static class EntityExtension
    {
        public static TEntity ConsistencyCheck<TEntity>(this TEntity entity, int entityId) where TEntity : CryptoEntity
        {
            if (entity.Id != entityId)
            {
                throw new ArgumentException("Entity consistency check failed");
            }

            return entity;
        }
    }
}