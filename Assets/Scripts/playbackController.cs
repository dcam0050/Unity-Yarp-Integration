using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class playbackController : MonoBehaviour {

	public Dictionary<string, List<GameObject> > objects;
	public string addObj;
	public string objName;
	public bool add;
	private bool internalAdd;
	public Vector3 objTransform;
	private GameObject tempGO;
	private GameObject tempGO2;


	// Use this for initialization
	void Start () {
		objects = new Dictionary<string, List<GameObject> >();

		//important to leave person as first object in the hierarchy before startup 
		tempGO = this.gameObject.transform.GetChild (0).gameObject;
		if (tempGO.transform != null) {
			Debug.Log("Found Person original");
			//add original to list
			objects.Add("personOriginal", new List<GameObject>());
			objects["personOriginal"].Add(tempGO);
			objects["personOriginal"][0].SetActive(false);
		} 
		else 
		{
			Debug.Log("Person instance not found!");
		}

		//load environment. Environment must be configured such that 0,0,0 corresponds with initial position of icub
		//loads an obj which can be a kinect model of the environment. 
		//Future version could allow loading of different environments through menu options
		UnityEngine.Object environment = Instantiate(Resources.Load("environmentSimple"));
		environment.name = "environment";
		//find instance of environment
		tempGO = GameObject.Find("environment");

		if (tempGO.transform != null) {
			Debug.Log("Found Environment");
			//add copy as child to this controller
			tempGO.transform.parent = this.transform;
			//add copy to list
			objects.Add ("environment",new List<GameObject>());
			objects["environment"].Add(tempGO);
		} 
		else 
		{
			Debug.Log("Environment not found!");
		}

	}
	// Update is called once per frame
	void Update () {
		Debug.Log ("Classes Count= " + objects.Count);

		if (!internalAdd & add) 
		{
			Debug.Log ("adding object " + addObj + "...");
			addObject (addObj, objName, objTransform);
		}
		internalAdd = add;

		//if an action is being carried out over multiple update periods
		//action is played out using unity's resumable function

	}

	bool addObject(string obj, string objName, Vector3 objPos, Bottle data = null)
	{
		bool success;

		switch (obj) {
			
		case "person":
			Debug.Log ("Adding person");
			tempGO = objects["personOriginal"][0];
			if(objPos == Vector3.zero)
			{
				objPos = new Vector3(12,0,0);
			}
			tempGO2 = (GameObject)Instantiate(tempGO);
			tempGO2.SetActive(true);
			//parse bottle to retreive face image and apply to plane

			success = true;
			break;
			
		default:
			//try loading resource
			tempGO2 = (GameObject) Instantiate(Resources.Load(obj));
			if(tempGO2.transform != null)
			{
				Debug.Log ("Adding " + obj);
				success = true;
				if(objPos == Vector3.zero)
				{
					objPos = new Vector3(6,7,0);
				}
				//in the future objects will have properties passed from SAM
				success = true;
			}
			else
			{
				Debug.Log ("Object unknown. Not adding");
				success = false;
			}
			break;
		}

		if (success) 
		{
			if(objName != "")
			{
				tempGO2.name = objName;
			}
			//make new object child of controller
			tempGO2.transform.parent = this.transform;
			//assign position to new object
			tempGO2.transform.localPosition = objPos;
			//check if name already assigned
			if (!objects.ContainsKey (obj)) 
			{
				//add new dictionary entry
				objects.Add (obj, new List<GameObject> ());
			} 

			objects [obj].Add (tempGO2);
		}
		return success;
	}
}
