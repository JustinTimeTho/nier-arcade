using UnityEngine;

using ObjectsPool;

public class Bullet : CachedMonoBehaviour, IPoolObject
{
	Vector3 _direction;

	float _speed;

	IPoolFree _pool;

	int _index;

	bool _destroyWithOtherBullets;

	public void SetPool(IPoolFree pool, int index)
	{
		_pool 	= pool;
		_index 	= index;
	}

	public bool isActive()
	{
		return gameObject.activeSelf;
	}

	public void Execute()
	{
		cachedTransform.position += _direction * _speed * Time.deltaTime;
	}

	public void Move(Vector3 startPosition, Vector3 direction, float speed, bool destroyWithOtherBullets)
	{
		cachedTransform.position = startPosition;

		var angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
		var rot =  Quaternion.AngleAxis(-angle, Vector3.up);
		cachedTransform.rotation = Quaternion.Euler(cachedTransform.eulerAngles.x, rot.eulerAngles.y, cachedTransform.eulerAngles.z);

		_direction = direction;
		_speed = speed;

		_destroyWithOtherBullets = destroyWithOtherBullets;
	}

	void OnCollisionEnter(Collision collision)
	{
		if ( ! _destroyWithOtherBullets)
			if (collision.gameObject.CompareTag(ArcadeGameObjectTags.Bullet.ToString()))
				return;

		gameObject.SetActive(false);
		_pool.Free(_index);
	}
}
