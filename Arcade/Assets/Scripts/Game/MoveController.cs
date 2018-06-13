using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
	[SerializeField]
	float _speed;

	Rigidbody _thisRigidbody;

	void Awake()
	{
		_thisRigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		var vertical = Input.GetAxis("Vertical");// * Time.deltaTime;
		var horizontal = Input.GetAxis("Horizontal");// * Time.deltaTime;

		_thisRigidbody.velocity = new Vector3(horizontal, 0f, vertical) * _speed;
	}
}
