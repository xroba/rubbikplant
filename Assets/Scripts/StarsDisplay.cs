using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarsDisplay : MonoBehaviour {

	Text txtDisplayStar;
	public int numberOfStarsCollected = 100;
	public enum status {FAILLURE, SUCCESS};

	// Use this for initialization
	void Start() {
		txtDisplayStar = GetComponent<Text>();
		updateScoreBoard(numberOfStarsCollected);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddStars(int amount){
		numberOfStarsCollected += amount;
		updateScoreBoard(numberOfStarsCollected);

	}

	public status UseStars (int amount)
	{
		if (numberOfStarsCollected >= amount) {
			numberOfStarsCollected -= amount;
			updateScoreBoard (numberOfStarsCollected);
			return status.SUCCESS;
		} 

		return status.FAILLURE;
		
	}

	void updateScoreBoard(int value){
		txtDisplayStar.text = value.ToString();
	} 
}
