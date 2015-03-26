using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class StickRight : MonoBehaviour {
	int a;
	public string flagText = "Test";
	public RawImage[] imgLeft=new RawImage[4];
	public RawImage ShowImg;
	public GameObject StickMenu;
	public GameObject Stick;
	public Texture [] MagicTexture = new Texture[11];
	int i = 0;
	int iFlag = 0;
	int flagG=0;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter.AddObserver(this, "SelectMagicText2");
		Stick.SetActive (false);
	}
	void SelectMagicText2 () {
		
		imgLeft[a].texture=ShowImg.texture;
		for (i=0;i<12;i++)
		{
			if (imgLeft[a].texture==MagicTexture[i])
			{
				iFlag=i;
				
			}
		}
		Resurch();
	}
	void Resurch () {

		switch (iFlag)
		{
		case 0:
			NotificationCenter.DefaultCenter.PostNotification(this, "BallRightAnim");
			NotificationCenter.DefaultCenter.PostNotification(this, "BallDestructFlagR");
			break;
		case 1:
			NotificationCenter.DefaultCenter.PostNotification(this, "BallRightAnim");
			NotificationCenter.DefaultCenter.PostNotification(this, "BallMetaporphose1FlagR");
			break;
		case 2:
			NotificationCenter.DefaultCenter.PostNotification(this, "BallRightAnim");
			
			NotificationCenter.DefaultCenter.PostNotification(this, "BallMetaporphose2FlagR");
			break;
		case 3:
			NotificationCenter.DefaultCenter.PostNotification(this, "InviseAnim");
			NotificationCenter.DefaultCenter.PostNotification(this, "MagicHpR");
			break;
		case 4:
			NotificationCenter.DefaultCenter.PostNotification(this, "InviseAnim");
			NotificationCenter.DefaultCenter.PostNotification(this, "MagicManaR");
			break;
		case 5:
			NotificationCenter.DefaultCenter.PostNotification(this, "BallRightAnim");
			NotificationCenter.DefaultCenter.PostNotification(this, "BallStasisFlagR");
			break;
		case 6:
			NotificationCenter.DefaultCenter.PostNotification(this, "MassRightAnim");
			NotificationCenter.DefaultCenter.PostNotification(this, "StasisMassiveR");
			break;
		case 7:
			NotificationCenter.DefaultCenter.PostNotification(this, "InviseAnim");
			NotificationCenter.DefaultCenter.PostNotification(this, "StasisInviseR");
			break;
		case 8:
			NotificationCenter.DefaultCenter.PostNotification(this, "JumpAnim");
			break;
		case 9:
			NotificationCenter.DefaultCenter.PostNotification(this, "RunAnim");
			break;
		case 10:
			NotificationCenter.DefaultCenter.PostNotification(this, "BallRightAnim");
				NotificationCenter.DefaultCenter.PostNotification(this, "CreateBrevnoR");
			break;
		case 11:
			NotificationCenter.DefaultCenter.PostNotification(this, "ShieldR");
			break;
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Fire3"))
		{
			StickMenu.SetActive(true);
			NotificationCenter.DefaultCenter.PostNotification(this, "Flag2");
		}
		if(Input.GetAxis ("Vertical2")==-1&& a!=3)
		{
			a=3;	
			for (i=0;i<12;i++)
			{
				if (imgLeft[a].texture==MagicTexture[i])
				{
					iFlag=i;
				}
			}
			Resurch();
		}
		if(Input.GetAxis ("Vertical2")==1&& a!=2)
		{
			a=2;
			for (i=0;i<12;i++)
			{
				if (imgLeft[a].texture==MagicTexture[i])
				{
					iFlag=i;

				}
			}
			Resurch();
		}
		if(Input.GetAxis ("Horizontal2")==-1&& a!=1)
		{
			a=1;
			for (i=0;i<12;i++)
			{
				if (imgLeft[a].texture==MagicTexture[i])
				{
					iFlag=i;
				}
			}
			Resurch();
		}
		
		if(Input.GetAxis ("Horizontal2")==1&& a!=0)
		{
			a=0;
			for (i=0;i<12;i++)
			{
				if (imgLeft[a].texture==MagicTexture[i])
				{
					iFlag=i;
				}
			}
			Resurch();
		}
	}
}
