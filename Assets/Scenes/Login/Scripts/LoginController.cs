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


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Submit() {
        username = usernameField.text;
        streamId = streamIdField.text;
        apiKey = apiKeyField.text;

        PlayerPrefs.SetString("username", username);
        PlayerPrefs.SetString("streamId", streamId);
        PlayerPrefs.SetString("apiKey", apiKey);

        SceneManager.LoadScene("Scenes/World/World");
    }
}
