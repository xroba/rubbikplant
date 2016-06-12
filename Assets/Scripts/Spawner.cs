using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] arrAttackers;
	public GameObject[] arrAttackersLvl2;
    public GameObject[] arrAttackersLvl3;
    GameManager gameManager;
    bool canPlay;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        canPlay = false;
    }

	// Update is called once per frame
	void Update () {

        if (gameManager.gameStart)
        {
            foreach (GameObject thisAttacker in arrAttackers)
            {
                if (IsTimeToSpawn(thisAttacker))
                {
                    Spawn(thisAttacker);
                }
            }

            if(Time.timeSinceLevelLoad > 45){

				foreach (GameObject thisAttacker in arrAttackersLvl2)
            	{
	                if (IsTimeToSpawn(thisAttacker))
	                {
	                    Spawn(thisAttacker);
	                }
            	}
            	
            }

            if (Time.timeSinceLevelLoad > 65)
            {

                foreach (GameObject thisAttacker in arrAttackersLvl3)
                {
                    if (IsTimeToSpawn(thisAttacker))
                    {
                        Spawn(thisAttacker);
                    }
                }

            }

        }

		
	}

	bool IsTimeToSpawn (GameObject attackerGameObject)
	{

		Attacker attacker = attackerGameObject.GetComponent<Attacker> ();

		float meanSpawnDelay = attacker.seenEverySeconds; //fox example need to be seen each 5 sec
		//Debug.Log ("meanSpawnDelay = " + meanSpawnDelay);

		float spawnPerSecond = 1 / meanSpawnDelay; // on one second basis = 1/5 = .20 !
		//Debug.Log ("spawnPerSecond = " + spawnPerSecond);

		//Debug.Log(Time.deltaTime +  " > " + meanSpawnDelay);
		if(Time.deltaTime > meanSpawnDelay){
			Debug.Log("Spawn rate capped by frame rate");
		} 

		// for the fox example this is .
		float threshold = spawnPerSecond * Time.deltaTime / 5; //in order to be framerate independant we multiplie by time.deltatime
		//Debug.Log ("threshold = " + threshold);

		float randomValue = Random.value;

		return (randomValue < threshold);
	}

	void Spawn(GameObject attacker){

		GameObject oAtt = (GameObject)Instantiate(attacker);
		oAtt.transform.SetParent(this.transform);
		oAtt.transform.position = transform.position;


	}

}
