using UnityEngine;

public class RotateToTag : CachedMonoBehaviour
{
	[SerializeField]
	ArcadeGameObjectTags _tag;

    [SerializeField]
    float _timeDeltaMultiplier;

	Transform _targetTransform;

	void Awake()
	{
		_targetTransform = GameObject.FindGameObjectWithTag(_tag.ToString()).GetComponent<Transform>();
	}

	void Update()
	{
		if (_targetTransform == null)
			return;

		var playerPosition = _targetTransform.position;

		var dx = playerPosition.x - cachedTransform.position.x;
		var dz = playerPosition.z - cachedTransform.position.z;
		var angle = Mathf.Atan2(dz, dx) * Mathf.Rad2Deg - 90;
		var rot =  Quaternion.AngleAxis(-angle, Vector3.up);

		cachedTransform.rotation = Quaternion.Lerp(cachedTransform.rotation, Quaternion.Euler(cachedTransform.eulerAngles.x, rot.eulerAngles.y, cachedTransform.eulerAngles.z), _timeDeltaMultiplier * Time.deltaTime);
	}
}
