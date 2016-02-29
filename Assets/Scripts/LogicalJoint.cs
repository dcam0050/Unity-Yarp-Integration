using UnityEngine;
using System.Collections;

public class LogicalJoint : DeviceDriver
{
	/**
     * Get the angle of an associated joint, in ICUB units and sign.
     */
	public virtual double getAngle() {return 0;}
	
	/**
     * Get the angular velocity of an associated joint, in ICUB units and sign.
     */
	public virtual double getVelocity() {return 0;}
	
	/**
     * Set velocity and acceleration control parameters.
     */
	public virtual void setControlParameters(double vel, double acc) {}
	
	/**
     * Drive towards an angle setpoint (in ICUB units/sign).
     */
	public virtual void setPosition(double target) {}
	
	/**
     * Set velocity of joint (in ICUB units/sign).
     */
	public virtual void setVelocity(double target) {}
	
	public virtual bool isValid() {return false;}

	/**
     * this is just a fake torque interface for now
     */
	public virtual double getTorque() {return 0;}
	
	/**
     * Set the reference torque.
     */
	public virtual void setTorque(double target) {}
	
	public virtual void controlModeChanged(int cm) {}

}

public class LogicalJoints : LogicalJoint
{
	public virtual LogicalJoint control(int part, int axis)
	{
		LogicalJoint logJoint = new LogicalJoint ();
		return logJoint;
	}
}