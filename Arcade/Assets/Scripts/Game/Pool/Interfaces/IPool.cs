namespace ObjectsPool
{
    public interface IPool : IPoolFree
    {
        void BindPoolInstantiate(PoolInstantiateEventHandler handler);
        void BindPoolDestroy(PoolDestroyEventHandler handler);
        void SetActive(bool active);
        bool isActive();
        bool Execute();
        void Clear();
    }
}