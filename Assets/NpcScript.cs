using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum NpcState { IDLE,TALK,MOVE,STAND }

public class NpcScript : MonoBehaviour {
    public float speedMove;
    public bool MoveAnimation;
    bool isTalking;
    bool forceTalking;
    NpcState currentNPCState;
    Animator animator;
    GameObject messagePanel;
    Text messageText;

	// Use this for initialization
	void Start () {
        currentNPCState = NpcState.IDLE;
        animator = GetComponent<Animator>();

        messagePanel = GameObject.Find("MessagePanel");
        messageText = messagePanel.GetComponentInChildren<Text>();

        messagePanel.SetActive(false);
        isTalking = false;

    }
	
	// Update is called once per frame
	void Update () {
        
        if (currentNPCState == NpcState.MOVE)
        {
            Debug.Log("Walk");
            animator.SetBool("Stand", false);

            animator.SetBool("Walk", true);
            this.transform.position = new Vector3(this.transform.position.x + speedMove * Time.deltaTime, transform.position.y, transform.position.z);
        }

        if(currentNPCState == NpcState.STAND)
        {
            Debug.Log("Stand");
            animator.SetBool("Walk", false);

            animator.SetBool("Stand", true);
        }

        if (currentNPCState == NpcState.TALK)
        {
            Debug.Log("Talk");
            //first check that the buble is active
            if (!messagePanel.activeSelf)
            {
                messagePanel.SetActive(true);
            }

            animator.SetBool("Stand", false);
            animator.SetBool("Walk", false);

            animator.SetTrigger("TalkTrigger");
        }
        
	}


    public void SetMove(float speedvalue)
    {
        speedMove = speedvalue;
        currentNPCState = NpcState.MOVE;

    }

    public void setStand()
    {
        currentNPCState = NpcState.STAND;
    }

    public void setTalk(string msg)
    {
       
            isTalking = true;
            currentNPCState = NpcState.TALK;
            messageText.text = msg;

    }

}
