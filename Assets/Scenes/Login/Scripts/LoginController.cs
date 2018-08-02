using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginController : MonoBehaviour {

    private string username;
    private string streamId;
    private string apiKey;

    private string usernameString = string.Empty;
    private string streamIdString = string.Empty;
    private string apiKeyString = string.Empty;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //void OnGUI()
    //{
    //    GUI.Window(0, windowRect, WindowFunction, "Login");
    //}

    //void WindowFunction(int windowId) {
    //    usernameString = GUI.TextField(new Rect(Screen.width / 3, 2 * Screen.height / 5, Screen.width / 3, Screen.height / 10), usernameString, 15);
    //    streamIdString = GUI.TextField(new Rect(Screen.width / 3, 2 * Screen.height / 5, Screen.width / 3, Screen.height / 10), streamIdString, 30);
    //    apiKeyString = GUI.TextField(new Rect(Screen.width / 3, 2 * Screen.height / 5, Screen.width / 3, Screen.height / 10), apiKeyString, 30);
    //    ethereumString = GUI.TextField(new Rect(Screen.width / 3, 2 * Screen.height / 5, Screen.width / 3, Screen.height / 10), ethereumString, 30);

    //    GUI.Label(new Rect(Screen.width / 3, 35 * Screen.height / 100, Screen.width / 5, Screen.height / 18), "Username");
    //}
}
