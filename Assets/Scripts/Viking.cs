using UnityEngine;
using System.Collections;

public class Viking : MonoBehaviour {

	Attacker attackerScript;
	Animator animatorCtrl;

	// Use this for initialization
	void Start () {
		attackerScript = GetComponent<Attacker>();
		animatorCtrl = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if(!collider.gameObject.GetComponent<Defender>()){
			return;
		}

			animatorCtrl.SetBool("isAttacking", true);
			attackerScript.Attack(collider.gameObject);
		

	}
}
