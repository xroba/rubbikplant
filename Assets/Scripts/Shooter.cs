using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	Animator animator;
	public GameObject projectile;
	public GameObject gun;
	private GameObject projectileFolder;
	private Spawner myLaneSpawner;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		projectileFolder = GameObject.Find("Projectiles");

		//create a parrent if necessary
		if(!projectileFolder)
		{
			projectileFolder = new GameObject("Projectiles");
		}

		SetMyLaneSpawner();

	}
	
	// Update is called once per frame
	void Update () {

		if(isAttackerAheadInLane()){
			animator.SetBool("isAttacking", true);	
		} else {
			animator.SetBool("isAttacking", false);
		}

	}

	bool isAttackerAheadInLane ()
	{

		if (myLaneSpawner.transform.childCount <= 0){
			return false;
		}

		foreach(Transform attacker in myLaneSpawner.transform){
			if(attacker.transform.position.x < transform.position.x){
				//attacker in lane but behind us.
				return false;
			} 
		}

		return true;

	}

	public void SetMyLaneSpawner(){
		//getPosition
		float lanePos = this.transform.position.y;

		Spawner[] spawnerArray = FindObjectsOfType<Spawner>();

		foreach( Spawner spawnlane in spawnerArray ){
			if(spawnlane.transform.position.y == lanePos){
				myLaneSpawner = spawnlane;
				return;
				//Debug.Log("spawner = " + myLaneSpawner);
			}
		}

		Debug.LogError(name + " does not fint the spawner");
	}

	//call on the animator
	private void FireGun(){
		GameObject oProjectile = (GameObject) Instantiate(projectile,gun.transform.position,Quaternion.identity);
		oProjectile.transform.SetParent(projectileFolder.transform);

	}
}
