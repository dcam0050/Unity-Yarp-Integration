using UnityEngine;
using System.Collections;

public class iCubSimulationControl : DeviceDriver
{
	string MODE_IDLE = "00";
	string MODE_POSITION = "01";
	string MODE_VELOCITY = "02";
	string MODE_TORQUE = "03";
	string MODE_IMPEDANCE_POS  = "04";
	string MODE_IMPEDANCE_VEL = "05";
	string MODE_OPENLOOP = "50";
	// string MODE_MIXED = 					//VOCAB_CM_MIXED
	//#define MODE_FORCE_IDLE                 VOCAB_CM_FORCE_IDLE
	//#define MODE_HW_FAULT                   VOCAB_CM_HW_FAULT
	//#define MODE_CALIBRATING                VOCAB_CM_CALIBRATING
	//#define MODE_CALIB_DONE                 VOCAB_CM_CALIB_DONE
	//#define MODE_NOT_CONFIGURED             VOCAB_CM_NOT_CONFIGURED
	//#define MODE_CONFIGURED                 VOCAB_CM_CONFIGURED
	//#define MODE_UNKNOWN                    VOCAB_CM_UNKNOWN

	public int verbosity;
	protected PolyDriver joints;
	protected LogicalJoints manager;
	
	protected Semaphore _mutex;
	protected Semaphore _done;
	
	protected bool _writerequested;
	protected bool _noreply;
	protected bool _opened;
	
	//current position of the joints
	protected double current_jnt_pos;
	protected double current_mot_pos;
	
	//torque of the joints
	protected double current_jnt_torques; // at the moment this is fake
	protected double current_mot_torques; // at the moment this is fake
	
	//openloop/pwm value
	protected double openloop_ref; // at the moment this is fake
	
	//current velocity of the joints
	protected double current_jnt_vel;
	protected double current_mot_vel;
	
	//next position of the joints
	protected double next_pos;
	protected double ref_command_positions;
	protected double ref_positions;
	
	//next velocity of the joints during velocity control
	protected double next_vel;
	protected double ref_command_speeds;
	protected double ref_speeds;
	
	//next torques of the joints during torque control
	protected double next_torques;
	protected double ref_torques;
	
	//semaphore access for synch with run function of webots
	protected int semaphoreNum;
	
	protected int partSelec;
	// number of joints/axes/controlled motors
	protected int njoints;
	
	// velocity
	protected double vel;
	
	//rate at which the position are updated im ms
	//int positionUpdateRate;
	protected static  int positionUpdateRate = 100;
	
	//axis remapping lookup-table
	protected int axisMap;                              
	// angle to encoder conversion factors
	protected double angleToEncoder;                    
	
	protected double zeros;                             // encoder zeros /
	protected double newtonsToSensor;
	
	protected double error_tol;
	
	protected bool motor_on;
	protected int motor;
	protected double[] ErrorPos = new double[100];
	protected int input;
	protected int inputs;  // in fact we need an "input" flag for every joint /
	protected double vels; // in fact we need a velocity for every joint /
	
	protected double limitsMin;                         // joint limits, min
	protected double limitsMax;                         // joint limits, max
	protected double velLimitsMin;                      // joint vel limits, min
	protected double velLimitsMax;                      // joint vel limits, max
	protected double torqueLimits;                      // torque limits
	protected double maxCurrent;                        // max motor current (simulated)
	protected double rotToEncoder;                      // angle to rotor conversion factors
	protected double gearbox;                           // the gearbox ratio
	protected double refSpeed;
	protected double refAccel;
	protected double controlP;
	protected bool   hasHallSensor;
	protected bool   hasTempSensor;
	protected bool   hasRotorEncoder;
	protected int    rotorIndexOffset;
	protected int    motorPoles;
	
	protected int    controlMode;
	protected int    interactionMode;
	
	protected Pid    position_pid;
	protected Pid    torque_pid;
	protected Pid    current_pid;
	protected MotorTorqueParameters motor_torque_params;
	SWIGTYPE_p_yarp__sig__Matrix kinematic_mj;
	// protected bool velocityMode;


