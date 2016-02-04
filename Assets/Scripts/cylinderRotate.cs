using UnityEngine;
using System.Collections;

public class cylinderRotate : MonoBehaviour {

	Transform cylTransform;
	public int speed;
	// Use this for initialization
	void Start () {
		cylTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(speed*Vector3.right);
	}
}
