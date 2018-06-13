using UnityEngine;

public class SelfRotate : CachedMonoBehaviour
{
	[SerializeField]
	float _rotationSpeed;

	void Update()
	{
		cachedTransform.rotation = Quaternion.Euler(cachedTransform.eulerAngles.x, cachedTransform.eulerAngles.y + (_rotationSpeed * Time.deltaTime), cachedTransform.eulerAngles.z);
	}
}
