using UnityEngine;
using System.Collections;

public class ColorLights : MonoBehaviour {

	//public float globalRed, globalGreen, globalBlue;
	BufferedPortBottle p;

	// Use this for initialization
	void Start () {
		Network.init();
		p = new BufferedPortBottle();
		p.open ("/unityYarp");

//		globalRed = 1.0f;
//		globalBlue = 0.5f;
//		globalGreen = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
		if (p.getPendingReads () > 0) {
			//gameObject.renderer.material.color = Color.cyan;
			Bottle bot = p.read ();
			if (bot.size () == 3) {
				float globalRed, globalGreen, globalBlue;
				globalRed = (float)bot.get (0).asDouble ();
				globalGreen = (float)bot.get (1).asDouble ();
				globalBlue = (float)bot.get (2).asDouble ();
				GetComponent<Light>().color = new Color(globalRed, globalGreen, globalBlue, 1);
				Debug.Log(globalRed+"    "+globalGreen+"    "+globalBlue);
	
					//gameObject.renderer.material.color= new Color(r, g, b);
			}
		}

	}


}
