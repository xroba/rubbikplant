using UnityEngine;
using System.Collections;

public class DefenderSpawn : MonoBehaviour {

	GameObject defenderFolder;
	StarsDisplay starsDisplay;
	// Use this for initialization
	void Start () {
	 starsDisplay = FindObjectOfType<StarsDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown ()
	{
	Debug.Log("1");
		if (Button.selectedDefender) {
		Debug.Log("2");

			GameObject selectDefender = Button.selectedDefender;
			int defenderCost = selectDefender.GetComponent<Defender>().starCost;

			if (starsDisplay.UseStars(defenderCost) == StarsDisplay.status.FAILLURE) {
				Debug.Log("not egnouf credit available : ");
				return;
			}

			if(!GameObject.Find("Defenders")){
				defenderFolder = new GameObject("Defenders");
			}

			SpawnDefender ();
		}

	}

	void SpawnDefender ()
	{
		Vector2 nPos = SnapToGrid (CalculateWorldPointOfMouseClip ());

		GameObject defender = (GameObject)Instantiate (Button.selectedDefender.gameObject);
		defender.transform.position = new Vector3 (nPos.x, nPos.y, 0f);
		defender.transform.SetParent (defenderFolder.transform);
	}

	Vector2 SnapToGrid(Vector2 position){
		int posx = Mathf.RoundToInt(position.x);
		int posy = Mathf.RoundToInt(position.y);

		return new Vector2(posx,posy);
	}

	Vector2 CalculateWorldPointOfMouseClip ()
	{
		 Vector3 mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		 return new Vector2(mpos.x,mpos.y);
	}
}
