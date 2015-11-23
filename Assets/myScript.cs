using UnityEngine;
using System.Collections;

public class myScript : MonoBehaviour {

	BufferedPortBottle p;
	public static float globalRed, globalGreen, globalBlue;
	// Use this for initialization
	void Start () {
		Network.init();
		p = new BufferedPortBottle();
		p.open ("/unityYarp");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			gameObject.GetComponent<Renderer>().material.color = Color.red;
				}
		if (Input.GetKeyDown (KeyCode.G)) {
			gameObject.GetComponent<Renderer>().material.color = Color.green;
		}
		if (Input.GetKeyDown (KeyCode.B)) {
			gameObject.GetComponent<Renderer>().material.color = Color.blue;
		}

		if (p.getPendingReads () > 0) {
			gameObject.GetComponent<Renderer>().material.color = Color.cyan;
			Bottle bot = p.read();
			if (bot.size() == 3) {
				float r = (float)bot.get (0).asDouble();
				float g = (float)bot.get (1).asDouble();
				float b = (float)bot.get (2).asDouble();
				gameObject.GetComponent<Renderer>().material.color= new Color(r, g, b);
				globalRed = r;
				globalGreen = g;
				globalBlue = b;
			}
			if (bot.size () == 1) {
				transform.Translate(0, 5, 0);
			}
		}

	}
}
