using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class playbackController : MonoBehaviour {

	public List<Objs> objects;
	// Use this for initialization
	void Start () {
		objects = new List<Objs>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public class Objs : MonoBehaviour {

	GameObject obj;
	String objName;
}
