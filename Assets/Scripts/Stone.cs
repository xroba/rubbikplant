using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

	//Only use for tagging ! 

	Animator animator;

	void Start(){
		animator = GetComponent<Animator>();
	}

	void OnTriggerStay2D(Collider2D collider){

		if(collider.gameObject.GetComponent<Attacker>()){
			animator.SetTrigger("isUnderAttackTrigger");
		}
	}

}
