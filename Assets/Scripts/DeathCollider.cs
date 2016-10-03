using UnityEngine;
using System.Collections;

public class DeathCollider : MonoBehaviour {

    public Camera cam;
	private Vector3 BabyPos;

    void Start () {
	}
	
	void Update () {
    }

    void OnTriggerEnter2D (Collider2D collider)
    { 
		if (collider.tag == "Kid") {
			BabyPos = collider.transform.position;
			if (collider.name == "KidLeft") {
				BabyPos.x = Random.Range (-2.4f, -0.4f);
				BabyPos.y = cam.transform.position.y + 11.53f;
				collider.transform.position = BabyPos;
			} else if (collider.name == "KidRight") {
				BabyPos.x = Random.Range (0.6f, 2.4f);
				BabyPos.y = cam.transform.position.y + 15.66f;
				collider.transform.position = BabyPos;
			}
		}
		if (collider.tag == "Player") {
			PlayerMovement.IsDead = true;
		}
		if (collider.tag == "Banana") {
			Vector3 banPos = collider.transform.position;
			banPos.y += 16.3f + 1.42f;
			collider.transform.position = banPos;
    	}
	}
}
