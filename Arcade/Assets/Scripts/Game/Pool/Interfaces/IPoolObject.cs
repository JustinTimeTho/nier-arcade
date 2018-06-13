namespace ObjectsPool
{
    public interface IPoolObject
    {
        void SetPool(IPoolFree pool, int index);
        bool isActive();
        void Execute();
    }
}