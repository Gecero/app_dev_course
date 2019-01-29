using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("w"))
            transform.Translate(new Vector3(0.0f, 200.0f * Time.deltaTime, 0.0f));
        if (Input.GetKey("s"))
            transform.Translate(new Vector3(0.0f, -2.0f * Time.deltaTime, 0.0f));

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
