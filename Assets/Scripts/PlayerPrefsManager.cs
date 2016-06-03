using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MUSIC_VOLUME = "music_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_"; 


	public static void SetMusicVolume (float value)
	{
		Debug.Log("change vol" + value);
		if (value >= 0 && value <= 1) {
			PlayerPrefs.SetFloat (MUSIC_VOLUME, value);
		} else {
			Debug.LogError("volume out of range");
		}

	}

	public static float GetMusicVolume ()
	{
		return PlayerPrefs.GetFloat(MUSIC_VOLUME);
	}

	public static void setLevelUnlock (int value)
	{
		if(value <= SceneManager.sceneCountInBuildSettings -1){
			PlayerPrefs.SetInt(LEVEL_KEY + value.ToString(), 1); //yes 1 = true
		} else {
			Debug.LogError("try to check a level that is not on the build order");
		}

	}

	public static bool IsLevelUnlocked (int value)
	{
		int levelvalue = PlayerPrefs.GetInt(LEVEL_KEY+value.ToString());
		bool isLevelUnlocked = (levelvalue == 1);
			
		if (value <= SceneManager.sceneCountInBuildSettings - 1) {
			return isLevelUnlocked;
		} else {
			Debug.LogError("try to check a level that is not on the build order");
			return false;
		}
	}

	public static void setDifficulty (float value)
	{
		if (value >= 0f && value <= 3f) {
			PlayerPrefs.SetFloat(DIFFICULTY_KEY,value);
		} else {
			Debug.LogError("try to setup a ddificulty out of range");
		}
	}

	public static float getDifficulty ()
	{
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
	
}
