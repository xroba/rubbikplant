using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreditTextScroll : MonoBehaviour {

	Text textComponent;
	string contentText;
	string currentText;
	public float speedTyping;
	bool stopTyping;
	bool isTyping;


	// Use this for initialization
	void Start () {
		textComponent = GetComponent<Text>();
		currentText = textComponent.text;
		contentText = "";
		isTyping = false;
		stopTyping = false;

		textComponent.text = contentText;
		  
	}
	
	// Update is called once per frame
	void Update () {

		if(!stopTyping && !isTyping){
			isTyping = true;

			StartCoroutine(ScrollText(currentText));
		}
		

	}

	IEnumerator ScrollText(string currentText){

		int currentLetter = 0;

			while(currentLetter < currentText.Length){

				textComponent.text += currentText[currentLetter]; 
				currentLetter++;
				yield return new WaitForSeconds(speedTyping);
			}


	}
}
