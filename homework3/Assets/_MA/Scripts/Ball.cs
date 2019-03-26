using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float fCollisions = 1.0f;
    public int iGoalP1 = 0;
    public int iGoalP2 = 0;

	public TextMesh P1Score;
	public TextMesh P2Score;

    public Transform tPlayer;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		float iStart = Random.value;
		if(iStart <= 0.5) {
			rb.velocity = new Vector3(-fCollisions, fCollisions, 0);
		} else {
			rb.velocity = new Vector3(fCollisions, fCollisions, 0);
		}
    }

    // Update is called once per frame
    void Update()
    {
		goal();
		Debug.Log(rb.velocity);
    }

    void FixedUpdate()
    {
		P1Score.text = iGoalP1.ToString();
		P2Score.text = iGoalP2.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
		fCollisions += 0.1f;
		Vector3 tempVel = rb.velocity.normalized * (3 + fCollisions);
		rb.velocity = tempVel;
		GetComponent<SoundManager>().playCollisionSound();
    }

    void goal()
    {
		//Goal query player 2 (Player 1 side)
		if (transform.position.x <= -11.24f)
		{
		    transform.position = new Vector3(0.2261235f, 0.0f, -6.33f);
		    fCollisions = 3.0f;
		    rb.velocity = new Vector3(-fCollisions, -fCollisions, 0);
		    iGoalP2++;
			GetComponent<SoundManager>().playGoalSound();
		}
		
		//Goal query player 1 (player 2 side)
		if (transform.position.x >= 11.24f)
		{
		    transform.position = new Vector3(0.2261235f, 0.0f, -6.33f);
		    fCollisions = 3.0f;
		    rb.velocity = new Vector3(fCollisions, fCollisions, 0);
		    iGoalP1++;
			GetComponent<SoundManager>().playGoalSound();
		}
    }
}

   
    

