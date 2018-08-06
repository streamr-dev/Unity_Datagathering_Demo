using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour {
    
    private string username;
    private string streamId;
    private string apiKey;

    public InputField usernameField;
    public InputField streamIdField;
    public InputField apiKeyField;

    bool displayMessage = false;
    bool displayModal = false;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetString("username") != "") {
            usernameField.text = PlayerPrefs.GetString("username");
            streamIdField.text = PlayerPrefs.GetString("streamId");
            apiKeyField.text = PlayerPrefs.GetString("apiKey");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        if (displayMessage) {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 3, 200f, 200f), "All the fields are mandatory.");
        }
        if (displayModal) {
            GUI.ModalWindow(0, new Rect(0, 0, Screen.width, Screen.height), WindowFunction, "Allow Streamr to access your location data for x days?");
        }
    }

    void WindowFunction(int windowId)
    {
        if (GUI.Button(new Rect(Screen.width / 3, Screen.height / 2, Screen.width / 10, Screen.height / 3), "Yes"))
        {
            PlayerPrefs.SetString("permission", "true");
            SceneManager.LoadScene("Scenes/World/World");
        }
        else if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 10, Screen.height / 3), "No"))
        {
            PlayerPrefs.SetString("permission", "false");
            SceneManager.LoadScene("Scenes/World/World");
        }
    }
    public void Submit() {
        if (usernameField.text != "" && streamIdField.text != "" && apiKeyField.text != "") {
            username = usernameField.text;
            streamId = streamIdField.text;
            apiKey = apiKeyField.text;

            PlayerPrefs.SetString("username", username);
            PlayerPrefs.SetString("streamId", streamId);
            PlayerPrefs.SetString("apiKey", apiKey);

            displayModal = true;
        } else {
            displayMessage = true;
        }
    }
}