using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health;
	SpriteRenderer spriteRenderer; 
	Color originalcolor;

	void Start(){
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		originalcolor = spriteRenderer.color;
	}


	public void DealDamage(float dmg){
		health -= dmg;

		if(health <= 0){
		 	DestroyObject();
		}
		spriteRenderer.color = Color.red;
		Invoke("ChangeColorToOrinal", 1f * Time.deltaTime);
	}

	void DestroyObject(){
		Debug.Log("destroy");
		Destroy(this.gameObject);
	}

	void ChangeColorToOrinal(){
		spriteRenderer.color = originalcolor;
	}
}
