using UnityEngine;
using System.Collections;

public class MagicController : MonoBehaviour {
	int a;
	public int ArmFlag;
	public int ManaCol = 100;
	public GameObject Shield1;
	public GameObject StasisBall1;
	public GameObject DestructBall1;
	public GameObject MetaBall1;
	public GameObject MetaBall2;
	public GameObject BrevnoBall1;

	public GameObject BallPosL;
	public GameObject BallPosR;


	public GameObject MassStasisL;
	public GameObject MassStasisR;

	public GameObject InvMagic;


	public string Flag = "DestructBall";
	public string FlagR = "DestructBall";
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter.AddObserver(this, "BallDestructFlag");
		NotificationCenter.DefaultCenter.AddObserver(this, "BallStasisFlag");
		NotificationCenter.DefaultCenter.AddObserver(this, "StasisMassive");
		NotificationCenter.DefaultCenter.AddObserver(this, "StasisInvise");
		NotificationCenter.DefaultCenter.AddObserver(this, "BallMetaporphose1Flag");
		NotificationCenter.DefaultCenter.AddObserver(this, "BallMetaporphose2Flag");
		NotificationCenter.DefaultCenter.AddObserver(this, "MagicHp");
		NotificationCenter.DefaultCenter.AddObserver(this, "MagicMana");
		NotificationCenter.DefaultCenter.AddObserver(this, "CreateBrevno");


		NotificationCenter.DefaultCenter.AddObserver(this, "BallDestructFlagR");
		NotificationCenter.DefaultCenter.AddObserver(this, "BallStasisFlagR");
		NotificationCenter.DefaultCenter.AddObserver(this, "StasisMassiveR");
		NotificationCenter.DefaultCenter.AddObserver(this, "StasisInviseR");
		NotificationCenter.DefaultCenter.AddObserver(this, "BallMetaporphose1FlagR");
		NotificationCenter.DefaultCenter.AddObserver(this, "BallMetaporphose2FlagR");
		NotificationCenter.DefaultCenter.AddObserver(this, "MagicHpR");
		NotificationCenter.DefaultCenter.AddObserver(this, "MagicManaR");
		NotificationCenter.DefaultCenter.AddObserver(this, "CreateBrevnoR");


		NotificationCenter.DefaultCenter.AddObserver(this, "LeftArmActive");
		NotificationCenter.DefaultCenter.AddObserver(this, "RightArmActive");
		
