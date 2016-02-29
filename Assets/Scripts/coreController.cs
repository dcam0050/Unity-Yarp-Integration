using UnityEngine;
using System.Collections;

public class coreController : MonoBehaviour
{
	public RobotConfig configOptions;
	public iCubLogicalJoints icub_joints;

	public PolyDriver head;
	public Property headProps;

	public DriverLinkCreator driverLink;
	public int i = 0;

	public string moduleName = "/icubImaginary";

	string arrToStr(int[] arr)
	{
		string str = "";
		for (int i = 0; i < arr.Length; i++){
			str += " " + arr[i].ToString();
		}
		return str;
	}

	string arrToStr(double[] arr)
	{
		string str = "";
		for (int i = 0; i < arr.Length; i++){
			str += " " + formatDouble(arr[i]);
		}
		return str;
	}

	string formatDouble(double a)
	{
		string str;
		if(a == (int)a)
		{ 
			str = a.ToString("F1");
		}
		else 
		{ 
			str = a.ToString(); 
		}
		return str;
	}

	void Start () {
		configOptions = new RobotConfig();
		if (configOptions.valid) {
			Debug.Log ("Options initialised ok");
			Network.init();

			headProps = new Property();

			//variables
			int rate = 100;
			int[] jntPosMax = new int[]{30,60,55,15,52,90};
			int[] jntPosMin = new int[]{-40,-70,-55,-35,-50,0};
			int[] error_tol = new int[]{1, 1, 1, 1, 1, 1};
			int Type = 3;
			int TotalJoints = 6;
			int[] axisMap = new int[]{0, 1, 2, 3, 4, 5};
			double Vel = 20.0;
			double[] Zeros = new double[]{0.0, 0.0, 0.0, 0.0, 0.0, 0.0};
			double[] Encoder = new double[]{0.017453, 0.017453, 0.017453, 0.017453, 0.017453, 0.017453};
			string partName = "/head";
			string device = "controlboardwrapper2";
			string subdevice = "simulationcontrol";

			//formatting variables into string
			string properties = "(ENDINI) (rate " + rate + ") (LIMITS (jntPosMax";
			properties += arrToStr(jntPosMax);
			properties += ") (jntPosMin";
			properties += arrToStr(jntPosMin);
			properties +=") (error_tol";
			properties += arrToStr(error_tol);
			properties += ")) (GENERAL (Type " + Type;
			properties += ") (TotalJoints " + TotalJoints;
			properties += ") (AxisMap" + arrToStr(axisMap);
			properties += ") (Vel " + formatDouble(Vel);
			properties += ") (Zeros" + arrToStr(Zeros);
			properties += ") (Encoder";
			properties += arrToStr(Encoder);
			properties += ")) (name " + partName + ") (device "+ device;
			properties += ") (subdevice "+ subdevice +")";
			Debug.Log(properties);
			//initialise properties class with string
			headProps.fromString(properties);


		} 
		else 
		{
			Debug.Log("Configuration failed.");
		}
	}

	void Update () {

	}


}



