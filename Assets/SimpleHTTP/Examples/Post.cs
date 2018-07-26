using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Post {
	public string title;
	public string body;
	public int userId;

	public Post(string title, string body, int userId) {
		this.title = title;
		this.body = body;
		this.userId = userId;
	}

    public override string ToString() {
        return this.body;
    }
}
