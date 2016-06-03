using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelFadeIn : MonoBehaviour {

	Image fadePanel;
	float timeToFade;
	Color currenColor = Color.black;
	bool isFade;
	int maxFade;


	// Use this for initialization
	void Start () {
		fadePanel = this.GetComponent<Image>();
		timeToFade = 2f;
		isFade = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.timeSinceLevelLoad < timeToFade) {
			//fadeIn
			float alpha = Time.deltaTime / timeToFade;
			currenColor.a -= alpha;
			fadePanel.color = currenColor;

		} else {
		 	this.gameObject.SetActive(false);
		}
	}

}
