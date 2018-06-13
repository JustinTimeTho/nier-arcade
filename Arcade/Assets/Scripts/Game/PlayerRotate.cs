using UnityEngine;

public class PlayerRotate : CachedMonoBehaviour
{
	
#if (UNITY_ANDROID || UNITY_IOS)
	Vector2 _touchStartPosition;

	bool _savedTouchStartPosition;
#else
	Quaternion _rotation;

	void Awake()
	{
		_rotation = cachedTransform.rotation;
	}
#endif

	void Update()
	{

#if (UNITY_ANDROID || UNITY_IOS)
		if (Input.touchCount >= 2)
		{
			var touch = Input.GetTouch(1);

			if ( ! _savedTouchStartPosition)
			{
				_touchStartPosition = touch.position;
				_savedTouchStartPosition = true;
			}
			
			var delta = touch.position - _touchStartPosition;

			var angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg - 90;
			var rot =  Quaternion.AngleAxis(-angle, Vector3.up);

			cachedTransform.rotation = Quaternion.Euler(cachedTransform.eulerAngles.x, rot.eulerAngles.y, cachedTransform.eulerAngles.z);
		}
		else
		{
			_savedTouchStartPosition = false;
		}
#else
		var mouseX = Input.GetAxis("Mouse X");
		var mouseY = Input.GetAxis("Mouse Y");

		if ( (mouseX < -0.1f || mouseX > 0.1f) || (mouseY < -0.1f || mouseY > 0.1f) )
		{
			Debug.DrawLine(cachedTransform.position, cachedTransform.position + Vector3.right * mouseX * 2f, Color.red);
			Debug.DrawLine(cachedTransform.position, cachedTransform.position + Vector3.forward * mouseY * 2f, Color.blue);
			
			var direction = new Vector3(mouseX, 0f, mouseY).normalized;
			var angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg - 90;
			var rot =  Quaternion.AngleAxis(-angle, Vector3.up);

			_rotation = Quaternion.Euler(cachedTransform.eulerAngles.x, rot.eulerAngles.y, cachedTransform.eulerAngles.z);
		}

		cachedTransform.rotation = _rotation;//Quaternion.Lerp(cachedTransform.rotation, _rotation, 7f * Time.deltaTime);
		// else
		// {
		// var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		// var endPoint = ray.origin + ray.direction * 15;
		// var oneLevelWithPlayer = endPoint + Vector3.up * (cachedTransform.position.y - endPoint.y);

		// var dx = oneLevelWithPlayer.x - cachedTransform.position.x;
		// var dz = oneLevelWithPlayer.z - cachedTransform.position.z;
		// var angle = Mathf.Atan2(dz, dx) * Mathf.Rad2Deg - 90;
		// var rot =  Quaternion.AngleAxis(-angle, Vector3.up);
		// cachedTransform.rotation = Quaternion.Euler(cachedTransform.eulerAngles.x, rot.eulerAngles.y, cachedTransform.eulerAngles.z);

		// Debug.DrawLine(ray.origin, endPoint, Color.green);
		// Debug.DrawLine(endPoint, oneLevelWithPlayer, Color.red);
		// Debug.DrawLine(cachedTransform.position, oneLevelWithPlayer, Color.blue);
		// }
#endif

	}
}