	static bool NOT_YET_IMPLEMENTED(string txt)
	{
		Debug.Log(txt + " not yet implemented for iCubSimulationControl");
		return false;
	}
	
	static bool DEPRECATED(string txt)
	{
		Debug.Log(txt + " has been deprecated for embObjMotionControl");
		return true;
	}

	//private iCubSimulationControl( iCubSimulationControl){

	//}

	private int ControlModes_yarp2iCubSIM(int yarpMode)
	{
		return 1;
	}

	private int ControlModes_iCubSIM2yarp(int iCubMode)
	{
		return 1;
	}
	
	private void compute_mot_pos(double mot, double jnt)
	{
		
	}
	
	private void compute_mot_vel(double mot, double jnt)
	{
		
	}

	/*
    Default Constructor. Construction is done in two stages, first build the
    object and then open the device driver.
    */

	public iCubSimulationControl ()
	{
		_opened = false;
		manager = null;
	}

	/**
   * Destructor.
   */
	~iCubSimulationControl()
	{

	}

	/*
    Open the device driver and start communication with the hardware.
    @param config is a Searchable object containing the list of parameters.
    @return true on success/failure.
    */
	 bool open(Searchable config)
	{
		Searchable p = config;
		if (!p.check ("GENERAL", "section for general motor control parameters")) {
			Debug.Log ("Cannot understand configuration parameters");
			return false;
		}

		//int TypeArm = p.findGroup("GENERAL").check("Type",Value(1),"what did the user select?").asInt();
		//Debug.Log (TypeArm);
		return true;
	}

	public virtual bool close()
	{
		return false;
	}

	// IEncoderTimedRaw
	
	public virtual bool getEncodersTimedRaw(double encs, double stamps)
	{
		return false;
	}

	public virtual bool getEncoderTimedRaw(int j, double encs, double stamp)
	{
		return false;
	}
	
	
	///////////// OPENLOOP INTERFACE
	//
	public virtual bool setRefOutputRaw (int j, double v)
	{
		return false;
	}
	public virtual bool setRefOutputsRaw (double v)
	{
		return false;
	}

	public virtual bool getRefOutputRaw (int j, double v)
	{
		return false;
	}

	public virtual bool getRefOutputsRaw (double v)
	{
		return false;
	}

	public virtual bool getOutputRaw (int j, double v)
	{
		return false;
	}

	public virtual bool getOutputsRaw (double v)
	{
		return false;
	}

	public virtual bool setOpenLoopModeRaw ()
	{
		return false;
	}

	/////////////////////////////// END OPENLOOP INTERFACE
	
	///////////// PID INTERFACE
	//
	public virtual bool setPidRaw(int j, Pid pid)
	{
		return false;
	}

	public virtual bool setPidsRaw(Pid pids)
	{
		return false;
	}

	public virtual bool setReferenceRaw(int j, double refVal) //refVal oiginally ref
	{
		return false;
	}

	public virtual bool setReferencesRaw(double refs)
	{
		return false;
	}

	public virtual bool setErrorLimitRaw(int j, double limit)
	{
		return false;
	}

	public virtual bool setErrorLimitsRaw(double limits)
	{
		return false;
	}

	public virtual bool getErrorRaw(int j, double err)
	{
		return false;
	}

	public virtual bool getErrorsRaw(double errs)
	{
		return false;
	}

	//public virtual bool getOutputRaw(int j, double out);
	//public virtual bool getOutputsRaw(double outs);

	public virtual bool getPidRaw(int j, Pid pid)
	{
		return false;
	}

	public virtual bool getPidsRaw(Pid pids)
	{
		return false;
	}

	public virtual bool getReferenceRaw(int j, double refVal) //refVal oiginally ref
	{
		return false;
	}

	public virtual bool getReferencesRaw(double refs)
	{
		return false;
	}

	public virtual bool getErrorLimitRaw(int j, double limit)
	{
		return false;
	}

	public virtual bool getErrorLimitsRaw(double limits)
	{
		return false;
	}

