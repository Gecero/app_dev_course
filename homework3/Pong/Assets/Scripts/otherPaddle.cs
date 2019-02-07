using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherPaddle : MonoBehaviour {
	private Rigidbody rb;
	public float paddleSpeed = 1000.0f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow))
			rb.AddForce(Vector3.up * paddleSpeed * Time.deltaTime);
		if (Input.GetKey(KeyCode.DownArrow))
			rb.AddForce(-Vector3.up * paddleSpeed * Time.deltaTime);

	}
}
