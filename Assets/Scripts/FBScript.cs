using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;

public class FBScript : MonoBehaviour {


	public GameObject FBLoggedin;
	public GameObject FBLoggedOut;
	public GameObject DialogUsername;
	public GameObject ProfilePicture;

	void Awake() {
		if (!FB.IsInitialized) {
			FB.Init (SetInit, OnHideUnity);
		} else {
			if (FB.IsLoggedIn) {
				Debug.Log ("FB is logged in!");
			} else {
				Debug.Log ("FB is not logged in!");
			}
			DealWithMenus (FB.IsLoggedIn);
		}

	}

	void SetInit() {
		if (FB.IsInitialized) {
			if (FB.IsLoggedIn) {
				Debug.Log ("FB is logged in!");
			} else {
				Debug.Log ("FB is not logged in!");
			}
			DealWithMenus (FB.IsLoggedIn);
		} else {
			Debug.Log ("Failed to load Facebook");
		}
	}

	void OnHideUnity(bool isGameShown) {
		if (!isGameShown) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}



	public void FBLogin() {
		List<string> permissions = new List<string> ();
		permissions.Add ("public_profile");
		FB.LogInWithReadPermissions (permissions, AuthCallBack);
	}

	void AuthCallBack(IResult result) {
		if (result.Error != null) {
			Debug.Log (result.Error); 
		} else {
			if (FB.IsLoggedIn) {
				Debug.Log ("FB is logged in!");
			} else {
				Debug.Log ("FB is not logged in!");
			}
			DealWithMenus (FB.IsLoggedIn);
		}
	}

	void DealWithMenus(bool isLoggedIn) {
		if (isLoggedIn) {
			FBLoggedin.SetActive (true);
			FBLoggedOut.SetActive (false);

			FB.API ("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
			FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfPic);
		} else {
			FBLoggedin.SetActive (false);
			FBLoggedOut.SetActive (true);
		}
	}

	void DisplayUsername(IResult result) {
		Text username = DialogUsername.GetComponent<Text> ();
		if (result.Error == null) {
			username.text = "Hi there, " + result.ResultDictionary ["first_name"];
		} else {
			Debug.Log (result.Error);
		}
	}

	void DisplayProfPic(IGraphResult result) {
		if (result.Texture != null) {
			Image ProfilePic = ProfilePicture.GetComponent<Image> ();
			ProfilePic.sprite = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 ());
		}
	}

	public void Share() {
		FB.FeedShare (
			string.Empty,
			new Uri ("https://play.google.com/store/apps/details?id=com.neurondev.saveharambe"),
			"Save Harambe!",
			"On the morning May 28th, we lost a brother and a true friend, Harambe. He died for our sins. Can you help him win, to live his wishes?",
			"Check out Save Harambe on the play store!",
			new Uri ("http://i.imgur.com/gHba5zp.png"),
			string.Empty,
			ShareCallback
		);
	}

	void ShareCallback(IResult result) {
		if (result.Cancelled) {
			Debug.Log ("Share Cancelled");
		} else if (!string.IsNullOrEmpty (result.Error)) {
			Debug.Log ("Error on Share!");
		} else if (!string.IsNullOrEmpty (result.RawResult)) {
			Debug.Log ("Success on Share!");
		}
	}

	public void Invite() {

		FB.Mobile.AppInvite (
			new Uri ("https://play.google.com/store/apps/details?id=com.neurondev.saveharambe"),
			new Uri ("http://i.imgur.com/gHba5zp.png"),
			InviteCallback
		);
	}

	void InviteCallback(IResult result) {
		if (result.Cancelled) {
			Debug.Log ("Invite Cancelled");
		} else if (!string.IsNullOrEmpty (result.Error)) {
			Debug.Log ("Error on invite!");
		} else if (!string.IsNullOrEmpty (result.RawResult)) {
			Debug.Log ("Success on Invite!");
		}
	}

	public void ShareWithUsers() {
		FB.AppRequest (
			"I scored " + Score.score +" points on SaveHarambe! I bet you can't beat my score!",
			null,
			new List<object> (){ "app_users" },
			null,
			null,
			null,
			null,
			ShareWithUsersCallback);
	}

	void ShareWithUsersCallback(IResult result) {
		if (result.Cancelled) {
			Debug.Log ("AppReq Cancelled");
		} else if (!string.IsNullOrEmpty (result.Error)) {
			Debug.Log ("Error on AppReq!");
		} else if (!string.IsNullOrEmpty (result.RawResult)) {
			Debug.Log ("I scored " + Score.score +" points on Save Harambe! I bet you can't beat my score!");
		}
	}

	public void Like() {
		Application.OpenURL ("https://www.facebook.com/Save-Harambe-668864553267255");
		Debug.Log ("Pressed");
	}
}