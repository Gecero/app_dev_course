using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour {

	public RectTransform line1;
	public RectTransform line2;
	public RectTransform line3;
	public RectTransform startButton;

	float getTimeMilli() { return Time.time * 1000.0f; }

	void Start() {

	}

	void Update()
	{
		float speed = 1000.0f * Time.deltaTime;
		int minX = 550;
		bool line3PosReached = line3.transform.position.x >= minX ? true : false;


		float size = Mathf.Abs(Mathf.Sin(getTimeMilli() * 0.0025f)) * 0.25f + 0.5f;
		line2.transform.localScale = new Vector3(size, size, 1.0f);

		if (line3.transform.position.x < minX)
			line3.transform.Translate(new Vector3(speed, 0.0f, 0.0f));

		if(line3PosReached) {
			line3.transform.Rotate(new Vector3(0.0f, 0.0f, speed * 0.025f));
		}

	}

	private void ChangeScence(string name)
	{
		//Application.LoadLevel(name); // duz not wurk
		//SceneManager.LoadScene(name);
		if (SceneManager.GetActiveScene().buildIndex < (SceneManager.sceneCountInBuildSettings - 1)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		} else {
			// reload current scene
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void StartGame()
	{
		Debug.Log("lol");
		ChangeScence("Game");
	}

}