	public virtual bool resetPidRaw(int j)
	{
		return false;
	}

	public virtual bool disablePidRaw(int j)
	{
		return false;
	}

	public virtual bool enablePidRaw(int j)
	{
		return false;
	}

	public virtual bool setOffsetRaw(int j, double v)
	{
		return false;
	}

	//
	//
	/////////////////////////////// END PID INTERFACE
	
	/// POSITION CONTROL INTERFACE RAW
	public virtual bool getAxes(int ax)
	{
		return false;
	}

	public virtual bool setPositionModeRaw()
	{
		return false;
	}


	public virtual bool positionMoveRaw(int j, double refVal) //refVal was ref
	{
		return false;
	}

	public virtual bool positionMoveRaw( double refs)
	{
		return false;
	}

	public virtual bool relativeMoveRaw(int j, double delta)
	{
		return false;
	}

	public virtual bool relativeMoveRaw( double deltas)
	{
		return false;
	}

	public virtual bool checkMotionDoneRaw(bool flag)
	{
		return false;
	}

	public virtual bool checkMotionDoneRaw(int j, bool flag)
	{
		return false;
	}

	public virtual bool setRefSpeedRaw(int j, double sp)
	{
		return false;
	}

	public virtual bool setRefSpeedsRaw( double spds)
	{
		return false;
	}

	public virtual bool setRefAccelerationRaw(int j, double acc)
	{
		return false;
	}

	public virtual bool setRefAccelerationsRaw( double accs)
	{
		return false;
	}

	public virtual bool getRefSpeedRaw(int j, double refVal)
	{
		return false;
	}

	public virtual bool getRefSpeedsRaw(double spds)
	{
		return false;
	}

	public virtual bool getRefAccelerationRaw(int j, double acc)
	{
		return false;
	}

	public virtual bool getRefAccelerationsRaw(double accs)
	{
		return false;
	}

	public virtual bool stopRaw(int j)
	{
		return false;
	}

	public virtual bool stopRaw()
	{
		return false;
	}

	
	// Position Control2 Interface
	public virtual bool positionMoveRaw( int n_joint,  int joints,  double refs)
	{
		return false;
	}

	public virtual bool relativeMoveRaw( int n_joint,  int joints,  double deltas)
	{
		return false;
	}

	public virtual bool checkMotionDoneRaw( int n_joint,  int joints, bool flags)
	{
		return false;
	}

	public virtual bool setRefSpeedsRaw( int n_joint,  int joints,  double spds)
	{
		return false;
	}

	public virtual bool setRefAccelerationsRaw( int n_joint,  int joints,  double accs)
	{
		return false;
	}

	public virtual bool getRefSpeedsRaw( int n_joint,  int joints, double spds)
	{
		return false;
	}

	public virtual bool getRefAccelerationsRaw( int n_joint,  int joints, double accs)
	{
		return false;
	}

	public virtual bool stopRaw( int n_joint,  int joints)
	{
		return false;
	}

	public virtual bool getTargetPositionRaw( int joint, double refVal) //refVal was ref
	{
		return false;
	}

	public virtual bool getTargetPositionsRaw(double refs)
	{
		return false;
	}

	public virtual bool getTargetPositionsRaw( int n_joint,  int joints, double refs)
	{
		return false;
	}

	
	// Velocity Control
	public virtual bool setVelocityModeRaw()
	{
		return false;
	}

	public virtual bool velocityMoveRaw(int j, double sp)
	{
		return false;
	}

	public virtual bool velocityMoveRaw( double sp)
	{
		return false;
	}

	
	// Velocity Control2 Interface
	public virtual bool velocityMoveRaw( int n_joint,  int joints,  double spds)
	{
		return false;
	}

	public virtual bool setVelPidRaw(int j,  Pid pid)
	{
		return false;
	}

	public virtual bool setVelPidsRaw( Pid pids)
	{
		return false;
	}

	public virtual bool getVelPidRaw(int j, Pid pid)
	{
		return false;
	}

	public virtual bool getVelPidsRaw(Pid pids)
	{
		return false;
	}

