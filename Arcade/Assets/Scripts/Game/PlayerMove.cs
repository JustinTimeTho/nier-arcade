using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : CachedMonoBehaviour
{
	[SerializeField]
	float _speed;

	float _vertical, _horizontal;

#if (UNITY_ANDROID || UNITY_IOS)
	[SerializeField]
	float _maxPixels;

	Vector2 _touchStartPosition;

	bool _savedTouchStartPosition;

	float _curSpeed;
#endif

	void Update()
	{
		var playerPosition = cachedTransform.position;

#if (UNITY_ANDROID || UNITY_IOS)
		if (Input.touchCount >= 1)
		{
			var touch = Input.GetTouch(0);

			if ( ! _savedTouchStartPosition)
			{
				_touchStartPosition = touch.position;
				_savedTouchStartPosition = true;
			}

			var direction = (touch.position - _touchStartPosition).normalized;

			_vertical = direction.y;
			_horizontal = direction.x;

			_curSpeed = map(Vector2.Distance(_touchStartPosition, touch.position), 0f, _maxPixels, 0f, _speed);
			if (_curSpeed > _speed)
				_curSpeed = _speed;
			
			if (float.IsNaN(_curSpeed))
				_curSpeed = 0f;
		}
		else
		{
			_vertical = 0f;
			_horizontal = 0f;
			_savedTouchStartPosition = false;
		}

		var velocityVector = new Vector3(_horizontal, 0f, _vertical);
		cachedRigidbody.velocity = Utils.IsNaN(velocityVector) ? Vector3.zero : (velocityVector  * _curSpeed);
#else
		_vertical 	= Input.GetAxis("Vertical");
		_horizontal	= Input.GetAxis("Horizontal");

		cachedRigidbody.velocity = new Vector3(_horizontal, 0f, _vertical) * _speed;
#endif
		
	}

#if (UNITY_ANDROID || UNITY_IOS)
	float map(float x, float in_min, float in_max, float out_min, float out_max)
	{
	return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
	}
#endif
}
