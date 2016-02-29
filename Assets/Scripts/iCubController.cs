using UnityEngine;
using System.Collections;

public class iCubController : MonoBehaviour {


	private BufferedPortBottle rightLegState ;

	[Header("Yarp Port Names")]
	public string rLegPortName = "/icubImaginary/right_leg:i";

	private BufferedPortBottle leftLegState ;
	public string lLegPortName = "/icubImaginary/left_leg:i";

	private BufferedPortBottle headState ;
	public string headPortName = "/icubImaginary/head:i";

	private BufferedPortBottle torsoState ;
	public string torsoPortName = "/icubImaginary/torso:i";

	private BufferedPortBottle leftArmState ;
	public string lArmPortName = "/icubImaginary/left_arm:i";

	private BufferedPortBottle rightArmState ;
	public string rArmPortName = "/icubImaginary/right_arm:i";

	[Header("Rig Transforms")]
	public Transform eyeLeft;
	public Transform eyeRight;
	public Transform head;
	public Transform torso;

	public Transform leftUpperArm1;
	public Transform leftUpperArm2;
	public Transform leftUpperArm3;
	public Transform rightUpperArm1;
	public Transform rightUpperArm2;
	public Transform rightUpperArm3;
	public Transform leftLowerArm;
	public Transform leftLowerArm1;
	public Transform rightLowerArm;
	public Transform rightLowerArm1;

	public Transform leftUpperLegx;
	public Transform leftUpperLegy;
	public Transform leftUpperLegz;

	public Transform rightUpperLegx;
	public Transform rightUpperLegy;
	public Transform rightUpperLegz;

	public Transform leftLowerLeg;
	public Transform leftFoot;
	public Transform leftFoot1;
	public Transform rightFoot;
	public Transform rightLowerLeg;

	public Transform rightHand;
	public Transform leftHand;

	[Header("Rig Rotation Offsets")]
	private Vector3 leftEyeOffset = new Vector3(0,0,0);
	private Vector3 rightEyeOffset = new Vector3(0,0,0);
	private Vector3 headOffset = new Vector3(0,0,0);
	private Vector3 torsoOffset = new Vector3(-12,0,0);

	private Vector3 rightUpperArmOffset = new Vector3(-65,0,-30);
	private Vector3 rightLowerArmOffset = new Vector3(0,-45,0);

	private Vector3 leftUpperArmOffset = new Vector3(-65,-7,70);
	private Vector3 leftLowerArmOffset = new Vector3(-16,0,0);

	private Vector3 leftUpperLegOffset = new Vector3(0,180,0);
	private Vector3 leftLowerLegOffset = new Vector3(0,0,0);
	private Vector3 leftFootOffset = new Vector3(-90,90,0);

	private Vector3 rightUpperLegOffset = new Vector3(0,0,180);
	private Vector3 rightLowerLegOffset = new Vector3(0,0,0);

	private Vector3 rightHandOffset = new Vector3 (0, 90, 0);
	private Vector3 leftHandOffset = new Vector3 (0, 90, 0);

	private Vector3 leftEyeVector;
	private Vector3 rightEyeVector;
	private Vector3 leftHandVector;
	private Vector3 rightHandVector;
	private Vector3 headVector;
	private Vector3 torsoVector;
	private Vector3 leftUpperArmVector;
	private Vector3 rightUpperArmVector;
	private Vector3 leftLowerArmVector;
	private Vector3 rightLowerArmVector;
	private Vector3 leftUpperLegVector;
	private Vector3 rightUpperLegVector;
	private Vector3 leftLowerLegVector;
	private Vector3 rightLowerLegVector;

	private int portCheckIter;
	private int portCheckInterval = 30;

	private bool headConnected;
	private bool torsoConnected;
	private bool leftArmConnected;
	private bool rightArmConnected;
	private bool leftLegConnected;
	private bool rightLegConnected;

	private int bottleTagInt;
	private int bottleTagString;
	private int bottleTagDouble;
	private int bottleTagList;

	// Use this for initialization
	void Start () {

		//open all ports
		Network.init();

		rightLegState = new BufferedPortBottle();
		leftLegState = new BufferedPortBottle();

		rightArmState = new BufferedPortBottle();
		leftArmState = new BufferedPortBottle();

		headState = new BufferedPortBottle();
		torsoState = new BufferedPortBottle();

		rightLegState.open (rLegPortName);
		leftLegState.open (lLegPortName);

		rightArmState.open (rArmPortName);
		leftArmState.open (lArmPortName);

		headState.open (headPortName);
		torsoState.open (torsoPortName);

		portCheckIter = 0;

		bottleTagInt = yarp.BOTTLE_TAG_INT;
		bottleTagString = yarp.BOTTLE_TAG_STRING;
		bottleTagDouble = yarp.BOTTLE_TAG_DOUBLE;
		bottleTagList = yarp.BOTTLE_TAG_LIST;
		Debug.Log ("INT: " + bottleTagInt + " DOUBLE: " + bottleTagDouble + " STRING: " + bottleTagString);

	}
	
