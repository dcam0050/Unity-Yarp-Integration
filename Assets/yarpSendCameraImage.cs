using UnityEngine;
using System.Collections;

public class yarpSendCameraImage : MonoBehaviour {
	
	BufferedPortBottle p;
	int i = 0;
	public string destPortName;
	public string sourcePortName;
	public RenderTexture view;
	// Use this for initialization
	void Start () {
		Network.init();
		p = new BufferedPortBottle();
		p.open (sourcePortName);

		Network.connect(sourcePortName, destPortName);
	}
	
	// Update is called once per frame
	void Update () {
			
	}
}
