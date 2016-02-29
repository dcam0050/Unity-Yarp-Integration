using UnityEngine;
using System.Collections;

public class OdeLogicalJoint : LogicalJoint
{
	private int number;
	private string unit;
	private string type;
	private int joint;
	private int feedback;
	private Vector3 axis;
	private double speed;
	private double torque;
	private double speedSetpoint;
	private bool hinged;
	private int universal;
	private int sign;
	private int subLength;
	private bool active;
	private double vel;
	private double acc;
	private PidFilter filter;
	private OdeLogicalJoint left, right, peer;
	private OdeLogicalJoint[] sub;
	
	private double dryFriction;
	private double maxTorque;

	private int verge;

	//this class obtains the joint data from ode and passes the values on
	//this eventually interfaces with joints in model for now fixed values
	public OdeLogicalJoint()
	{
		filter = new PidFilter (6, 0.3, 0.0, 100);
		active = false;
		verge = 0;
		speedSetpoint = 0;
		number = -1;
		vel = 1;
		acc = 1;
	}

	public OdeLogicalJoint[] nest(int len) 
	{
		sub = null;
		sub = new OdeLogicalJoint[len];
		for (int i=0; i<len; i++) {
			sub[i] = new OdeLogicalJoint();
		}
		subLength = len;
		return sub;
	}

	/**
     * Initialize a regular control unit.
     */
	public void init(string unit, string type, int index, int sign, RobotConfig conf)
	{
		//initialise parameters for particular joint type, name and index
		this.number = index;
		this.type = type;
		this.unit = unit;
		this.dryFriction = conf.motorDryFriction;
		this.maxTorque = conf.motorMaxTorque;
		this.sign = sign;
	}

	public void init(OdeLogicalJoint left, OdeLogicalJoint right, OdeLogicalJoint peer, int sgn) 
	{
		active = true;
		verge = sgn;
		sign = 1;
		this.left = left;
		this.right = right;
		this.peer = peer;
	}

	/**
     * Get the angle of an associated joint, in ICUB units and sign.
     */
	public double getAngle() 
	{
		return getAngleRaw()*sign;
	}
	
	/**
     * Get the angular velocity of an associated joint, in ICUB units and sign.
     */
	public double getVelocity() 
	{
		return getVelocityRaw()*sign;
	}
	
	/**
     * Get the angle of an associated joint in unconverted units and sign.
     */
	public double getAngleRaw()
	{
		return 25;
	}
	
	/**
     * Get the velocity of an associated joint in unconverted units and sign.
     */
	public double getVelocityRaw()
	{
		return 1.2;
	}
	
	/**
     * Get the current target velocity.
     */
	public double getSpeedSetpoint() 
	{
		return speedSetpoint;
	}
	
	//test for torque
	public double getTorque()
	{
		return torque;
	}
	
	public void setTorque(double target)
	{
		this.torque = target;
	}
	
	/**
     * Set velocity and acceleration control parameters.
     */
	public void setControlParameters(double vel, double acc)
	{
		this.vel = vel;
		this.acc = acc;
	}
	
	/**
     * Drive towards an angle setpoint (in ICUB units/sign).
     */
	public void setPosition(double target)
	{
		double error = target - getAngleRaw()*sign;
		double ctrl = filter.pid(error);
		setVelocityRaw(ctrl*sign*vel);
	}


	/**
     * Set velocity of joint (in ICUB units/sign).
     */
	public void setVelocity(double target)
	{
		setVelocityRaw(sign*target);
	}
	
	/**
     * Set raw velocity of joint (in ODE units/sign).
     */
	public void setVelocityRaw(double target)
	{
		speedSetpoint = target;
		if (verge==0) {
			if (speed != null){
				speed = speedSetpoint;
			}
		}
	}
	
	public virtual bool isValid() {
		return (number != -1) || (verge != 0);
	}
	
	public void controlModeChanged(int cm)
	{

	}
}

