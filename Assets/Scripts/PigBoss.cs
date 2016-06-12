using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NpcScript))]
public class PigBoss : MonoBehaviour {

    public bool isMoving;
    public float speedMove = 1;
    public bool isStanding = false;
    NpcScript npcScript;
    bool persoMsg = false;
    string[] PigBossSentence;
	// Use this for initialization
	void Start () {
        npcScript = GetComponent<NpcScript>();
        
        PigBossSentence = new string[13];
        PigBossSentence[0] = "Je m'ennuie";
        PigBossSentence[1] = "...";
        PigBossSentence[2] = "hmm, c'est toi ... bon vu ton niveau on est pas pret de terminer le jeu";
        PigBossSentence[3] = "Qui touche un cactus se pique !";
        PigBossSentence[4] = "Le pire con c'est le vieux con, on peut rien contre l'expérience.";
        PigBossSentence[5] = "Moi, je ne vis que la nuit, depuis que quelqu'un m'a dit Un jour, tu vas mourir !";
        PigBossSentence[6] = "Je me couche tellement tard et me leve tellement tôt que je me croise dans l'escalier ...";
        PigBossSentence[7] = "Nath si tu vois un cochon clique dessus pour changer de musique";
        PigBossSentence[8] = "Voir une araignée c'est rien, le pire c'est quand tu la voit plus .. !";
        PigBossSentence[9] = "Ned Stark se marie avec la reine des dragons a la fin de la saison ... vrai ou Faux ?";
        PigBossSentence[10] = "Ton Score est de .... ah non on s en fou en fait";
        PigBossSentence[11] = "je dois citer ma soeur Geraldine et mon frere Miguel ... juste une obligation familiale";
		PigBossSentence[12] = "Nath si tu vois un cochon clique dessus pour changer de musique";
    }
	
	// Update is called once per frame
	void Update () {

        if (isMoving)
        {
            npcScript.SetMove(speedMove);
        }

        if(this.transform.position.x > 5 && isMoving)
        {
        	returnToStandPosition();
        }

       
	}

	public void returnToStandPosition(){
			isMoving = false;
			isStanding = true;
            npcScript.setStand();
			

			StartCoroutine(StartTalking());

			//Invoke("retrieveSentenceAndTalk", 5);
    }

    IEnumerator StartTalking()
    {
        while (true)
        {
			yield return 0;
            retrieveSentenceAndTalk();
            yield return new WaitForSeconds(10);
        }
    }

    public void retrieveSentenceAndTalk()
    {
    	//Debug.Log("i m on the coroutine");
        int rndValue = Random.Range(0, PigBossSentence.Length);
        npcScript.setTalk(PigBossSentence[rndValue]);
    }

    public void StartForceTalking(string msg)
    {
        npcScript.setTalk(msg);
    }

	void OnMouseDown ()
	{
		if(!isMoving){
			StartForceTalking("Hi hi ca me chatouille... essaie plutôt de cliquer sur un cochon dans le jeu");
		}
	}


}
