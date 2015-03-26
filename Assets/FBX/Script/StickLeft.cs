using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StickLeft : MonoBehaviour {
	int a;
	int i;
	int iFlag = 0;
	public string flagText = "Test";
	public RawImage[] imgLeft=new RawImage[4];
	public RawImage ShowImg;
	public GameObject StickMenu;
	public GameObject Stick;
	public Texture [] MagicTexture = new Texture[11];
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter.AddObserver(this, "SelectMagicText1");
		Stick.SetActive (false);
	}
	void SelectMagicText1 () {
		
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
			NotificationCenter.DefaultCenter.PostNotification(this, "BallLeftAnim");
			NotificationCenter.DefaultCenter.PostNotification(this, "BallDestructFlag");
			break;
		case 1:
			NotificationCenter.DefaultCenter.PostNotification(this, "BallLeftAnim");
			NotificationCenter.DefaultCenter.PostNotification(this, "BallMetaporphose1Flag");
			break;
		case 2:
			NotificationCenter.DefaultCenter.PostNotification(this, "BallLeftAnim");
			
			NotificationCenter.DefaultCenter.PostNotification(this, "BallMetaporphose2Flag");
			break;
		case 3:
			NotificationCenter.DefaultCenter.PostNotification(this, "InviseAnimL");			
			NotificationCenter.DefaultCenter.PostNotification(this, "MagicHp");
			break;
		case 4:
			NotificationCenter.DefaultCenter.PostNotification(this, "InviseAnimL");
			NotificationCenter.DefaultCenter.PostNotification(this, "MagicMana");
			break;
		case 5:
			NotificationCenter.DefaultCenter.PostNotification(this, "BallLeftAnim");
			NotificationCenter.DefaultCenter.PostNotification(this, "BallStasisFlag");
			break;
		case 6:
			NotificationCenter.DefaultCenter.PostNotification(this, "MassLeftAnim");
			NotificationCenter.DefaultCenter.PostNotification(this, "StasisMassive");
			break;
		case 7:
			NotificationCenter.DefaultCenter.PostNotification(this, "InviseAnimL");
			NotificationCenter.DefaultCenter.PostNotification(this, "StasisInvise");
			break;
		case 8:
			NotificationCenter.DefaultCenter.PostNotification(this, "JumpAnimL");
			break;
		case 9:
			NotificationCenter.DefaultCenter.PostNotification(this, "RunAnimL");
			break;
		case 10:
			NotificationCenter.DefaultCenter.PostNotification(this, "BallLeftAnim");
			NotificationCenter.DefaultCenter.PostNotification(this, "CreateBrevno");
			break;
		case 11:
			NotificationCenter.DefaultCenter.PostNotification(this, "ShieldL");

			break;
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Fire3"))
		{
			StickMenu.SetActive(true);
			NotificationCenter.DefaultCenter.PostNotification(this, "Flag1");
		}
		if(Input.GetAxis ("Vertical2")==-1&& a!=3)
		{
			a=3;	
			for (i=0;i<12;i++)
			{
				if (imgLeft[a].texture==MagicTexture[i])
				{
					iFlag=i;
					Resurch();
				}
			}
		}
		if(Input.GetAxis ("Vertical2")==1&& a!=2)
		{
			a=2;
			for (i=0;i<12;i++)
			{
				if (imgLeft[a].texture==MagicTexture[i])
				{
					iFlag=i;
					Resurch();
				}
			}
		}
		if(Input.GetAxis ("Horizontal2")==-1&& a!=1)
		{
			a=1;
			for (i=0;i<12;i++)
			{
				if (imgLeft[a].texture==MagicTexture[i])
				{
					iFlag=i;
					Resurch();
				}
			}
		}
		
		if(Input.GetAxis ("Horizontal2")==1&& a!=0)
		{
			a=0;
			for (i=0;i<12;i++)
			{
				if (imgLeft[a].texture==MagicTexture[i])
				{
					iFlag=i;
					Resurch();
				}
			}
		}
		
	}
}
