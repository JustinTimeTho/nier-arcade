using UnityEngine;

public class ShootToTag : CachedMonoBehaviour
{
	[SerializeField]
	ArcadeGameObjectTags _tag;

    [SerializeField]
	float _shootsInterval;

	[SerializeField]
	Weapon _weapon;

	Transform _targetTransform;

	float _seconds;

	void Awake()
	{
		_targetTransform = GameObject.FindGameObjectWithTag(_tag.ToString()).GetComponent<Transform>();
	}

	void Update()
	{
		if (_targetTransform == null)
			return;

		if (_seconds >= _shootsInterval)
		{
			_seconds = 0f;

			var dir = (_weapon.cachedTransform.position - cachedTransform.position).normalized;
			_weapon.Shoot(dir);
		}
		else _seconds += Time.deltaTime;
	}
}
