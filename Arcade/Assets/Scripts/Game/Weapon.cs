using UnityEngine;

using ObjectsPool;

[RequireComponent(typeof(AudioSource))]
public class Weapon : CachedMonoBehaviour
{
	[SerializeField]
	GameObject _bulletPrefab;

	[SerializeField]
	int _poolCapacity;
	
	[SerializeField]
	float _bulletSpeed;

	[SerializeField]
	bool _destroyWithOtherBullets;

	PoolBullet _pool;

	AudioSource _audioSource;

	void Awake()
	{
		_audioSource = GetComponent<AudioSource>();

		_pool = new PoolBullet(_bulletPrefab, _poolCapacity);

		GameObject.FindGameObjectWithTag(ArcadeGameObjectTags.UnityPool.ToString()).GetComponent<UnityPool>().AddPool(_pool);

		_pool.Add(_poolCapacity);
	}

	void OnDestroy()
	{
		_pool.SetActive(false);
	}

	public void Shoot(Vector3 direction)
	{
		var bullet = _pool.GetObject();
		bullet.gameObject.SetActive(true);

		direction.y = 0f;
		
		bullet.Move(cachedTransform.position, direction, _bulletSpeed, _destroyWithOtherBullets);

		_audioSource.Play();
	}
}
