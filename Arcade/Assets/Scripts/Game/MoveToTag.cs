using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveToTag : CachedMonoBehaviour
{
	[SerializeField]
	ArcadeGameObjectTags _tag;

	[SerializeField]
	float _speed;

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
		var direction = (playerPosition - cachedTransform.position).normalized;

		cachedRigidbody.velocity = direction * _speed;
	}
}
