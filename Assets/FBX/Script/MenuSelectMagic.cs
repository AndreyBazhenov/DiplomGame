using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuSelectMagic : MonoBehaviour {

	public Text[]Menu = new Text[5];
	public GameObject menu;
	public GameObject stick1;
	
	public GameObject stick2;
	public Texture[]Destuct = new Texture[4];
	public Texture[]Metamorphose = new Texture[4];
	public Texture[]Stasis = new Texture[4];
	public Texture[]Force = new Texture[4];
	public Texture[]Create = new Texture[4];

	public RawImage lastTexture;
	public Text description;

	public RawImage[]img = new RawImage[4];
	public RawImage ShowImg;

	public RawImage[]MagicImgLeft = new RawImage[4];
	public RawImage[]MagicImgRight = new RawImage[4];


	public Color color;

	public GameObject[] Select=new GameObject[4];
	int x;
	int xFlag = 0;
	int i=0;
	int j=0;
	int k=0;
	int l=0;
	int d1=12;
	int	d2=12;
	// Use this for initialization
	void Start () {
		Menu [0].color = Color.red;
		Select[0].SetActive (true);
		i = 0;

		NotificationCenter.DefaultCenter.AddObserver(this, "Flag1");
		NotificationCenter.DefaultCenter.AddObserver(this, "Flag2");
		menu.SetActive(false);
	}

	void Flag1 () {
		xFlag = 1;

		}
	void Flag2 () {
		xFlag = 2;

		}

	void StartMenu () {
		Menu [0].color = Color.red;
		Select[0].SetActive (true);
		i = 0;
		}
	void TextMethod () {
		if (img[j].texture==Destuct[0])
		{
			description.text="Огненый шар,служит для разрушения стен, применение его  на живых существах карается...";
		}
		if (img[j].texture==Destuct[1])
		{
			description.text="Магия в разработке))";
		}
		if (img[j].texture==Destuct[2])
		{
			description.text="Магия в разработке))";
		}
		if (img[j].texture==Destuct[3])
		{
			description.text="Магия в разработке))";
		}


		if (img[j].texture==Metamorphose[0])
		{
			description.text="Метаморфоз, позволит из останков дерева создать голема. Голем способен спасти животных от магии";
		}
		if (img[j].texture==Metamorphose[1])
		{
			description.text="Магия обратная метаморфозу, освобождает животных от магии))";
		}
		if (img[j].texture==Metamorphose[2])
		{
			description.text="Поднимает количество жизни в 2 раза больше максимума, но работает один раз...";
		}
		if (img[j].texture==Metamorphose[3])
		{
			description.text="Поднимает количество маны в 2 раза больше максимума, но работает один раз...";
		}

		if (img[j].texture==Stasis[0])
		{
			description.text="Шар стазиса останавливает врага на время, полезная в бою...";
		}
		if (img[j].texture==Stasis[1])
		{
			description.text="Магия стазиса действующая на всех вокруг себя, но лишь притормаживает...";
		}
		if (img[j].texture==Stasis[2])
		{
			description.text="Делает тебя невидимым, но очень быстро сьедает ману";
		}
		if (img[j].texture==Stasis[3])
		{
			description.text="Магия в разработке))";
		}

		if (img[j].texture==Force[0])
		{
			description.text="Повышает силу прыжка, в течении пяти прыжков сила будет выше";
		}
		if (img[j].texture==Force[1])
		{
			description.text="Для магии ускорения мана не нужна, но тем не менее мана тратится...";
		}
		if (img[j].texture==Force[2])
		{
			description.text="Магия в разработке))";
		}
		if (img[j].texture==Force[3])
		{
			description.text="Магия в разработке))";
		}

		if (img[j].texture==Create[0])
		{
			description.text="Создает остатки дерева для создания голема, ведь не всегда их можно найти не подалеку";
		}
		if (img[j].texture==Create[1])
		{
			description.text="Создает щит защищающий от магических атак, полезная вещь))";
		}
		if (img[j].texture==Create[2])
		{
			description.text="Магия в разработке))";
		}
		if (img[j].texture==Create[3])
		{
			description.text="Магия в разработке))";
		}
		ShowImg.texture = img [j].texture;
	}
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonUp ("Fire3"))
		{

			if (xFlag==1)
			{
				stick1.SetActive(true);
				lastTexture.texture = ShowImg.texture;
				NotificationCenter.DefaultCenter.PostNotification(this, "SelectMagicText1");
				stick1.SetActive(false);
				menu.SetActive(false);
				xFlag=0;
			}
			if (xFlag==2)
			{
				stick2.SetActive(true);
				lastTexture.texture = ShowImg.texture;
				NotificationCenter.DefaultCenter.PostNotification(this, "SelectMagicText2");
				stick2.SetActive(false);
				menu.SetActive(false);
				xFlag=0;
			}
		}
		if (Input.GetAxis ("Vertical2") > -0.5 && Input.GetAxis ("Vertical2") < 0.5) {
			d1=15;		
		}
		if (Input.GetAxis ("Horizontal2") > -0.5 && Input.GetAxis ("Horizontal2") < 0.5) {
			d2=15;		
		}

		if(Input.GetAxis ("Vertical2")==-1&& d1!=1)
		{
			Select[j].SetActive(false);
			j=0;
			Select[j].SetActive(true);
			if (i<=3)
			{
				Menu[i].color=Color.black;
					i++;
				Menu[i].color=Color.red;
				d1=1;
			}
			switch (i)
			{
			case  0:
				for(k=0;k<4;k++)
				{
					img[k].texture=Destuct[k];
				}
				break;
			case  1:
				for(k=0;k<4;k++)
				{
					img[k].texture=Metamorphose[k];
				}
				break;
			case  2:
				for(k=0;k<4;k++)
				{
					img[k].texture=Stasis[k];
				}
				break;
			case  3:
				for(k=0;k<4;k++)
				{
					img[k].texture=Force[k];
				}
				break;
			case  4:
				for(k=0;k<4;k++)
				{
					img[k].texture=Create[k];
				}
				break;
			}
			TextMethod();
		}
		if(Input.GetAxis ("Vertical2")==1&& d1!=1 )
		{
			Select[j].SetActive(false);
			j=0;
			Select[j].SetActive(true);
			if (i>=1)
			{
				Menu[i].color=Color.black;
				i--;
				Menu[i].color=Color.red;

				d1=1;
			}
			switch (i)
			{
			case  0:
				for(k=0;k<4;k++)
				{
					img[k].texture=Destuct[k];
				}
				break;
			case  1:
				for(k=0;k<4;k++)
				{
					img[k].texture=Metamorphose[k];
				}
				break;
			case  2:
				for(k=0;k<4;k++)
				{
					img[k].texture=Stasis[k];
				}
				break;
			case  3:
				for(k=0;k<4;k++)
				{
					img[k].texture=Force[k];
				}
				break;
			case  4:
				for(k=0;k<4;k++)
				{
					img[k].texture=Create[k];
				}
				break;
			}
			TextMethod();
		}
		if(Input.GetAxis ("Horizontal2")==-1&& d2!=1)
		{
			if (j<3)
			{
				Select[j].SetActive(false);
				j++;
				Select[j].SetActive(true);
			
				d2=1;
				TextMethod();
			}
		}
		
		if(Input.GetAxis ("Horizontal2")==1&& d2!=1)
		{
			if (j>0)
			{
				Select[j].SetActive(false);
				j--;
				Select[j].SetActive(true);

				d2=1;
				TextMethod();
			}
		}
	}
}
