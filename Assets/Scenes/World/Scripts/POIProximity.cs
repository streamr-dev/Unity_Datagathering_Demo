using System.Collections;
using System.Collections.Generic;    
using UnityEngine;
using UnityEngine.UI;

public class POIProximity : MonoBehaviour {

    private List<string> nearbyPOIS;
    [SerializeField] private Player player;

    public List<string> getNearbyPOIS() {
        return nearbyPOIS;
    }

    // Update is called once per frame
    void Update()
    {
        nearbyPOIS = new List<string>();
        Transform[] allChildren = GetComponentsInChildren<Transform>();

        foreach (Transform child in allChildren)
        {
            if (child.ToString().Contains("Food")) {
                if ((child.transform.position - player.transform.position).magnitude < 30.0) {
                    nearbyPOIS.Add(child.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text);
                }
            }
        }
    }
}  

