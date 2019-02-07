using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleHandler : MonoBehaviour
{
	public float paddleSpeed = 1000.0f;
    public string upKey = "w";
    public string downKey = "s";
    
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(upKey))
			rb.AddForce(Vector3.up * paddleSpeed * Time.deltaTime);
		if(Input.GetKey(downKey))
		    rb.AddForce(-Vector3.up * paddleSpeed * Time.deltaTime);
		
    }
}