	public virtual bool getRefVelocityRaw( int joint, double refVal)
	{
		return false;
	}

	public virtual bool getRefVelocitiesRaw(double refs)
	{
		return false;
	}

	public virtual bool getRefVelocitiesRaw( int n_joint,  int joints, double refs)
	{
		return false;
	}

	
	
	////////////////////// BEGIN Encoder Interface
	
	public virtual bool resetEncoderRaw(int j)
	{
		return false;
	}

	public virtual bool resetEncodersRaw()
	{
		return false;
	}

	public virtual bool setEncoderRaw(int j, double val)
	{
		return false;
	}

	public virtual bool setEncodersRaw( double vals)
	{
		return false;
	}

	public virtual bool getEncoderRaw(int j, double v)
	{
		return false;
	}

	public virtual bool getEncodersRaw(double encs)
	{
		return false;
	}

	public virtual bool getEncoderSpeedRaw(int j, double sp)
	{
		return false;
	}

	public virtual bool getEncoderSpeedsRaw(double spds)
	{
		return false;
	}

	public virtual bool getEncoderAccelerationRaw(int j, double spds)
	{
		return false;
	}

	public virtual bool getEncoderAccelerationsRaw(double accs)
	{
		return false;
	}

	
	///////////////////////// END Encoder Interface
	
	//////////////////////// BEGIN RemoteVariables Interface
	//
	public virtual bool getRemoteVariableRaw(string key, Bottle val)
	{
		return false;
	}

	public virtual bool setRemoteVariableRaw(string key, Bottle val)
	{
		return false;
	}

	public virtual bool getRemoteVariablesListRaw(Bottle listOfKeys)
	{
		return false;	
	}

	
	///////////////////////// END RemoteVariables Interface
	
	//////////////////////// BEGIN MotorEncoderInterface
	//
	public virtual bool getNumberOfMotorEncodersRaw(int num)
	{
		return false;
	}

	public virtual bool resetMotorEncoderRaw(int m)
	{
		return false;
	}

	public virtual bool resetMotorEncodersRaw()
	{
		return false;
	}

	public virtual bool setMotorEncoderRaw(int m, double val)
	{
		return false;
	}

	public virtual bool setMotorEncodersRaw(double vals)
	{
		return false;
	}

	public virtual bool getMotorEncoderRaw(int m, double v)
	{
		return false;	
	}

	public virtual bool setMotorEncoderCountsPerRevolutionRaw(int m, double cpr)
	{
		return false;
	}

	public virtual bool getMotorEncoderCountsPerRevolutionRaw(int m, double cpr)
	{
		return false;
	}

	public virtual bool getMotorEncodersRaw(double encs)
	{
		return false;	
	}

	public virtual bool getMotorEncoderSpeedRaw(int m, double sp)
	{
		return false;
	}

	public virtual bool getMotorEncoderSpeedsRaw(double spds)
	{
		return false;
	}

	public virtual bool getMotorEncoderAccelerationRaw(int m, double spds)
	{
		return false;
	}

	public virtual bool getMotorEncoderAccelerationsRaw(double accs)
	{
		return false;
	}

	public virtual bool getMotorEncodersTimedRaw(double encs, double stamps)
	{
		return false;
	}

	public virtual bool getMotorEncoderTimedRaw(int m, double encs, double stamp)
	{
		return false;
	}

	
	///////////////////////// END Encoder Interface
	////// Amplifier interface
	//
	public virtual bool enableAmpRaw(int j)
	{
		return false;
	}

	public virtual bool disableAmpRaw(int j)
	{
		return false;	
	}

	public virtual bool getCurrentsRaw(double vals)
	{
		return false;
	}

	public virtual bool getCurrentRaw(int j, double val)
	{
		return false;
	}

	public virtual bool setMaxCurrentRaw(int j, double val)
	{
		return false;
	}

	public virtual bool getMaxCurrentRaw(int j, double val)
	{
		return false;
	}

	public virtual bool getAmpStatusRaw(int st)
	{
		return false;
	}

	public virtual bool getAmpStatusRaw(int k, int st)
	{
		return false;
	}

