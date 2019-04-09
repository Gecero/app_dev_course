using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{

	public Rigidbody player1;
	public Rigidbody player2;
	public Rigidbody ball;
	private Vector3 lastPlayer1Velocity = Vector3.zero;
	private Vector3 lastPlayer2Velocity = Vector3.zero;
	public bool shrinkBallOnCollision = false;

	// Start is called before the first frame update
	void Start()
	{
		player1.GetComponent<PauseObject>().init(pausePlayer1, unpausePlayer1);
		player2.GetComponent<PauseObject>().init(pausePlayer2, unpausePlayer2);
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

	void pausePlayer1() { if(player1.velocity != Vector3.zero) { lastPlayer1Velocity = player1.velocity; } player1.velocity = Vector3.zero; }
	void unpausePlayer1() {	player1.velocity = lastPlayer1Velocity;	}
	void pausePlayer2() { if(player2.velocity != Vector3.zero) { lastPlayer2Velocity = player2.velocity; } player2.velocity = Vector3.zero; }
	void unpausePlayer2() { player2.velocity = lastPlayer2Velocity; }
	
}
