using UnityEngine;
using System.Collections;

public class iCubLogicalJoints : LogicalJoints
{
	private const int MAX_PART = 10;
	private const int MAX_AXIS = 40;
	private const int PART_ARM_LEFT = 1;
	private const int PART_ARM_RIGHT = 2;
	private const int PART_HEAD = 3;
	private const int PART_HEAD_RAW = 9;
	private const int PART_LEG_LEFT = 4;
	private const int PART_LEG_RIGHT = 5;
	private const int PART_TORSO = 6;
	private bool initialised = false;
	private OdeLogicalJoint[,] simControl;

	public iCubLogicalJoints(RobotConfig config)
	{
		simControl = new OdeLogicalJoint[MAX_PART,MAX_AXIS];
		int head = PART_HEAD;
		int rawHead = PART_HEAD_RAW;
		OdeLogicalJoint[] sub;
		if (config.actHead){      
			string headName = "head";
			// for (int i=0; i<4; i++) {
			getController(head,0).init(headName,"hinge",0,+1, config);
			getController(head,1).init(headName,"hinge",1,-1, config);
			getController(head,2).init(headName,"hinge",2,-1, config);
			getController(head,3).init(headName,"hinge",3,+1, config);
			// }
			// for the eyes, we need to map vergence/version onto
			// individual hinge joints
			getController(rawHead,4).init(headName,"hinge",4,-1, config);
			getController(rawHead,5).init(headName,"hinge",5,+1, config);
			
			getController(head,4).init(getController(rawHead,4),
			                           getController(rawHead,5),
			                           getController(head,5),
			                           +1);
			getController(head,5).init(getController(rawHead,4),
			                           getController(rawHead,5),
			                           getController(head,4),
			                           -1);
			////////////////////////////////////////////////////////////
			// Setting up the left and right arms
			
			for (int arm = PART_ARM_LEFT; arm <= PART_ARM_RIGHT; arm++) {
				string armName = (arm==PART_ARM_LEFT)?"leftarm":"rightarm";
				
				if (arm == PART_ARM_RIGHT && config.actRArm){
					getController(arm,0).init(armName,"hinge",0,-1, config);
					getController(arm,1).init(armName,"hinge",1,+1, config);
					getController(arm,2).init(armName,"hinge",2,-1, config);
					getController(arm,3).init(armName,"hinge",3,+1, config);
					getController(arm,4).init(armName,"hinge",4,-1, config);
					getController(arm,5).init(armName,"universalAngle1",5,-1, config);
					getController(arm,6).init(armName,"universalAngle2",5,-1, config);
				}
				
				if (arm == PART_ARM_LEFT && config.actLArm){
					getController(arm,0).init(armName,"hinge",0,-1, config);
					getController(arm,1).init(armName,"hinge",1,-1, config);
					getController(arm,2).init(armName,"hinge",2,+1, config);
					getController(arm,3).init(armName,"hinge",3,+1, config);
					getController(arm,4).init(armName,"hinge",4,+1, config);
					getController(arm,5).init(armName,"universalAngle1",5,+1, config);
					getController(arm,6).init(armName,"universalAngle2",5,-1, config);
					
				}
				if (arm == PART_ARM_RIGHT && config.actRHand){
					getController(arm,7).init(armName,"hinge",6,+1, config);
					sub = null;
					sub = getController(arm,7).nest(1);
					sub[0].init(armName,"hinge",8,-1, config);
					
					getController(arm,8).init(armName,"universalAngle1",22,-1, config);//thumb
					getController(arm,9).init(armName,"universalAngle2",22,-1, config);//thumb
					
					getController(arm,10).init(armName,"hinge",23,-1, config);
					sub = null;
					sub = getController(arm,10).nest(1);
					sub[0].init(armName,"hinge",24,-1, config);
					
					getController(arm,11).init(armName,"hinge",10,-1, config);//index proximal
					getController(arm,12).init(armName,"hinge",14,-1, config);
					sub = null;
					sub = getController(arm,12).nest(1);
					sub[0].init(armName,"hinge",18,-1, config);
					
					getController(arm,13).init(armName,"hinge",11,-1, config);//middle finger
					getController(arm,14).init(armName,"hinge",15,-1, config);
					sub = null;
					sub = getController(arm,14).nest(1);
					sub[0].init(armName,"hinge",19,-1, config);
					
					getController(arm,15).init(armName,"hinge",12,-1, config);//ring + pinky
					sub = null;
					sub = getController(arm,15).nest(2);
					sub[0].init(armName,"hinge",16,-1, config);
					sub[1].init(armName,"hinge",20,-1, config);
				}
				if (arm == PART_ARM_LEFT && config.actLHand ){
					getController(arm,7).init(armName,"hinge",6,+1, config);
					sub = null;
					sub = getController(arm,7).nest(1);
					sub[0].init(armName,"hinge",8,-1, config);
					
					/*getController(arm,8).init(armName,"hinge",22,+1);//thumb
              getController(arm,9).init(armName,"hinge",23,+1);
              getController(arm,10).init(armName,"hinge",24,+1);
            */
					getController(arm,8).init(armName,"universalAngle1",22,+1, config);//thumb
					getController(arm,9).init(armName,"universalAngle2",22,-1, config);//thumb
					
					getController(arm,10).init(armName,"hinge",23,+1, config);
					sub = null;
					sub = getController(arm,10).nest(1);
					sub[0].init(armName,"hinge",24,+1, config);
					
					getController(arm,11).init(armName,"hinge",10,+1, config);//index proximal
					getController(arm,12).init(armName,"hinge",14,+1, config);
					sub = null;
					sub = getController(arm,12).nest(1);
					sub[0].init(armName,"hinge",18,+1, config);
					
					getController(arm,13).init(armName,"hinge",11,+1, config);//middle finger
					getController(arm,14).init(armName,"hinge",15,+1, config);
					sub = null;
					sub = getController(arm,14).nest(1);
					sub[0].init(armName,"hinge",19,+1, config);
					
					getController(arm,15).init(armName,"hinge",12,+1, config);//ring + pinky
					sub = null;
					sub = getController(arm,15).nest(2);
					sub[0].init(armName,"hinge",16,+1, config);
					sub[1].init(armName,"hinge",20,+1, config);
				}
			}
			
			if (config.actLegs){
				for (int leg = PART_LEG_LEFT; leg <= PART_LEG_RIGHT; leg++) {
					string legName = (leg==PART_LEG_LEFT)?"leftleg":"rightleg";
					//       changed for demo look below for previous joint setup
					if (leg == PART_LEG_RIGHT){
						getController(leg,0).init(legName,"hinge",5,-1, config);
						getController(leg,1).init(legName,"hinge",4,-1, config);
						getController(leg,2).init(legName,"hinge",3,-1, config);
						getController(leg,3).init(legName,"hinge",2,-1, config);
						getController(leg,4).init(legName,"hinge",1,+1, config);
						getController(leg,5).init(legName,"hinge",0,-1, config);
					}else{
						getController(leg,0).init(legName,"hinge",5,-1, config);
						getController(leg,1).init(legName,"hinge",4,+1, config);
						getController(leg,2).init(legName,"hinge",3,+1, config);
						getController(leg,3).init(legName,"hinge",2,-1, config);
						getController(leg,4).init(legName,"hinge",1,+1, config);
						getController(leg,5).init(legName,"hinge",0,+1, config);
					}
				}
			}
			
			if (config.actTorso){
				int torso = PART_TORSO;
				string torsoName = "torso";
				getController(torso,0).init(torsoName,"hinge",2,+1, config);
				getController(torso,1).init(torsoName,"hinge",1,+1, config);
				getController(torso,2).init(torsoName,"hinge",0,-1, config);
			}
		}
		initialised = true;;

	}

	~iCubLogicalJoints()
	{
		this.simControl = null;
	}

	public override LogicalJoint control(int part, int axis)
	{
		return getController (part, axis);
	}

	public OdeLogicalJoint getController(int part, int axis)
	{
		if (simControl [part, axis] == null) {
			simControl[part,axis]=new OdeLogicalJoint();
		}

		return simControl[part,axis];
	}

	public virtual bool open(Searchable config)
	{
		if(initialised)
		{ return true;}
		else{ return false;}
	}

	public virtual bool close()
	{
		this.simControl = null;
		initialised = false;
		return true;
	}
}

