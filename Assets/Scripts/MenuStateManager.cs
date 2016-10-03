using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuStateManager : MonoBehaviour {
	public bool adHidden = true;
    bool isMuted = false;
	void Awake()
	{
		DontDestroyOnLoad(this);
	}

    public void LoadScene(string scene)
    {
        if (PlayerMovement.numTimesPlayed == 0)
        {
                SceneManager.LoadScene("Intro");
        }

        SceneManager.LoadScene(scene);
		if (!adHidden)
		{

			AdManager.Instance.hideBanner();
			adHidden = true;
		}
		showAdOnScene(scene);
    }

	private void showAdOnScene(string Scene)
	{
		if (adHidden) {
			if (Scene == "MainMenu") {
				AdManager.Instance.showBanner ();
				adHidden = false;
			} else if (Scene == "GameOver") {
				if (PlayerMovement.numTimesPlayed % 4 != 0) {
					if (PlayerMovement.numTimesPlayed % 2 == 0) {
						AdManager.Instance.showBanner ();
						adHidden = false;
					}
				} else {
					AdManager.Instance.showInterstitial ();
					adHidden = false;
				}
			} else {
				AdManager.Instance.hideBanner ();
				adHidden = true;
			}
		}
	}
    public void MuteGame()
    {
        bool checkingIfMuted = isMuted;
        checkingIfMuted = !checkingIfMuted;
        isMuted = checkingIfMuted;
        if (checkingIfMuted)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
        PlayerPrefs.SetInt("muted", checkingIfMuted ? 0 : 1);
    }

}

