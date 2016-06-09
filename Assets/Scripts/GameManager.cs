using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public bool gameStart;
    float countDown = 5f;
    float timeRemaining = 5f;

    GameObject countDownCanvas;
    Text countdownComponentTxt;
    MusicManager musicManager;



    // Use this for initialization
    void Start () {
        gameStart = false;
        countDownCanvas = GameObject.Find("CountDownTxt");

        if (countDownCanvas)
        {
            countdownComponentTxt = countDownCanvas.GetComponent<Text>();
        }

        musicManager = FindObjectOfType<MusicManager>();

	}
	
	// Update is called once per frame
	void Update () {

        if(timeRemaining > 0)
        {
            timeRemaining = (int)(countDown - Time.timeSinceLevelLoad);
            countdownComponentTxt.text = timeRemaining.ToString();
        } else
        {
            countDownCanvas.SetActive(false);
            gameStart = true;

        }

    }

    public void ChangeMusicForNath()
    {
        if (musicManager)
        {
            musicManager.ChangeMusic(6);
        } else
        {
            Debug.Log("no MUSIC MANAGER");
        }
    }
}
