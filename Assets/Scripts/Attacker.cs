using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Range (-1f, 1.5f)]
	public float currentSpeed;
	public int seenEverySeconds;
	Animator animator;
	GameObject currentTarget;
	Health health;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		health = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 newPosition = new Vector3(this.transform.position.x + currentSpeed * Time.deltaTime * -1,this.transform.position.y,0);
		transform.position = newPosition;

		if(!currentTarget){
			animator.SetBool("isAttacking",false);
		}
	}


	public void Attack(GameObject obj){
		currentTarget = obj;
	}

	//Call on Animation
	public void setCurrentSpeed (float speed)
	{
		currentSpeed = speed;
	}

	//call from the animator event !!!
	public void StrikeCurrentTarget (float dmg)
	{
		if(currentTarget){

			Debug.Log("CurrentTarget = " + currentTarget);

			Health defenderHealth = currentTarget.GetComponent<Health>();

			if(defenderHealth){
				defenderHealth.DealDamage(dmg);
			}

		}

	}

}
