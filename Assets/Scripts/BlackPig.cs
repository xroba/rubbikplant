using UnityEngine;
using System.Collections;

public class BlackPig : MonoBehaviour {

	Attacker attackerScript;
	Animator animatorCtrl;
	MusicManager musicManager;
	bool canClick = true;


	// Use this for initialization
	void Start () {
		attackerScript = GetComponent<Attacker>();
		animatorCtrl = GetComponent<Animator>();
		musicManager = FindObjectOfType<MusicManager>();

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


    void OnMouseDown()
    {
        if(musicManager && canClick){
        	musicManager.ChangeMusic(6);
        	canClick = false;
        } else if(musicManager && !canClick){
        	

        }
    }
}
