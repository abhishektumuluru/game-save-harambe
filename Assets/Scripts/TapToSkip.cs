using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TapToSkip : MonoBehaviour {


	void Update () {
	    if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Gameplay");
        }
	}
}
