using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShoot : CachedMonoBehaviour
{
	[SerializeField]
	Weapon _weapon;

	[SerializeField]
	float _shootsInterval;

	float _offset;

	void Update()
	{
#if (UNITY_ANDROID || UNITY_IOS)
		if (Input.touchCount >= 2)
            Shoot();
#else
		var fire = Input.GetAxis("Fire1");
        if (fire <= -1f || fire >= 1f)
            Shoot();
#endif
	}

    void Shoot()
    {
        if (Time.realtimeSinceStartup - _offset >= _shootsInterval)
		{
			var direction = (_weapon.cachedTransform.position - cachedTransform.position).normalized;
			_weapon.Shoot(direction);

			_offset = Time.realtimeSinceStartup;
		}
    }
}
