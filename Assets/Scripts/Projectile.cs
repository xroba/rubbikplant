using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed, damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		Attacker attacker = collider.gameObject.GetComponent<Attacker> ();
		Health health = collider.gameObject.GetComponent<Health> ();

		if (!attacker) {
			return;
		}

		health.DealDamage(damage);

		Destroy(this.gameObject);

	}

}
