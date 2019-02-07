using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTextHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<TextMesh>().text = "Player 1 Score:" + ScoreHandler.playerScore + "\nPlayer 2 Score:" + ScoreHandler.opponentScore;

	}
}
