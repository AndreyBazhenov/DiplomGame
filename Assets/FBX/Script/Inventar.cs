using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Inventar : MonoBehaviour {
	public GameObject inventary; 
	public RawImage[]a = new RawImage[6];
	public RawImage[]b = new RawImage[6];
	public RawImage[]c = new RawImage[6];
	int d = 1;
	int d2 = 0;
	int i = 0;
	int j = 0;
	public Texture heathPotion;
	public Texture manaPotion;
	public Texture Empty;
	public Texture ArtifactMat;
	public Texture UseArtifactMat;
	public Texture Select;
	public Texture SelectMana;
	public Texture SelectHealth;

	private Texture lastMaterial;
	private Texture futureMaterial;

	int mana;
	int health;
	int k,l;
	int getAfirst;
	// Use this for initialization
	void Start () {
		Debug.Log ("Start");
		NotificationCenter.DefaultCenter.AddObserver(this, "getObjectHealth");
		NotificationCenter.DefaultCenter.AddObserver(this, "getObjectMana");
		NotificationCenter.DefaultCenter.AddObserver(this, "ClosedInv");
		NotificationCenter.DefaultCenter.AddObserver(this, "StartInv");
		inventary.SetActive(false);
	}
	void StartInv()
	{
		lastMaterial = a [0].texture;
		if(a[i].texture==Empty)
		{
			a[i].texture=Select;
		}
		if(a[i].texture==manaPotion)
		{
			a[i].texture=SelectMana;
		}
		if(a[i].texture==heathPotion)
		{
			a[i].texture=SelectHealth;
		}
		
	}
	void ClosedInv()
	{
		if(j==0)
		{
			if(a[i].texture==Select)
			{
				a[i].texture=Empty;
			}
			if(a[i].texture==SelectMana)
			{
				a[i].texture=manaPotion;				
			}
			if(a[i].texture==SelectHealth)
			{
				a[i].texture=heathPotion;				
			}

			
		}
		if(j==1)
		{
			if(b[i].texture==Select)
			{
				b[i].texture=Empty;
			}
			if(b[i].texture==SelectMana)
			{
				b[i].texture=manaPotion;
			}
			if(b[i].texture==SelectHealth)
			{
				b[i].texture=heathPotion;
			}
		
		}
		j = 0;
		i = 0;
		getAfirst = 1;
	}
	void getObjectHealth()
	{
		Debug.Log ("Yeaaa");
		health = 1;;
		for ( k=0;k<6;k++)
		{
			for ( l=0;l<2;l++)
			{
				Debug.Log(l);
				if(l==0&&a[k].texture==Empty&&health==1)
				{
					if(a[0].texture==Empty)
					{getAfirst=1;}
					a[k].texture=heathPotion;
					health=0;
					if(getAfirst==1)
					{
						lastMaterial=a[0].texture;
						getAfirst=0;
					}
				}
				if(l==1&&b[k].texture==Empty&&health==1)
				{
					b[k].texture=heathPotion;
					health=0;
				}
			}
		}
	}
	void getObjectMana()
	{
		Debug.Log ("YeaaaS");
		mana = 1;;
		for ( k=0;k<6;k++)
		{
			for ( l=0;l<2;l++)
			{
				Debug.Log(l);
				if(l==0&&a[k].texture==Empty&&mana==1)
				{
					if(a[0].texture==Empty)
					{getAfirst=1;}
					a[k].texture=manaPotion;
					mana=0;
					if(getAfirst==1)
					{
						lastMaterial=a[0].texture;
						getAfirst=0;
					}
				}
				if(l==1&&b[k].texture==Empty&&mana==1)
				{
					b[k].texture=manaPotion;
					mana=0;
				}
			}
		}
	}
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonUp ("Fire3"))
		{
			if(j==0)
			{
				if(a[i].texture==SelectMana)
					{
						a[i].texture=Empty;
					lastMaterial=a[i].texture;
					NotificationCenter.DefaultCenter.PostNotification(this, "UpMana");
					Debug.Log(i);
					}
				if(a[i].texture==SelectHealth)
					{
						a[i].texture=Empty;
					lastMaterial=a[i].texture;
					Debug.Log(i);
					NotificationCenter.DefaultCenter.PostNotification(this, "UpHealth");
					}
			
			}
			if(j==1)
			{
				
				Debug.Log("Reeeyaaa3!!");
					
				if(b[i].texture==SelectMana)
					{
						b[i].texture=Empty;
					lastMaterial=b[i].texture;
					
					NotificationCenter.DefaultCenter.PostNotification(this, "UpMana");
					Debug.Log(i);

					}
				if(b[i].texture==SelectHealth)
					{
						b[i].texture=Empty;
					lastMaterial=b[i].texture;
					NotificationCenter.DefaultCenter.PostNotification(this, "UpHealth");
					Debug.Log(i);

					}

			}
		}
		if (a [0].texture == null) {
			a[0].texture=Empty;	
		}


		if (Input.GetAxis ("Vertical2") > -0.5 && Input.GetAxis ("Vertical2") < 0.5) {
			d=15;		
		}
		if (Input.GetAxis ("Horizontal2") > -0.5 && Input.GetAxis ("Horizontal2") < 0.5) {
			d2=15;		
		}
		if(Input.GetAxis ("Vertical2")==-1&& d!=4)
		{
			if(j==0)
			{
				if(i<5)
				{
					Debug.Log("pravo");
					a[i].texture=lastMaterial;
					i=i+1;
					lastMaterial=a[i].texture;
					//a[i].texture=Select;
					if(a[i].texture==Empty)
					{
						a[i].texture=Select;
					}
					if(a[i].texture==manaPotion)
					{
						a[i].texture=SelectMana;
					}
					if(a[i].texture==heathPotion)
					{
						a[i].texture=SelectHealth;
					}
					d=4;
				}
			}
			if(j==1)
			{
				if(i<5)
				{
					Debug.Log("pravo");
					b[i].texture=lastMaterial;
					i=i+1;
					lastMaterial=b[i].texture;
					//b[i].texture=Select;
					if(b[i].texture==Empty)
					{
						b[i].texture=Select;
					}
					if(b[i].texture==manaPotion)
					{
						b[i].texture=SelectMana;
					}
					if(b[i].texture==heathPotion)
					{
						b[i].texture=SelectHealth;
					}
					d=4;
				}
			}
			if(j==2)
			{
				if(i<5)
				{
					Debug.Log("pravo");
					c[i].texture=lastMaterial;
					i=i+1;
					lastMaterial=c[i].texture;
					c[i].texture=Select;
					d=4;
				}
			}
		}
		if(Input.GetAxis ("Vertical2")==1&& d!=3)
		{
			if(j==0)
			{
				if(i>0)
					{
						Debug.Log("levo");
					a[i].texture=lastMaterial;
						i=i-1;
					lastMaterial=a[i].texture;
					//a[i].texture=Select;
					if(a[i].texture==Empty)
					{
						a[i].texture=Select;
					}
					if(a[i].texture==manaPotion)
					{
						a[i].texture=SelectMana;
					}
					if(a[i].texture==heathPotion)
					{
						a[i].texture=SelectHealth;
					}
						d=3;
					}
			}
			if(j==1)
			{
				if(i>0)
					{
						Debug.Log("levo");
					b[i].texture=lastMaterial;
						i=i-1;
					lastMaterial=b[i].texture;
					//b[i].texture=Select;
					if(b[i].texture==Empty)
					{
						b[i].texture=Select;
					}
					if(b[i].texture==manaPotion)
					{
						b[i].texture=SelectMana;
					}
					if(b[i].texture==heathPotion)
					{
						b[i].texture=SelectHealth;
					}
						d=3;
					}
				}
			if(j==2)
			{
				if(i>0)
					{
						Debug.Log("levo");
					c[i].texture=lastMaterial;
						i=i-1;
					lastMaterial=c[i].texture;
					c[i].texture=Select;
						d=3;
					}
			}


			
		}
		if(Input.GetAxis ("Horizontal2")==-1&& d2!=2)
		{

			if(j==1)
			{

				b[i].texture=lastMaterial;
					j=j+1;
				lastMaterial=c[i].texture;
				c[i].texture=Select;
					Debug.Log(j);
					d2=2;

			}
			if(j==0)
			{
				
				a[i].texture=lastMaterial;
				j=j+1;
				lastMaterial=b[i].texture;
				//b[i].texture=Select;
				if(b[i].texture==Empty)
				{
					b[i].texture=Select;
				}
				if(b[i].texture==manaPotion)
				{
					b[i].texture=SelectMana;
				}
				if(b[i].texture==heathPotion)
				{
					b[i].texture=SelectHealth;
				}
				Debug.Log(j);
				Debug.Log(j);
				d2=2;
				
			}

		}
		
		if(Input.GetAxis ("Horizontal2")==1&& d2!=1)
		{
			if(j==1)
			{
			
				b[i].texture=lastMaterial;
					j=j-1;
				lastMaterial=a[i].texture;
				//a[i].texture=Select;
				if(a[i].texture==Empty)
				{
					a[i].texture=Select;
				}
				if(a[i].texture==manaPotion)
				{
					a[i].texture=SelectMana;
				}
				if(a[i].texture==heathPotion)
				{
					a[i].texture=SelectHealth;
				}
					Debug.Log("Vverh");
					d2=1;
				}

			if(j==2)
			{

				c[i].texture=lastMaterial;
					j=j-1;
				lastMaterial=b[i].texture;
				//b[i].texture=Select;
				if(b[i].texture==Empty)
				{
					b[i].texture=Select;
				}
				if(b[i].texture==manaPotion)
				{
					b[i].texture=SelectMana;
				}
				if(b[i].texture==heathPotion)
				{
					b[i].texture=SelectHealth;
				}
					Debug.Log(j);
					d2=1;
				
			}
		}
	}
}
