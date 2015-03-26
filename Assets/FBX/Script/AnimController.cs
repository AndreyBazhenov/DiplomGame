using UnityEngine;
using System.Collections;

public class AnimController : MonoBehaviour {
	public string LArm="Lball";
	public string RArm="Rball";
	int runFlagL = 0;
	int runFlagR = 0;
	public int FlagL = 0;
	public int FlagR = 0;
	
	public int ManaCol = 100;

	public GameObject Shield1;


	
	public GameObject MassStasisL;
	public GameObject MassStasisR;

	int JumpFlag=0;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter.AddObserver(this, "BallLeftAnim");
		NotificationCenter.DefaultCenter.AddObserver(this, "BallRightAnim");
		NotificationCenter.DefaultCenter.AddObserver(this, "MassLeftAnim");
		NotificationCenter.DefaultCenter.AddObserver(this, "MassRightAnim");
		NotificationCenter.DefaultCenter.AddObserver(this, "InviseAnim");
		NotificationCenter.DefaultCenter.AddObserver(this, "RunAnim");
		NotificationCenter.DefaultCenter.AddObserver(this, "JumpAnim");
		NotificationCenter.DefaultCenter.AddObserver(this, "InviseAnimL");
		NotificationCenter.DefaultCenter.AddObserver(this, "RunAnimL");
		NotificationCenter.DefaultCenter.AddObserver(this, "JumpAnimL");
		NotificationCenter.DefaultCenter.AddObserver(this, "ShieldL");
		NotificationCenter.DefaultCenter.AddObserver(this, "ShieldR");
		NotificationCenter.DefaultCenter.AddObserver(this, "ManaEmpty1");
		NotificationCenter.DefaultCenter.AddObserver(this, "ManaNorm1");
		NotificationCenter.DefaultCenter.AddObserver(this, "ManaDanger1");
	}
	
	
	void ManaEmpty1 () {
		ManaCol = 0;
	}
	void ManaDanger1() {
		ManaCol = 4;
	}
	void ManaNorm1 () {
		ManaCol = 100;
	}
	void BallLeftAnim () {
		LArm = "Lball";
	}
	void BallRightAnim () {
		RArm = "Rball";
	}
	void MassLeftAnim () {
		LArm = "LMass";
	}
	void MassRightAnim () {
		RArm = "RMass";
	}
	void InviseAnim () {
		RArm = "Invise";
	}
	void RunAnim () {
		RArm = "Running";
	}
	void JumpAnim () {
		RArm = "Jumping";
	}
	void InviseAnimL () {
		LArm = "Invise";
	}
	void RunAnimL () {
		LArm = "Running";
	}
	void JumpAnimL () {
		LArm = "Jumping";
	}
	void ShieldL () {
		LArm = "Shield";
	}
	void ShieldR () {
		RArm = "Shield";
	}

	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetAxis ("Vertical") == 0) 
		{
			if (LArm == "Running" || RArm == "Running") 
			{
				NotificationCenter.DefaultCenter.PostNotification (this, "InviseNotEnebled");
			}
		}
		if (Input.GetAxis ("Vertical")!=0 ) {
			if (runFlagL==1||runFlagR==1)
			{
					animation.Play("Magic_Run_Loop");
					NotificationCenter.DefaultCenter.PostNotification (this, "InviseEnebled");		
			}
		}

		if (Input.GetAxis ("MagicAttack1")>0&&FlagL==0 ) {
			NotificationCenter.DefaultCenter.PostNotification(this, "LeftArmActive");
			switch (LArm)
			{
			case "Lball":
				animation.Play("Magic_Attack_Left");
				break;
			case "LMass":
				animation.Play("Magic_Begin_MassStasis_Left");
				
				NotificationCenter.DefaultCenter.PostNotification (this, "InviseEnebled");
				break;
			case "Invise":
				animation.Play("Magic_Invisible");
				NotificationCenter.DefaultCenter.PostNotification (this, "InviseMaterial");
				NotificationCenter.DefaultCenter.PostNotification (this, "InviseEnebled");
				break;
			case "Running":
				animation.Play("Magic_Run_Begin");
				NotificationCenter.DefaultCenter.PostNotification(this, "FlagRunBegin");
				break;
			case "Jumping":
				if (ManaCol > 5) {
				NotificationCenter.DefaultCenter.PostNotification(this, "FlagJumpingBegin");
				JumpFlag=1;
				}
			else
			{
				NotificationCenter.DefaultCenter.PostNotification(this, "FlagJumpingEnd");
			}
				break;
			case "Shield":
				animation.Play("Magic_Shield_Begin");
				NotificationCenter.DefaultCenter.PostNotification (this, "InviseEnebled");
				break;
			}
			FlagL=1;
		}
		if (Input.GetAxis ("MagicAttack2")<0&&FlagR==0 ) {
			NotificationCenter.DefaultCenter.PostNotification(this, "RightArmActive");
			Debug.Log("BeginR");
			switch (RArm)
			{
			case "Rball":
				animation.Play("Magic_Attack_Right");
				break;
			case "RMass":
				animation.Play("Magic_Begin_MassStasis_Right");
				
				NotificationCenter.DefaultCenter.PostNotification (this, "InviseEnebled");
				break;
			case "Invise":
				animation.Play("Magic_Invisible");
				NotificationCenter.DefaultCenter.PostNotification (this, "InviseMaterial");
				NotificationCenter.DefaultCenter.PostNotification (this, "InviseEnebled");

				break;
			case "Running":
				animation.Play("Magic_Run_Begin");	
				if (ManaCol>0)
				{
				NotificationCenter.DefaultCenter.PostNotification(this, "FlagRunBegin");
					
					runFlagR=1;
				}
				else
				{
					NotificationCenter.DefaultCenter.PostNotification(this, "FlagRunEnd");
				}
				break;
			case "Jumping":
				NotificationCenter.DefaultCenter.PostNotification(this, "FlagJumpingBegin");
				JumpFlag=1;
				break;
			case "Shield":
				animation.Play("Magic_Shield_Begin");
				NotificationCenter.DefaultCenter.PostNotification (this, "InviseEnebled");				
				break;
			}
			FlagR=1;
		}

		if (Input.GetAxis ("MagicAttack1") == 0&&FlagL==1) {
			switch (LArm)
			{
			case "LMass":
				animation.Play("Magic_End_MassStasis_Left");
				NotificationCenter.DefaultCenter.PostNotification (this, "InviseNotEnebled");
				break;
				
			case "Running":
				animation.Play("Magic_Run_End");
				NotificationCenter.DefaultCenter.PostNotification(this, "FlagRunEnd");
				runFlagR=0;
				break;
			case "Jumping":
				NotificationCenter.DefaultCenter.PostNotification(this, "FlagJumpingEnd");
				JumpFlag=0;
				break;
			case "Shield":
				animation.Play("Magic_Shield_End");
				Shield1.SetActive (false);
				
				NotificationCenter.DefaultCenter.PostNotification (this, "InviseNotEnebled");
				break;
			case "Invise":
				NotificationCenter.DefaultCenter.PostNotification (this, "NormMaterial");
				
				NotificationCenter.DefaultCenter.PostNotification (this, "InviseNotEnebled");
				MassStasisL.SetActive (false);
				break;
			}
			FlagL=0;

			}
		if (Input.GetAxis ("MagicAttack2") == 0&&FlagR==1) {
			switch (RArm)
			{
				
			case "RMass":
				animation.Play("Magic_End_MassStasis_Right");
				NotificationCenter.DefaultCenter.PostNotification (this, "InviseNotEnebled");
				
				MassStasisR.SetActive (false);
				break;
				
			case "Running":
				animation.Play("Magic_Run_End");
				NotificationCenter.DefaultCenter.PostNotification(this, "FlagRunEnd");
				runFlagR=0;
				break;
			case "Jumping":
				NotificationCenter.DefaultCenter.PostNotification(this, "FlagJumpingEnd");
				JumpFlag=0;
				break;
			case "Shield":
				animation.Play("Magic_Shield_End");
				Shield1.SetActive (false);
				
				NotificationCenter.DefaultCenter.PostNotification (this, "InviseNotEnebled");
				break;
			case "Invise":
				NotificationCenter.DefaultCenter.PostNotification (this, "NormMaterial");
				NotificationCenter.DefaultCenter.PostNotification (this, "InviseNotEnebled");
				
				break;
			}
			FlagR=0;
		}
		if (Input.GetButtonDown("Jump")&&JumpFlag==1){

			if (ManaCol > 5) {
				animation.Play("Magic_Jump");
				NotificationCenter.DefaultCenter.PostNotification (this, "DamageMana1");
			}
			else
			{
				NotificationCenter.DefaultCenter.PostNotification(this, "FlagJumpingEnd");
			}
			
		}
	/*	if (Input.GetButtonDown("MagicAttack1")&&!Input.GetButtonDown("MagicAttack2")){
			Debug.Log(LArm);

		}
		if (Input.GetButtonDown("MagicAttack2")&&!Input.GetButtonDown("MagicAttack1")){
			Debug.Log(RArm);

		}
		if (Input.GetButtonUp("MagicAttack1")){
			Debug.Log(LArm);
			switch (LArm)
			{
			case "LMass":
				animation.Play("Magic_End_MassStasis_Left");
				break;
		
			case "Running":
				animation.Play("Magic_Run_End");
				runFlagR=0;
				break;
		
			}
		}
		if (Input.GetButtonUp("MagicAttack2")){
			Debug.Log(RArm);
			switch (RArm)
			{
			
			case "RMass":
				animation.Play("Magic_End_MassStasis_Right");
				break;
		
			case "Running":
				animation.Play("Magic_Run_End");
				runFlagR=0;
				break;
		
			}
		}*/
	}
}
