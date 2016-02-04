using UnityEngine;
using System.Collections;

public class yarpSendText : MonoBehaviour {

	BufferedPortBottle p;
	int i = 0;
	string destPortName = "/unityRead";
	// Use this for initialization
	void Start () {
		Network.init();
		p = new BufferedPortBottle();

		//while(p.getOutputCount == 0)
		//{
			p.open ("/unityYarp");
		//}
		Network.connect("/unityYarp", destPortName);

	}
	
	// Update is called once per frame
	void Update () {
		i++;
		Bottle bottle = p.prepare ();
		bottle.clear();
		bottle.addString("count");
		bottle.addInt(i);
		p.write();
		Debug.Log("Message Sent");
	}
}
