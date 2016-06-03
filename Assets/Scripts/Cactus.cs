using UnityEngine;
using System.Collections;

public class Cactus : MonoBehaviour {

	Defender defender;

	void Start ()
	{
		defender = GetComponent<Defender>();
	}

	void OnTriggerStay2D(Collider2D other) {

		if( other.GetComponent<Attacker>() ){
			Health AttackerHealth = other.GetComponent<Health>();
			AttackerHealth.DealDamage(defender.DealDmgOnTouch);
		}
    }


}
