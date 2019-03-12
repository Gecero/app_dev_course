using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    public float speed = 10.0f;
    public float respawnSpeed = 250.0f;
	private Rigidbody rb;
    private float collisions = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        resetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        checkPosition();
	}

	void resetPosition()
	{
        rb.transform.position = new Vector3(0.0f, 0.0f, 5.0f);

        rb.AddForce(new Vector3(0, Random.Range(-0.5f, 0.5f) * respawnSpeed, Random.Range(-1.0f, 1.0f) * respawnSpeed));
    }

	void checkPosition()
	{
		if(transform.position.z > 12.0f)
		{
			ScoreHandler.playerScore += 1;
			resetPosition();
		}
		if(transform.position.z < -20.0f)
		{
			ScoreHandler.opponentScore += 1;
			resetPosition();
		}
	}

    private void OnCollisionEnter(Collision collision)
    {
        collisions += 0.1f;
        Vector3 temp = rb.velocity.normalized * (3.0f + collisions);
        rb.velocity = temp;
    }

}
