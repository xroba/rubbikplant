using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	AudioSource audioSource;

	void Start(){
		audioSource = GetComponent<AudioSource>();
	}

	public void PlayFinishLevelSound ()
	{
		Debug.Log(audioSource.clip);
		audioSource.Play();
	}
}
