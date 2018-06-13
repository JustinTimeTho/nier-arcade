using System.Collections.Generic;

using UnityEngine;

namespace ObjectsPool
{
    public abstract class Pool<T> : IPool where T : IPoolObject
    {

        event PoolInstantiateEventHandler PoolInstantiate;

        event PoolDestroyEventHandler PoolDestroy;

        readonly List<T> _objects;

        readonly Queue<T> _freeObjects;

        readonly GameObject _prefab;

        bool _active = true;

        public Pool(GameObject prefab, int capacity)
        {
            _prefab         = prefab;
            _objects        = new List<T>(capacity);
            _freeObjects    = new Queue<T>(capacity);
        }

        public abstract T ConvertToPoolObject(GameObject gameObject, int index);

        public abstract GameObject ConvertToGameObject(T poolObject);

        public void BindPoolInstantiate(PoolInstantiateEventHandler handler)
        {
            PoolInstantiate += handler;
        }

        public void BindPoolDestroy(PoolDestroyEventHandler handler)
        {
            PoolDestroy += handler;
        }

        public void Add()
        {
            var obj = ConvertToPoolObject(PoolInstantiate(_prefab),  _objects.Count);

            _objects.Add(obj);
            _freeObjects.Enqueue(obj);
        }

        public void Add(int count)
        {
            for (int i = 0; i < count; i++)
                Add();
        }

        public bool Execute()
        {
            var hasExecute = false;

            foreach (var poolObject in _objects)
            {
                if (poolObject != null && poolObject.isActive())
                {
                    poolObject.Execute();
                    hasExecute = true;
                }
            }

            return hasExecute;
        }

        public void SetActive(bool active)
        {
            _active = active;
        }

        public bool isActive()
        {
            return _active;
        }

        public void Free(int index)
        {
            _freeObjects.Enqueue(_objects[index]);
        }

        public void Clear()
        {
            foreach (var poolObject in _objects)
                PoolDestroy(ConvertToGameObject(poolObject));

            _freeObjects.Clear();
            _objects.Clear();
        }

        public void ClearNotActive()
        {
            foreach (var poolObject in _objects)
                if ( ! poolObject.isActive())
                    PoolDestroy(ConvertToGameObject(poolObject));
        }

        public T GetObject()
        {
            if (_freeObjects.Count > 0)
                return _freeObjects.Dequeue();

            var obj = ConvertToPoolObject(PoolInstantiate(_prefab),  _objects.Count);

            _objects.Add(obj);

            return obj;
        }
    }
}