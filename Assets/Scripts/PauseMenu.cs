using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
	public static bool isPaused = false;
	public GameObject PauseMenuCanvas;

	void Update ()
    {
		if (isPaused)
        {
			PauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
		}
        else
        {
			PauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}
	}

	public void Resume()
    {
        isPaused = false;
	}

	public void Pause()
    {
		isPaused = true;
	}
}