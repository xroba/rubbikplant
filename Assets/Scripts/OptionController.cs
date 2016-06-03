using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class OptionController : MonoBehaviour {

	MusicManager musicManager;
	public Slider volumeSlider;
	public Slider difficultySlider;
	float _volume;
	float _difficulty;

	void Start ()
	{
		musicManager = FindObjectOfType<MusicManager>();
		//volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
		volumeSlider.value = PlayerPrefsManager.GetMusicVolume();
		//difficultySlider = GameObject.Find("DifficultySlider").GetComponent<Slider>();
		difficultySlider.value = PlayerPrefsManager.getDifficulty();

	}
	
	public void AdjustVolume(float volume){
		Debug.Log("Vol:" + _volume);
		_volume = volume;
		musicManager.ChangeVolume(_volume);
	}

	public void AdjustDifficulty (float difficulty)
	{
		_difficulty = difficulty;
	}

	public void setDefault ()
	{
		_volume = 0.8f;
		_difficulty = 2f;
		volumeSlider.value = _volume;
		difficultySlider.value = _difficulty;
	}

	public void SaveAndExit(){
		PlayerPrefsManager.SetMusicVolume(_volume);
		PlayerPrefsManager.setDifficulty(_difficulty);
		SceneManager.LoadScene("01a Start");
	}


}
