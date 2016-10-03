using UnityEngine;
using System.Collections;
using admob;

public class AdManager : MonoBehaviour
{
	public static AdManager Instance{ set; get; }

	private const string BANNER_ID = "HIDDEN_FOR _GITHUB";
	private const string INTERSTITIAL_ID = "HIDDEN_FOR_GITHUB";

	private void Start() {
		Instance = this;
		DontDestroyOnLoad (gameObject);
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		Admob.Instance ().initAdmob (BANNER_ID, INTERSTITIAL_ID);
		Admob.Instance ().loadInterstitial ();
		#endif
	}

	public void showBanner() {
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		Admob.Instance ().showBannerRelative (AdSize.SmartBanner, AdPosition.TOP_CENTER, 0);
		#endif
	}

	public void showInterstitial() {
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		if (Admob.Instance ().isInterstitialReady ()) {
		Admob.Instance ().showInterstitial ();
		}
		#endif
	}

	public void hideBanner() {
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
		Admob.Instance ().removeBanner ();
		#endif
	}
}