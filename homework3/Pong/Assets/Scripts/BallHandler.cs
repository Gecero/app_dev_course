using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    public float speed = 10.0f;
	public static float x, y, z;
    private float rotation;
	private float vx;
	private float vy;
	private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotation = Random.Range(-10.0f, 10.0f);
        rotation = 1.0f;
		updateVelocity();
		//rb.AddForce(getVelocity()*10000.0f);
		rb.velocity = new Vector3(0.5f, 0.5f, 0.0f);

	}

    void updateVelocity() {
        vx = Mathf.Sin(rotation) * Time.deltaTime * speed;
        vy = Mathf.Cos(rotation) * Time.deltaTime * speed;
    }

    Vector3 getVelocity() {
        return new Vector3(0.0f, vy, vx) * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(getVelocity());
        updateVelocity();
		//transform.position = Vector3.Reflect(transform.position, Vector3.right);
		//x = transform.position.x;
		//y = transform.position.y;
		//z = transform.position.z;
		checkPosition();
	}

	void resetPosition()
	{
		transform.position = new Vector3(0.0f, 0.0f, -3.0f);
		rotation = Random.Range(-10.0f, 10.0f);
		updateVelocity();
		rb.AddForce(getVelocity());
	}

	void checkPosition()
	{
		if(transform.position.z > 1.21f)
		{
			ScoreHandler.playerScore += 1;
			resetPosition();
		}
		if(transform.position.z < -9.0f)
		{
			ScoreHandler.opponentScore += 1;
			resetPosition();
		}
	}

	void OnCollisionStay(Collision collision) {
		//Debug.Log("collischn dihtektett");
		//   rotation = (4.0f*3.141592653589732f) - rotation;
		Vector3 tmp = Vector3.Reflect(transform.position, collision.contacts[0].normal);
		rb.AddForce(tmp);
		//rb.velocity = tmp;
	}
	
}
