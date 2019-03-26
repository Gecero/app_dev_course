using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioClip goalSound;
	public AudioClip collisionSound;
	public AudioSource source;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playCollisionSound() {
		if (!source.isPlaying) {
			source.pitch = Random.Range(0.9f, 1.1f);
			source.PlayOneShot(collisionSound, 1.0f);
		}
	}

	public void playGoalSound() {
		source.Stop(); // because winning is more important than defending >:D
		source.pitch = 1.0f;
		source.PlayOneShot(goalSound, 1.0f);
	}

}
