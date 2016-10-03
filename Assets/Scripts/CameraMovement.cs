using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public GameObject Harambe;
    private Vector3 CameraPosition;

    void Start () {
        CameraPosition = transform.position;
	}
	
	void Update () {
        
        if (Harambe.transform.position.y >= transform.position.y)
        {
            CameraPosition.y = Harambe.transform.position.y;
            transform.position = CameraPosition;
        }
	}
}
