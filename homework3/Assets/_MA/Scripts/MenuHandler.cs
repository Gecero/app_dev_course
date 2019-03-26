using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuHandler : MonoBehaviour {
	
	public RectTransform line1;
	public RectTransform line2;
	public RectTransform line3;
	public RectTransform startButton;
	public RectTransform exitButton;
	private Text line1T;
	private Text line2T;
	private Text line3T;
	
	float getTimeMilli() { return Time.time * 1000.0f; }
	
	void adjustGUIRatios() {
		startButton.sizeDelta = new Vector2(Screen.width / 10, Screen.height / 17.5f);
		startButton.transform.position = new Vector3(((float)Screen.width / 1.5f) + startButton.sizeDelta.x, (Screen.height / 4) * 3 + startButton.sizeDelta.y, 0.0f);
		exitButton.sizeDelta = startButton.sizeDelta;
		exitButton.transform.position = new Vector3(startButton.transform.position.x, startButton.transform.position.y * 0.8f, 1.0f);

		line1T.fontSize = (int)Mathf.Sqrt(((float)Screen.width / 8.0f) * ((float)Screen.height / 6.0f));
		line1.transform.position = new Vector3((Screen.width / 2) - (line1T.fontSize * 2.5f), (Screen.height / 4) * 3, 0.0f);
		line2T.fontSize = (int)(Mathf.Sqrt(((float)Screen.width / 8.0f) * ((float)Screen.height / 6.0f)) * 0.25f);
		line2.transform.position = new Vector3(line1.transform.position.x + (line1T.fontSize * 1.25f), (Screen.height / 4) * 2.25f, 0.0f);
		line3T.fontSize = line2T.fontSize + 5;
		line3.transform.position = new Vector3(((float)Screen.width / 2.0f) - (line3T.fontSize * (Mathf.Sin(line3.transform.rotation.z) + Mathf.Pow(3.1415926535897932f, 2))), (float)Screen.height * 0.45f, 0.0f);
	}	
	
	void Start() {
		DOTween.Init();
		DOTween.RewindAll();
		line1T = line1.GetComponent<Text>();
		line2T = line2.GetComponent<Text>();
		line3T = line3.GetComponent<Text>();
	}
	
	void Update() {
		// update the menu stuff
		adjustGUIRatios();
		float speed = 1000.0f * Time.deltaTime;
		float size = Mathf.Abs(Mathf.Sin(getTimeMilli() * 0.0025f)) * 0.25f + 0.5f;
		line2.transform.DOScale(new Vector3(size, size, 1.0f), 0);
		line3.transform.DORotate(new Vector3(0.0f, 0.0f, speed * 0.025f), 0, RotateMode.LocalAxisAdd);
	}

	private void ChangeScence(string name) {
		//Application.LoadLevel(name); // duz not wurk
		//SceneManager.LoadScene(name);
		if (SceneManager.GetActiveScene().buildIndex < (SceneManager.sceneCountInBuildSettings - 1)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		} else {
			// reload current scene
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void StartGame() {
		Debug.Log("lol");
		ChangeScence("Game");
	}

	// https://answers.unity.com/questions/899037/applicationquit-not-working-1.html#answer-1157271
	public void QuitGame() {
		// save any game data here
		#if UNITY_EDITOR
			// Application.Quit() does not work in the editor so
			// UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}

}
