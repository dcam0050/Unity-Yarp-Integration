using UnityEngine;
using System.Collections;

public class driverTest : MonoBehaviour {
	private PolyDriver robotDevice;
	private Property options;
	private IPositionControl pos;
	private IVelocityControl vel;
	private IEncoders enc;

	public string remotePort;
	public string localPort;
	public string deviceType; //can be drop down list

	// Use this for initialization
	void Start () {
		//options.put ("device", deviceType);
		//options.put ("local", localPort);
		//options.put ("remote", remotePort);
		options = new Property ();
		options.put ("device", "controlboardwrapper2");
		options.put ("subdevice", "simulationcontrol");
		options.put ("name", "/icubZobbi/head");

		robotDevice = new PolyDriver(options);
		if (!robotDevice.isValid ()) {
			Debug.Log ("Device not available");
			Debug.Log (Drivers.factory().toString());
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
