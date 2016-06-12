using UnityEngine;
using System.Collections;


public class bunny : MonoBehaviour {

	public int duplicateNumber;
	float randomTimeToDuplicate;
	Vector3 currentPosition;
	public GameObject cloneBunnny;
	Animator animatorCtrl;
	Attacker attackerScript;
	public Transform bunnyEffect;
	Spawner[] arrSpawner;


	// Use this for initialization
	void Start () {
		//take a random Sec in order to duplicate
		randomTimeToDuplicate = Random.Range(3,5);
		Invoke("DuplicateBunny",randomTimeToDuplicate);
		Vector3 currentPosition;
		animatorCtrl = GetComponent<Animator>();
		attackerScript = GetComponent<Attacker>();
		arrSpawner = FindObjectsOfType<Spawner>();
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if(!collider.gameObject.GetComponent<Defender>()){
			return;
		}
			animatorCtrl.SetBool("isAttacking", true);
			attackerScript.Attack(collider.gameObject);
	}

	void DuplicateBunny(){

			//take the current Position
			currentPosition = this.transform.position;

			if(duplicateNumber == 2){
			animatorCtrl.SetTrigger("isCloneTrigger");
				if(IsBorderTop() == false){
					Vector3 positionTop = currentPosition + new Vector3(0,1,0);
					SpawnClone(positionTop);
				}

				if(IsBorderBottom() == false){
					Vector3 positionDown = currentPosition + new Vector3(0,-1,0);
					SpawnClone(positionDown);
				}
			}
	}

	void SpawnClone(Vector3 newPosition){
		Instantiate(bunnyEffect,newPosition,Quaternion.identity);
		GameObject goBunny =(GameObject) Instantiate(cloneBunnny,newPosition,Quaternion.identity);
		//also put the bunny inside his spawnerLane
		GameObject mySpawnerLane = FindSpawnerLaneByYPos((int)newPosition.y);
		if(mySpawnerLane){
			goBunny.transform.SetParent(mySpawnerLane.transform);
		} else {

			Debug.LogError("Did not find the spawnLane !");
		}



	 	Animator newBunnnyAnimator = goBunny.GetComponent<Animator>();
		newBunnnyAnimator.SetTrigger("isWakeUpTrigger");
	}

	GameObject FindSpawnerLaneByYPos(int posY){
		foreach(Spawner spawnLane in arrSpawner){
			if (spawnLane.gameObject.transform.position.y == posY){
				return spawnLane.gameObject;
			}
		}
		return null;
	}

	bool IsBorderTop(){
		return this.transform.position.y == 5;
	}

	bool IsBorderBottom(){
		return this.transform.position.y == 1;
	}


}
