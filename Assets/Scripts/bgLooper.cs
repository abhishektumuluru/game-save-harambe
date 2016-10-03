using UnityEngine;
using System.Collections;

public class bgLooper : MonoBehaviour {
	Transform player;
	float offsetY;

	// Use this for initialization
	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");
		if (player_go == null) {
			Debug.Log ("Couldn't find Player");
			return;
		}

		player = player_go.transform;
		offsetY = transform.position.y - player.position.y;
	}
	
	// Update is called once per frame
	void Update () {	
		if (player != null) {
			Vector3 pos = transform.position;
			pos.y = player.position.y + offsetY;
			transform.position = pos;
		}

	}

	void OnTriggerEnter2D(Collider2D collider)  {
		if (collider.isTrigger) {
			if (collider.tag == "Background") {
				float offsetY = 6.18f * 4;
				Vector3 posi = collider.transform.position;
				posi.y = offsetY + posi.y;
				collider.transform.position = posi;
				Debug.Log ("Success");
			} 	
		}
        if (collider.tag == "Side Wall")
        {
            float offsettY = 1 * 19;
            Vector3 posit = collider.transform.position;
            posit.y += offsettY;
            collider.transform.position = posit;
        }
        if (collider.tag == "Platform") {
			Vector3 posPlat = collider.transform.position;
			posPlat.y += 20.5f;
			collider.transform.position = posPlat;
		}
	}
}