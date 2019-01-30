using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMover : MonoBehaviour
{

	private Rigidbody rb;
	public float moveSpeed = 175.0f;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey("w"))
		{
			rb.isKinematic = true;
			transform.Translate(new Vector3(0.0f, moveSpeed * Time.deltaTime, 0.0f));
			rb.isKinematic = false;
		}
		if (Input.GetKey("s"))
		{
			rb.isKinematic = true;
			transform.Translate(new Vector3(0.0f, -moveSpeed * Time.deltaTime, 0.0f));
			rb.isKinematic = false;
		}

	}

	// called once at the start of the collision
	void OnCollisionEnter(Collision collisionInfo)
	{
		Debug.Log("collision!!1einself");
	}

	// while the collision
	void OnCollisionStay(Collision collisionInfo)
	{
		Debug.Log("FKN COLLISION DETECTED OMG :|D~");
	}

	// gets called if the collision ends
	void OnCollisionExit(Collision collisionInfo)
	{
		//Debug.Log("no collision anymore d(;d_;)b");
	}

}
