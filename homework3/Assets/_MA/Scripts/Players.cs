using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{

	public Rigidbody player1;
	public Rigidbody player2;
	public Rigidbody ball;
	public bool shrinkBallOnCollision = false;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update() {
		player1.AddForce(new Vector3(0, Input.GetAxis("VerticalLeft") * 10.0f, 0));
		player2.AddForce(new Vector3(0, Input.GetAxis("VerticalRight") * 10.0f, 0));
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (shrinkBallOnCollision == true) {
			player1.transform.localScale += new Vector3(0, -1.0f, 0);
			player2.transform.localScale += new Vector3(0, -1.0f, 0);
		}
	}
}
