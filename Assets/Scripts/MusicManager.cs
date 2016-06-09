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
        Debug.Log("SCENE = " + SceneId);
        if (SceneId == 0)
        {
            return;
        }

		if (SceneId == 1) { //start Menu
			myAudioClip =	arrAudioClips [SceneId];
            audioSource.clip = myAudioClip;
            audioSource.volume = PlayerPrefsManager.GetMusicVolume();
            audioSource.Play();


        } else if (SceneId == 3) //During Game
        {
            myAudioClip = arrAudioClips[SceneId];
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

    public void ChangeMusic(int track)
    {
        Debug.Log("CHANGEMUSIC WITH TRACK = " + track);
        myAudioClip = arrAudioClips[track];
        audioSource.clip = myAudioClip;
        audioSource.volume = PlayerPrefsManager.GetMusicVolume();
        audioSource.Play();
    }
}