		NotificationCenter.DefaultCenter.AddObserver(this, "ManaEmpty");
		NotificationCenter.DefaultCenter.AddObserver(this, "ManaNorm");
		NotificationCenter.DefaultCenter.AddObserver(this, "ManaDanger");
	}


	void ManaEmpty () {
		ManaCol = 0;
		MassiveStasisRightEnd ();
		MassiveStasisLeftEnd ();
		ShieldEnding ();
	}
	void ManaDanger() {
		ManaCol = 4;
	}
	void ManaNorm () {
		ManaCol = 100;
	}

	void LeftArmActive () {
		ArmFlag = 0;
	}

	void RightArmActive () {
		ArmFlag = 1;
	}






	void BallDestructFlag () {
		Flag = "DestructBall";
	}
	void BallStasisFlag () {
		Flag = "StasisBall";
	}
	void StasisMassive () {
		Flag = "StasisMass";
	}
	void StasisInvise () {
		Flag = "Invise";
	}
	void BallMetaporphose1Flag () {
		Flag = "MetaBall1";
	}
	void BallMetaporphose2Flag () {
		Flag = "MetaBall2";
	}
	void MagicHp () {
		Flag = "HP";
	}
	void MagicMana () {
		Flag = "Mana";
	}

	void CreateBrevno () {
		Flag = "Brevno";
	}





	void BallDestructFlagR () {
		FlagR = "DestructBall";
	}
	void BallStasisFlagR () {
		FlagR = "StasisBall";
	}
	void StasisMassiveR () {
		FlagR = "StasisMass";
	}
	void StasisInviseR () {
		FlagR = "Invise";
	}
	void BallMetaporphose1FlagR () {
		FlagR = "MetaBall1";
	}
	void BallMetaporphose2FlagR () {
		FlagR = "MetaBall2";
	}
	void MagicHpR () {
		FlagR = "HP";
	}
	void MagicManaR () {
		FlagR = "Mana";
	}
	
	void CreateBrevnoR () {
		FlagR = "Brevno";
	}


	void LeftBall () {

		if (ManaCol>5)
		{
		switch (Flag)
		{
		case "DestructBall":
				GameObject Ball1Linst = Instantiate (DestructBall1, BallPosL.transform.position, BallPosL.transform.rotation) as GameObject;
			break;
		case "StasisBall":
				GameObject Ball2Linst = Instantiate (StasisBall1, BallPosL.transform.position, BallPosL.transform.rotation) as GameObject;
			break;
		case "MetaBall1":
				GameObject Ball3Linst = Instantiate (MetaBall1, BallPosL.transform.position, BallPosL.transform.rotation) as GameObject;
			break;
		case "MetaBall2":
				GameObject Ball4Linst = Instantiate (MetaBall2, BallPosL.transform.position, BallPosL.transform.rotation) as GameObject;
			break;
		case "Brevno":
				GameObject Ball5Linst = Instantiate (BrevnoBall1, BallPosL.transform.position, BallPosL.transform.rotation) as GameObject;
			break;
		
			}
			NotificationCenter.DefaultCenter.PostNotification (this, "DamageMana1");}
	}
	void RightBall () {

		if (ManaCol > 5) {
						switch (FlagR) {
						case "DestructBall":
				GameObject Ball1Linst = Instantiate (DestructBall1, BallPosR.transform.position, BallPosR.transform.rotation) as GameObject;
								break;
						case "StasisBall":
				GameObject Ball2Linst = Instantiate (StasisBall1, BallPosR.transform.position, BallPosR.transform.rotation) as GameObject;
								break;
						case "MetaBall1":
				GameObject Ball3Linst = Instantiate (MetaBall1, BallPosR.transform.position, BallPosR.transform.rotation) as GameObject;
								break;
						case "MetaBall2":
				GameObject Ball4Linst = Instantiate (MetaBall2, BallPosR.transform.position, BallPosR.transform.rotation) as GameObject;
								break;
						case "Brevno":
				GameObject Ball5Linst = Instantiate (BrevnoBall1, BallPosR.transform.position, BallPosR.transform.rotation) as GameObject;
								break;
			
						}
			NotificationCenter.DefaultCenter.PostNotification (this, "DamageMana1");
				}
	}
	void ShieldBegining () {
		if (ManaCol > 5) {
			Shield1.SetActive (true);
				}
	}
	void ShieldEnding () {
		if (ManaCol < 5)
		Shield1.SetActive (false);

	}
	void MassiveStasisLeft () {
		if (ManaCol > 5) {
						MassStasisL.SetActive (true);
				}
	}
	void MassiveStasisRight () {
		if (ManaCol > 5) {
						MassStasisR.SetActive (true);
				}
	}
	void MassiveStasisLeftEnd () {
		if (ManaCol < 5)
		MassStasisL.SetActive (false);
	}
	void MassiveStasisRightEnd () {
		if (ManaCol < 5)
		MassStasisR.SetActive (false);
	}
	void Invise () {
		if (ManaCol > 5) {
		if (ArmFlag == 1) {
		switch (FlagR) {
		case "Invise":
		NotificationCenter.DefaultCenter.PostNotification (this, "InviseMaterial");
		NotificationCenter.DefaultCenter.PostNotification (this, "InviseEnebled");
		break;
		case "HP":
		NotificationCenter.DefaultCenter.PostNotification (this, "UpHealth");
		NotificationCenter.DefaultCenter.PostNotification (this, "DamageMana1");
		break;
		case "Mana":
		NotificationCenter.DefaultCenter.PostNotification (this, "UpMana");
		NotificationCenter.DefaultCenter.PostNotification (this, "DamageMana1");
		break;
		}
		}
				
		if (ArmFlag == 0) {
		switch (Flag) {
		case "Invise":
		NotificationCenter.DefaultCenter.PostNotification (this, "InviseMaterial");
		NotificationCenter.DefaultCenter.PostNotification (this, "InviseEnebled");
		break;
		case "HP":
		NotificationCenter.DefaultCenter.PostNotification (this, "UpHealth");
		NotificationCenter.DefaultCenter.PostNotification (this, "DamageMana1");
		break;
		case "Mana":
		NotificationCenter.DefaultCenter.PostNotification (this, "UpMana");
		NotificationCenter.DefaultCenter.PostNotification (this, "DamageMana1");
		break;
								}
						}
				}
	}

	void InviseEnd () {
	
	}
	// Update is called once per frame
	void Update () {
	
	}
}
