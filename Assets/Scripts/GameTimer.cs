using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Slider))]
public class GameTimer : MonoBehaviour {

	Slider gameTimer;
	public float timeOfLevelInSec = 10f;
	float timeRemaining;
	bool isEndLevel;
	LevelManager levelManager;
	GameObject winLabel;

	AudioSource audioSource;

	// Use this for initialization
	void Start ()
	{
		gameTimer = GetComponent<Slider> ();
		gameTimer.maxValue = timeOfLevelInSec;
		timeRemaining = timeOfLevelInSec;
		isEndLevel = false;
		audioSource = GetComponent<AudioSource> ();
		levelManager = FindObjectOfType<LevelManager> ();
		winLabel = GameObject.Find ("YouWinText");

		FindYouWin ();

	}

	void FindYouWin ()
	{
		if (!winLabel) {
			Debug.Log ("mais enfin ");
		}
		else {
			winLabel.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		timeRemaining = timeOfLevelInSec - Time.timeSinceLevelLoad;

		//Debug.Log(timeRemaining);

		gameTimer.value = timeRemaining;

		if (timeRemaining <= 0 && !isEndLevel) {
			audioSource.Play();
			winLabel.SetActive(true);
			Invoke("LoadNextLevel" , audioSource.clip.length);
			isEndLevel = true;

		}
	}

	void LoadNextLevel(){
		levelManager.NextLevel();
	}
}