	public virtual bool getPWMRaw(int j, double val)
	{
		return false;
	}

	public virtual bool getPWMLimitRaw(int j, double val)
	{
		return false;
	}

	public virtual bool setPWMLimitRaw(int j, double val)
	{
		return false;
	}

	public virtual bool getPowerSupplyVoltageRaw(int j, double val)
	{
		return false;
	}

	//
	/////////////// END AMPLIFIER INTERFACE
	
	////// calibration
	public virtual bool calibrateRaw(int j, double p)
	{
		return false;
	}

	public virtual bool doneRaw(int j)
	{
		return false;
	}

	
	/////// Limits
	public virtual bool setLimitsRaw(int axis, double min, double max)
	{
		return false;
	}

	public virtual bool getLimitsRaw(int axis, double min, double max)
	{
		return false;	
	}

	public virtual bool setVelLimitsRaw(int axis, double min, double max)
	{
		return false;
	}

	public virtual bool getVelLimitsRaw(int axis, double min, double max)
	{
		return false;
	}

	
	/////// Axis Info
	public virtual bool getAxisNameRaw(int axis, string name)
	{
		return false;
	}

	public virtual bool getJointTypeRaw(int axis, JointTypeEnum type)
	{
		return false;
	}

	
	/// IMotor
	public virtual bool getNumberOfMotorsRaw(int m)
	{
		return false;	
	}

	public virtual bool getTemperatureRaw(int m, double val)
	{
		return false;
	}

	public virtual bool getTemperaturesRaw(double vals)
	{
		return false;
	}

	public virtual bool getTemperatureLimitRaw(int m, double temp)
	{
		return false;
	}

	public virtual bool setTemperatureLimitRaw(int m, double temp)
	{
		return false;
	}

	public virtual bool getMotorOutputLimitRaw(int m, double limit)
	{
		return false;
	}

	public virtual bool setMotorOutputLimitRaw(int m, double limit)
	{
		return false;
	}

	public virtual bool getPeakCurrentRaw(int m, double val)
	{
		return false;
	}

	public virtual bool setPeakCurrentRaw(int m, double val)
	{
		return false;
	}

	public virtual bool getNominalCurrentRaw(int m, double val)
	{
		return false;
	}

	public virtual bool setNominalCurrentRaw(int m, double val)
	{
		return false;	
	}

	
	/////// Torque Control
	public virtual bool setTorqueModeRaw()
	{
		return false;
	}

	public virtual bool getTorqueRaw(int axis, double a)
	{
		return false;	
	}

	public virtual bool getTorquesRaw(double a)
	{
		return false;
	}

	public virtual bool getTorqueRangeRaw(int axis ,double a, double b)
	{
		return false;
	}

	public virtual bool getTorqueRangesRaw(double a,double b)
	{
		return false;
	}

	public virtual bool setRefTorquesRaw(double a)
	{
		return false;
	}

	public virtual bool setRefTorqueRaw(int axis, double a)
	{
		return false;
	}

	public virtual bool setRefTorquesRaw(int n_joint, int joints, double t)
	{
		return false;
	}

	public virtual bool getRefTorquesRaw(double a)
	{
		return false;
	}

	public virtual bool getRefTorqueRaw(int axis , double refVal) //refVAl was ref
	{
		return false;
	}

	public virtual bool getBemfParamRaw(int a, double b)
	{
		return false;
	}

	public virtual bool setBemfParamRaw(int a, double b)
	{
		return false;
	}

	public virtual bool setTorquePidRaw(int a, Pid pid)
	{
		return false;
	}

	public virtual bool setTorquePidsRaw(Pid pid)
	{
		return false;
	}

	public virtual bool setTorqueErrorLimitRaw(int a, double b)
	{
		return false;
	}

	public virtual bool setTorqueErrorLimitsRaw(double a)
	{
		return false;
	}

	public virtual bool getTorqueErrorRaw(int a, double b)
	{
		return false;
	}

	public virtual bool getTorqueErrorsRaw(double a)
	{
		return false;
	}

