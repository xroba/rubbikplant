using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	SpriteRenderer iconSprite;
	Button[] arrayButton;
	public GameObject prefab;
	Text costText;
	public static GameObject selectedDefender;
	
	// Use this for initialization
	void Start () {
		iconSprite = GetComponent<SpriteRenderer>();
		arrayButton = FindObjectsOfType<Button>();
		costText = GetComponentInChildren<Text>();

		costText.text = prefab.GetComponent<Defender>().starCost.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown ()
	{
		//Debug.Log ("press button");

		foreach (Button btn in arrayButton) {
			btn.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
		}

		iconSprite.color = Color.white;

		//set the static
		selectedDefender = prefab;

	}
}
