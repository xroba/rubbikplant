using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour {

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

		if (collider.gameObject.GetComponent<Stone>()) {
			animatorCtrl.SetTrigger ("Jump Trigger");
		} else {
			animatorCtrl.SetBool("isAttacking", true);
			attackerScript.Attack(collider.gameObject);
		}

	}
}
