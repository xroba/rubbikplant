using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevel;

	void Start ()
	{
		//if (SceneManager.GetActiveScene().buildIndex == 0) {
		//	Invoke("NextLevel",3);
		//}	
		if (autoLoadNextLevel == 0) {
			Debug.Log("Auto Load is disabled");
		} else {
			Invoke("GoToMenu",autoLoadNextLevel);
		}

	}


	public void LoadLevel(string levelstr)
	{
		Application.LoadLevel(levelstr);
	}

	public void StartGame(){
		Application.LoadLevel("02 Level_01");
	}

	public void QuitGame(){
	 	Application.Quit();
	}

	public void GoToMenu(){
	 	Application.LoadLevel("01a Start");
	}


	public void WinGame (){
		Application.LoadLevel("03a Win");
	}

	public void LostGame (){
		Application.LoadLevel("03b Lost");
	}

	public void NextLevel ()
	{
		if ( (Application.loadedLevel + 1) > 3) {
			WinGame ();
		} else {
			Application.LoadLevel (Application.loadedLevel + 1);
		}
	}



/*	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0){
			NextLevel();
		}
	}
*/	
}
