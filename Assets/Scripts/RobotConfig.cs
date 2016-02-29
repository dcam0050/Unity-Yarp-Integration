using UnityEngine;
using System.Collections;

public class RobotConfig
{
	public double maxContactCorrectingVel;
	public double contactFrictionCoefficient;
	public double motorMaxTorque;
	public double motorDryFriction;
	public double jointStopBouncyness;

	public bool valid = false;
	public bool actElevation, actStartHomePos , actLegs, actTorso, actLArm, 
	actRArm, actLHand, actRHand, actHead, actfixedHip, actVision,
	actHeadCover, actWorld, actPressure, actScreen, actLegsCovers, 
	actLeftArmCovers, actRightArmCovers, actTorsoCovers, actSelfCol, 
	actCoversCol, actSkinEmul;

	public RobotConfig()
	{
		//this function loads preferences from the file iCub_parts_activation.ini and sets the flags
		//for now these flags will be hardcoded because they are probably not important to set frequently
		//eventually these parameters will form part of the setup menu coded into the simulator

		//SETUP
		valid = false;

		actElevation = false;
		actStartHomePos = true;

		actLegs = true;
		actTorso = true;
		actLArm = true;
		actRArm = true;
		actLHand = true;
		actRHand = true;
		actHead = true;

		actfixedHip = true;
		actSelfCol = false;
		actCoversCol = false;
		actPressure = false;
		actSkinEmul = false;
		actVision = true;

		maxContactCorrectingVel = 1000; //range from 1 to 2000
		contactFrictionCoefficient = 1.0; //range from 0 to 1 friction on contact surfaces which is taken care of by material in unity
		motorMaxTorque = 1000; //range from 1 to 1000 units Nm
		motorDryFriction = 0.3; //range from 0 to 1 friction at the joints
		jointStopBouncyness = 0.0; //range 0 to 1 how much the joints bounce when stopping

		valid = true;
	}
	
}

