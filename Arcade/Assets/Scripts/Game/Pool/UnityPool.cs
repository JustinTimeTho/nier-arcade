using System.Collections.Generic;

using UnityEngine;

using ObjectsPool;

public class UnityPool : MonoBehaviour
{
	[SerializeField]
	int _poolsCapacity;

	Dictionary<uint, IPool> _pools;

	List<uint> _idsToRemove;

	uint _currentPoolId;

	Dictionary<uint, IPool> Pools
	{
		get
		{
			if (_pools == null)
				_pools = new Dictionary<uint, IPool>(_poolsCapacity);

			return _pools;
		}
	}

	void Awake()
	{
		_idsToRemove = new List<uint>();
	}

	void Update()
	{
		foreach (var poolId in Pools.Keys)
		{
			var pool = Pools[poolId];

			if (pool.Execute())
				continue;

			if (pool.isActive())
				continue;

			pool.Clear();
			_idsToRemove.Add(poolId);
		}

		foreach (var id in _idsToRemove)
			Pools.Remove(id);

		_idsToRemove.Clear();
	}

	public void AddPool(IPool pool)
	{
		pool.BindPoolInstantiate(OnPoolInstantiate);
		pool.BindPoolDestroy(OnPoolDestroy);

		Pools.Add(_currentPoolId++, pool);
	}

	GameObject OnPoolInstantiate(GameObject prefab)
	{
		return Instantiate(prefab);
	}

	void OnPoolDestroy(GameObject poolObject)
	{
		Destroy(poolObject);
	}
}