	public virtual bool getTorquePidOutputRaw(int a, double b)
	{
		return false;
	}

	public virtual bool getTorquePidOutputsRaw(double a)
	{
		return false;
	}

	public virtual bool getTorquePidRaw(int a, Pid pid)
	{
		return false;
	}

	public virtual bool getTorquePidsRaw(Pid pid)
	{
		return false;
	}

	public virtual bool getTorqueErrorLimitRaw(int a, double b)
	{
		return false;
	}

	public virtual bool getTorqueErrorLimitsRaw(double a)
	{
		return false;
	}

	public virtual bool resetTorquePidRaw(int a)
	{
		return false;	
	}

	public virtual bool disableTorquePidRaw(int a)
	{
		return false;
	}

	public virtual bool enableTorquePidRaw(int a)
	{
		return false;
	}

	public virtual bool setTorqueOffsetRaw(int a, double b)
	{
		return false;
	}

	public virtual bool getMotorTorqueParamsRaw(int j, MotorTorqueParameters motorParams) //moorParams was params
	{
		return false;
	}

	public virtual bool setMotorTorqueParamsRaw(int j, MotorTorqueParameters motorParams) //motorParams was params
	{
		return false;	
	}

	/////// Control Mode Interface
	public virtual bool setPositionModeRaw(int j)
	{
		return false;
	}

	public virtual bool setVelocityModeRaw(int j)
	{
		return false;
	}

	public virtual bool setTorqueModeRaw(int j)
	{
		return false;
	}

	public virtual bool setImpedancePositionModeRaw(int j)
	{
		return false;
	}

	public virtual bool setImpedanceVelocityModeRaw(int j)
	{
		return false;
	}

	public virtual bool setOpenLoopModeRaw(int j)
	{
		return false;
	}

	public virtual bool getControlModeRaw(int j, int mode)
	{
		return false;
	}

	public virtual bool getControlModesRaw(int modes)
	{
		return false;
	}

	
	/////// Control Mode2 Interface
	public virtual bool getControlModesRaw(int n_joint, int joints, int modes)
	{
		return false;
	}

	public virtual bool setControlModeRaw( int j,  int mode)
	{
		return false;
	}

	public virtual bool setControlModesRaw( int n_joint,  int joints, int modes)
	{
		return false;
	}

	public virtual bool setControlModesRaw(int modes)
	{
		return false;
	}

	
	
	/////// InteractionMode
//	public virtual bool getInteractionModeRaw(int axis, yarp mode)
//	{
//		return false;
//	}
//
//	public virtual bool getInteractionModesRaw(int n_joints, int joints, yarp::dev::InteractionModeEnum modes)
//	{
//		return false;
//	}
//
//	public virtual bool getInteractionModesRaw(yarp::dev::InteractionModeEnum modes)
//	{
//		return false;
//	}
//
//	public virtual bool setInteractionModeRaw(int axis, yarp::dev::InteractionModeEnum mode)
//	{
//		return false;	
//	}
//
//	public virtual bool setInteractionModesRaw(int n_joints, int joints, yarp::dev::InteractionModeEnum modes)
//	{
//		return false;
//	}
//
//	public virtual bool setInteractionModesRaw(yarp::dev::InteractionModeEnum modes)
//	{
//		return false;
//	}

	
	/////// PositionDirect
	public virtual bool setPositionDirectModeRaw()
	{
		return false;
	}

	public virtual bool setPositionRaw(int j, double refVal)
	{
		return false;
	}

	public virtual bool setPositionsRaw( int n_joint,  int joints, double refs)
	{
		return false;
	}

	public virtual bool setPositionsRaw( double refs)
	{
		return false;
	}

	public virtual bool getRefPositionRaw( int joint, double refVal)	
	{
		return false;	
	}

	public virtual bool getRefPositionsRaw(double refs)	
	{
		return false;
	}


	public virtual bool getRefPositionsRaw( int n_joint,  int joints, double refs)
	{
		return false;
	}
	
	//void run(void);
	
	/////// Joint steps
	public void jointStep()
	{
		
	}
}

