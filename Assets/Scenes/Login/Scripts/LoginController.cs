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
    }

    public void Submit() {
        if (usernameField.text != "" && streamIdField.text != "" && apiKeyField.text != "") {
            username = usernameField.text;
            streamId = streamIdField.text;
            apiKey = apiKeyField.text;

            PlayerPrefs.SetString("username", username);
            PlayerPrefs.SetString("streamId", streamId);
            PlayerPrefs.SetString("apiKey", apiKey);

            SceneManager.LoadScene("Scenes/World/World");
        } else {
            displayMessage = true;
        }
    }
}