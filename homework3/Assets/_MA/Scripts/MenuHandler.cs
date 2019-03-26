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
	
	float getTimeMilli() { return Time.time * 1000.0f; }

	void Start() {
		DOTween.Init();
		DOTween.RewindAll();
	}

	void Update()
	{
		float speed = 1000.0f * Time.deltaTime;
		float line3X = 550;
		bool line3PosReached = line3.transform.position.x >= line3X ? true : false;


		float size = Mathf.Abs(Mathf.Sin(getTimeMilli() * 0.0025f)) * 0.25f + 0.5f;
		line2.transform.DOScale(new Vector3(size, size, 1.0f), 0);

		if (line3.transform.position.x < line3X)
			//line3.transform.Translate(new Vector3(speed, 0.0f, 0.0f));
			//DOTween.To(()=> line3.transform.position, x=> line3.transform.position = x, line3.transform.position + new Vector3(speed, 0.0f, 0.0f), 0);
			line3.transform.DOMove(line3.transform.position + new Vector3(speed, 0.0f, 0.0f), 0);
			
		if(line3PosReached) {
			line3.transform.DORotate(new Vector3(0.0f, 0.0f, speed * 0.025f), 0, RotateMode.LocalAxisAdd);
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