	// Update is called once per frame
	void Update () {
		//check if port has been connected every 10 update cycles
		if (portCheckIter == portCheckInterval) 
		{
			//check all ports
			Debug.Log ("Checking Ports...");
			headConnected = (headState.getInputCount () > 0);
			torsoConnected = (torsoState.getInputCount () > 0);
			rightArmConnected = (rightArmState.getInputCount () > 0);
			leftArmConnected = (leftArmState.getInputCount () > 0);
			rightLegConnected = (rightLegState.getInputCount () > 0);
			leftLegConnected = (leftLegState.getInputCount () > 0);

			portCheckIter = 0;
		}
		portCheckIter++;

		if (headConnected) 
		{
			Bottle state = headState.read ();

			if(state != null)
			{
				headVector = new Vector3(-(float)state.get(0).asDouble(),-(float)state.get(2).asDouble(),-(float)state.get(1).asDouble());
				leftEyeVector = new Vector3(0,(float)state.get(3).asDouble(),-(float)state.get(4).asDouble());
				rightEyeVector = leftEyeVector;

				leftEyeVector.z = leftEyeVector.z+(float)state.get(5).asDouble();
				rightEyeVector.z = rightEyeVector.z-(float)state.get(5).asDouble();

				head.localRotation = Quaternion.Euler(headVector+headOffset);
				eyeLeft.localRotation = Quaternion.Euler(leftEyeVector+leftEyeOffset);
				eyeRight.localRotation = Quaternion.Euler(rightEyeVector+rightEyeOffset);
			}
		}
		else
		{
			Debug.Log ("Head Disconnected");
		}

		if (torsoConnected) 
		{
			Bottle state = torsoState.read ();
			
			if(state != null)
			{
				torsoVector = new Vector3((float)state.get(2).asDouble(),(float)state.get(0).asDouble(),(float)state.get(1).asDouble());
				torso.localRotation = Quaternion.Euler(torsoVector+torsoOffset);
			}
		}
		else
		{
			Debug.Log ("Torso Disconnected");
		}

		if (rightArmConnected)
		{
			Bottle state = rightArmState.read ();
			
			if(state != null)
			{
				//TODO thumb vectors and finger vectors

				rightUpperArmVector = Vector3.zero;
				rightUpperArmVector.x = (float)state.get(1).asDouble() + rightUpperArmOffset.x;
				rightUpperArmVector.y = (float)state.get(0).asDouble() + rightUpperArmOffset.y;
				rightUpperArm1.localRotation = Quaternion.Euler(rightUpperArmVector); //yaw

				rightUpperArmVector = Vector3.zero;
				rightUpperArmVector.y = (float)state.get(2).asDouble()+rightUpperArmOffset.z;
				rightUpperArm2.localRotation = Quaternion.Euler(rightUpperArmVector); //roll

				rightLowerArmVector = new Vector3(-(float)state.get(3).asDouble(),0,0);
				rightLowerArm.localRotation = Quaternion.Euler(rightLowerArmVector+rightLowerArmOffset);

				rightLowerArmVector = new Vector3(0,(float)state.get(4).asDouble(),0);
				rightLowerArm1.localRotation = Quaternion.Euler(rightLowerArmVector);

				rightHandVector = new Vector3(-(float)state.get(5).asDouble(),0,(float)state.get(6).asDouble());
				rightHand.localRotation = Quaternion.Euler(rightHandVector + rightHandOffset);
			}	
		}
		else
		{
			Debug.Log ("Right Arm Disconnected");
		}

		if (leftArmConnected)
		{
			Bottle state = leftArmState.read ();
			
			if(state != null)
			{
				//TODO thumb vectors and finger vectors
				
				leftUpperArmVector = Vector3.zero;
				leftUpperArmVector.x = (float)state.get(1).asDouble() + leftUpperArmOffset.x;
				leftUpperArmVector.y = -(float)state.get(0).asDouble() + leftUpperArmOffset.y;
				leftUpperArm1.localRotation = Quaternion.Euler(leftUpperArmVector); //yaw
				
				leftUpperArmVector = Vector3.zero;
				leftUpperArmVector.y = -(float)state.get(2).asDouble()+leftUpperArmOffset.z;
				leftUpperArm2.localRotation = Quaternion.Euler(leftUpperArmVector); //roll
				
				leftLowerArmVector = new Vector3(-(float)state.get(3).asDouble(),0,0);
				leftLowerArm.localRotation = Quaternion.Euler(leftLowerArmVector+leftLowerArmOffset);
				
				leftLowerArmVector = new Vector3(0,-(float)state.get(4).asDouble(),0);
				leftLowerArm1.localRotation = Quaternion.Euler(leftLowerArmVector);
				
				leftHandVector = new Vector3((float)state.get(5).asDouble(),0,(float)state.get(6).asDouble());
				leftHand.localRotation = Quaternion.Euler(leftHandVector + leftHandOffset);
			}	
		}
		else
		{
			Debug.Log ("Left Arm Disconnected");
		}

		if (leftLegConnected)
		{
			Bottle state = rightLegState.read ();

			if(state != null)
			{
				rightUpperLegVector = rightUpperLegx.localRotation.eulerAngles;
				rightUpperLegVector.x = -(float)state.get(0).asDouble() + rightUpperLegOffset.x;
				rightUpperLegx.localRotation = Quaternion.Euler(rightUpperLegVector);

				rightUpperLegVector = rightUpperLegy.localRotation.eulerAngles;
				rightUpperLegVector.y = -(float)state.get(2).asDouble()  + rightUpperLegOffset.y;
				rightUpperLegy.localRotation = Quaternion.Euler(rightUpperLegVector);

				rightUpperLegVector = rightUpperLegz.localRotation.eulerAngles;
				rightUpperLegVector.z = -(float)state.get(1).asDouble()  + rightUpperLegOffset.z;
				rightUpperLegz.localRotation = Quaternion.Euler(rightUpperLegVector);

				rightLowerLegVector = Vector3.zero;
				rightLowerLegVector.x = -(float)state.get(3).asDouble();//  + rightLowerLegOffset.x;
				rightLowerLeg.localEulerAngles = rightLowerLegVector;

				rightLowerLegVector = rightFoot.localRotation.eulerAngles;
				rightLowerLegVector.x = -(float)state.get(4).asDouble() + rightLowerLegOffset.y;
				rightLowerLegVector.y = (float)state.get(5).asDouble() + rightLowerLegOffset.z;
				rightFoot.localRotation = Quaternion.Euler(rightLowerLegVector);
			}	
		}
		else
		{
			Debug.Log ("Right Leg Disconnected");
		}

		if (leftLegConnected)
		{
			Bottle state = leftLegState.read ();

			if(state != null)
			{
				leftUpperLegVector = leftUpperLegx.localRotation.eulerAngles;
				leftUpperLegVector.x = -(float)state.get(0).asDouble() + leftUpperLegOffset.x;
				leftUpperLegx.localRotation = Quaternion.Euler(leftUpperLegVector);

				leftUpperLegVector = leftUpperLegy.localRotation.eulerAngles;
				leftUpperLegVector.y = -(float)state.get(2).asDouble()  + leftUpperLegOffset.y;
				leftUpperLegy.localRotation = Quaternion.Euler(leftUpperLegVector);

				leftUpperLegVector = leftUpperLegz.localRotation.eulerAngles;
				leftUpperLegVector.z = -(float)state.get(1).asDouble()  + leftUpperLegOffset.z;
				leftUpperLegz.localRotation = Quaternion.Euler(leftUpperLegVector);

				leftLowerLegVector = Vector3.zero;
				leftLowerLegVector.x = -(float)state.get(3).asDouble();
				leftLowerLeg.localEulerAngles = leftLowerLegVector;

				leftLowerLegVector = leftFoot.localRotation.eulerAngles;
				leftLowerLegVector.x = -(float)state.get(5).asDouble() + leftFootOffset.x;
				leftLowerLegVector.y =  leftFootOffset.y;
				leftLowerLegVector.z =  leftFootOffset.z;
				leftFoot.localRotation = Quaternion.Euler(leftLowerLegVector);
				leftLowerLegVector = Vector3.zero;
				leftLowerLegVector.x = (float)state.get(4).asDouble();
				leftFoot1.localRotation = Quaternion.Euler(leftLowerLegVector);                       
			}	
		}
		else
		{
			Debug.Log ("Left Leg Disconnected");
		}

	}
}


//literals states to connect to
// /icubSim/right_leg/state:o 
// /icubSim/left_leg/state:o
// /icubSim/head/state:o
// /icubSim/left_arm/state:o
// /icubSim/right_arm/sate:o
// /icubSim/torso/state:0