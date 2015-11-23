using UnityEngine;
using System.Collections;

public class setLightRGB : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Light>().color = new Color (myScript.globalRed, myScript.globalGreen, myScript.globalBlue);
	}
}
