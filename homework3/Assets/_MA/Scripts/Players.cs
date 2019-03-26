using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{

    public Rigidbody rbPlayer1;
    public Rigidbody rbPlayer2;
    public Rigidbody rbBall;
    public bool bP1 = false;
    public bool bP2 = false;
    public bool bShrink = false;
    public float fForce = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        {
         /*/   //Up
            if (Input.GetKey(KeyCode.W))
            {
                rbPlayer1.AddForce(0, fForce, 0);
            }

            //Down
            if (Input.GetKey(KeyCode.S))
            {
                rbPlayer1.AddForce(0, -fForce, 0);
            }

        }//Player1 Controll
        
        {
            //Up
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rbPlayer2.AddForce(0, fForce, 0);
            }

            //Down
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rbPlayer2.AddForce(0, -fForce, 0);
            }
            /*/
        }//Player2 Controll

            rbPlayer1.AddForce(new Vector3(0, Input.GetAxis("VerticalLeft") * 10.0f, 0));
            rbPlayer2.AddForce(new Vector3(0, Input.GetAxis("VerticalRight") * 10.0f, 0));
            
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (bShrink == true)
        {
            rbPlayer1.transform.localScale += new Vector3(0, -1.0f, 0);
            rbPlayer2.transform.localScale += new Vector3(0, -1.0f, 0);
        }
    }
}
