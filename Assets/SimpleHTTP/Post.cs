﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Post {

    public string username;
    public string userId;
	public double lat;
    public double lng;
    public float? speed;

	public Post(string username, string userId, double lat, double lng, float? speed) {
        this.username = username;
        this.lat = lat;
        this.lng = lng;
        this.userId = userId;
        this.speed = speed;
	}
}
