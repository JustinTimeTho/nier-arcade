using UnityEngine;

public class ShootsToTag : CachedMonoBehaviour
{
	[SerializeField]
	ArcadeGameObjectTags _tag;

    [SerializeField]
	float _shootsInterval;

	[SerializeField]
	Weapon[] _weapons;

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

			for (int i = 0; i < _weapons.Length; i++)
			{
				var weapon = _weapons[i];
				var dir = (weapon.cachedTransform.position - cachedTransform.position).normalized;
				weapon.Shoot(dir);
			}
		}
		else _seconds += Time.deltaTime;
	}
}
