using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {
	private MusicManager musicManager;
	AudioSource audioSource;
	// Use this for initialization
	void Start ()
	{

		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		if (musicManager) {
			musicManager.ChangeVolume (PlayerPrefsManager.GetMusicVolume ());
		} else {
			Debug.LogWarning("MUSIC MANAGER NO FOUND");
		}

				
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
