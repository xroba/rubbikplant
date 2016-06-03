using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public AudioClip[] arrAudioClips;
	AudioSource audioSource;
	AudioClip myAudioClip;

	void Awake ()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	void Start ()
	{
		audioSource = this.GetComponent<AudioSource>();
		//audioSource.clip = splashAudioClip;
		audioSource.loop = false;
		audioSource.volume = PlayerPrefsManager.GetMusicVolume();

		//audioSource.Play();
	}

	void Update(){
		//Debug.Log(PlayerPrefsManager.GetMusicVolume());
	}

	void OnLevelWasLoaded (int SceneId)
	{

		if (SceneId == 1) { //start
			myAudioClip =	arrAudioClips [SceneId];
			audioSource.clip = myAudioClip;
			audioSource.volume = PlayerPrefsManager.GetMusicVolume();
			audioSource.Play();	
		}
	}

	public void ChangeVolume (float volume)
	{
		Debug.Log("YEAH Volume change" + volume);
		audioSource.volume = volume;
	}
}
