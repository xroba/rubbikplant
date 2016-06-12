using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageText : MonoBehaviour {

	Text messageText;
	string defaultmsg = "Nath Click sur un cochon pour changer de musique !";

	public string[] arrMsg;


	// Use this for initialization
	void Start () {
		messageText = GetComponent<Text>();
	   
	}


	public void WriteMessage(string msg){
		messageText.text = msg;
	}
}
