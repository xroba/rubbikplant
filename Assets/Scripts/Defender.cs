using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	public int starCost = 100;
	public int DealDmgOnTouch = 0;

	StarsDisplay starsDisplay;

	void Start(){
		 starsDisplay = FindObjectOfType<StarsDisplay>();
	}

	//call on animation only for the sun ! 
	public void CollectStars(int amount){
		//Debug.Log(amount + "collecting star");
		starsDisplay.AddStars(amount);
	}



}
