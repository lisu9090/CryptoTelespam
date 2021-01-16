namespace ProofOfConcept.ServiceWorker.Abstract
{
    interface IActionDequeuer<out T> where T : IAction
    {
        T DequeueAction();
        bool HasAction();
    }
}
