using UnityEngine;
using System.Collections;

public class SplashScript : MonoBehaviour {

	public AudioClip splashAudioClip;
	AudioSource audioSource;
	float waitTime;
	LevelManager levelManager;

	// Use this for initialization
	void Start () {
		waitTime = 3f;
        PlayerPrefsManager.SetMusicVolume(0.5f);
        //levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        audioSource = this.GetComponent<AudioSource>();
		audioSource.clip = splashAudioClip;
		audioSource.loop = false;
		audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		float mTime = waitTime - Time.time;
		if(mTime <= 0){
			//levelManager.GoToMenu();
		}
	}
}
