using UnityEngine;
using System.Collections;

public class bunny : MonoBehaviour {

	public int duplicateNumber;
	float randomTimeToDuplicate;
	Transform currentPosition;

	// Use this for initialization
	void Start () {
		//take a random Sec in order to duplicate
		randomTimeToDuplicate = Random.Range(2,5);
		Invoke("DuplicateBunny",randomTimeToDuplicate);
	}


	void DuplicateBunny(){

			//take the current Position
//			currentPosition = this.transform.position;

			if(duplicateNumber > 2){

				
				Vector3 positionTop = currentPosition.position + new Vector3(0,1,0);
				Vector3 positionDown = currentPosition.position + new Vector3(0,1,0);

			}
	}
}
