using UnityEngine;
using System.Collections;

public class FallingKid : MonoBehaviour {

    public float fallSpeed;
    

    void Start()
    {
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
		Vector3 pos = transform.position;
		pos.y += fallSpeed;
		transform.position = pos;
    }
		
}
