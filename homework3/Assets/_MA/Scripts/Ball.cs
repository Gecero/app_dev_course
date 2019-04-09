using System;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class Ball : MonoBehaviour
{
	private float collisions = 1.0f;
	public bool makeBallFasterOnCollision;
	private int scoreP1 = 0;
	private int scoreP2 = 0;
	public TextMesh scoreTextMeshP1;
	public TextMesh scoreTextMeshP2;
	private Rigidbody rb;
	private bool firstSpawn = true;
	public bool paused = false;
	private Vector3 lastVelocity = Vector3.zero; // for pausing and unpausing
	private PauseObject po;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		po = GetComponent<PauseObject>();
		po.init(pauseBall, unpauseBall);
		resetPosition();
	}

	// Update is called once per frame
	void Update() {
		checkForGoals();
		
	}

	void FixedUpdate() {
		scoreTextMeshP1.text = scoreP1.ToString();
		scoreTextMeshP2.text = scoreP2.ToString();
	}

	void pauseBall() {
		if(rb.velocity != Vector3.zero) // !!! we need this if because then otherwise both lastVelocity and rb.velocity go to null aka. Vector3.zero and the ball would not move even if its unpaused !!!
			lastVelocity = rb.velocity;
		rb.velocity = Vector3.zero;
	}

	void unpauseBall() {
		rb.velocity = lastVelocity;
		// don't need to "Vector3.zero-ize" lastVelocity because it gets overwritten each way
	}

	void resetPosition() {
		rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
		transform.DOMove(new Vector3(0.2261235f, 0.0f, -6.33f), firstSpawn == true ? 0 : 1);
		collisions = 3.0f;
		float tmpX = UnityEngine.Random.Range(-0.1f, 0.1f);
		if (tmpX > 1.0f)
			tmpX += 1f;
		else if (tmpX < 1.0f)
			tmpX -= 1f;
		else
			tmpX = 1.0f;

		float tmpY = UnityEngine.Random.Range(-0.1f, 0.1f);
		if (tmpY > 1.0f)
			tmpY += 1f;
		else if (tmpY < 1.0f)
			tmpY -= 1f;
		else
			tmpY = 1.0f;
		
		Vector3 tmp = new Vector3(tmpX, tmpY, 0.0f).normalized;
		rb.velocity = new Vector3(tmp.x * collisions, tmp.y * collisions, 0);
		firstSpawn = false;
	}

	void OnCollisionEnter(Collision collision)
	{
		if(makeBallFasterOnCollision)
			collisions += 0.1f;
		Vector3 tempVel = rb.velocity.normalized * (3.0f + collisions);
		rb.velocity = tempVel;
		GetComponent<SoundManager>().playCollisionSound();
	}

	void checkForGoals()
	{
		if (transform.position.x <= -11.0f)
		{
			resetPosition();
			scoreP2++;
			GetComponent<SoundManager>().playGoalSound();
		}
		
		if (transform.position.x >= 11.0f)
		{
			resetPosition();
			scoreP1++;
			GetComponent<SoundManager>().playGoalSound();
		}
	}
}

   
	

