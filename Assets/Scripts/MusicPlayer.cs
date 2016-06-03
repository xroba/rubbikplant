using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	void Awake (){
		Debug.Log("musicPlayer Awake : " + GetInstanceID());
		if(instance != null){
			Destroy(gameObject);
			Debug.Log("Killing Myself");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	// Use this for initialization
	void Start ()
	{

	}


}
