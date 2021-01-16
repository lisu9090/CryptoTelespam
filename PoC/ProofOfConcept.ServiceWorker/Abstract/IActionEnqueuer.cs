namespace ProofOfConcept.ServiceWorker.Abstract
{
    interface IActionEnqueuer<in T> where T : IAction
    {
        void EnqueueAction(T workItem);
    }
}
