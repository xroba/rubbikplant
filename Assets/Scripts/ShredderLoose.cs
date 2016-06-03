using UnityEngine;
using System.Collections;

public class ShredderLoose : MonoBehaviour {

	LevelManager levelManager;
	
	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){

		if (collider.gameObject.GetComponent<Attacker>()){

			levelManager.LostGame();

		}
	}
}
