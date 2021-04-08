using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Database.Abstract
{
    internal interface IUnitOfWork
    {
        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();
    }
}