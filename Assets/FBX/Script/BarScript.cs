using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class BarScript : MonoBehaviour {
	public float hpMax=100f;
	public float manaMax=200f;
	public float hpCur;
	public float manaCur;
	public float procentHealth=100f;
	public float widthHealth=1f;
	public float procentMana=100f;
	public float widthMana=1f;

	public ParticleSystem hpPart;
	public ParticleSystem manaPart;

	public Image HealthImage;
	public Image ManaImage;

	public int a = 0;
	public float Timer; //Время в секундах которое отсчитает таймер
	private float TimerDown; //Изменяемая переменная для внутренних операций
	public float Timer1; //Время в секундах которое отсчитает таймер
	private float TimerDown1; //Изменяемая переменная для внутренних операций

	public Text hpText1;
	public Text manaText1;
	// Use this for initialization
	void Start () {
		hpCur = hpMax;
		manaCur = manaMax;
		NotificationCenter.DefaultCenter.AddObserver(this, "UpHealth");
		NotificationCenter.DefaultCenter.AddObserver(this, "UpMana");

		NotificationCenter.DefaultCenter.AddObserver(this, "DamageMana1");
		NotificationCenter.DefaultCenter.AddObserver(this, "DamageHealth1");
		NotificationCenter.DefaultCenter.AddObserver(this, "InviseEnebled");
		NotificationCenter.DefaultCenter.AddObserver(this, "InviseNotEnebled");

		TimerDown = Timer; //Задаем временной переменной значение которое нужно отсчитать
		TimerDown1 = Timer1;

		procentHealth=100;
		widthHealth=1;
		procentMana=100;
		widthMana=1;
	}
	void InviseEnebled()
	{
		a = 1;
	}
	void InviseNotEnebled()
	{
		a = 0;
	}
	void UpHealth()
	{
		hpCur =hpMax;
		procentHealth = hpCur / hpMax * 100;
		widthHealth = hpCur / hpMax;
		hpPart.Play ();				
	}
	void UpMana()
	{				
		manaCur=manaMax;
		procentMana = manaCur / manaMax * 100;
		widthMana = manaCur / manaMax;
		manaPart.Play ();				
		}
	void DamageHealth1()
	{
		hpCur-=1;
		procentHealth = hpCur / hpMax * 100;
		widthHealth = hpCur / hpMax;
	}
	void DamageMana1()
	{
		manaCur-=20;
		procentMana = manaCur / manaMax * 100;
		widthMana = manaCur / manaMax;		
	}
	// Update is called once per frame
	void Update () {
		if (a==1)
		{
			if(TimerDown1 > 0) TimerDown1 -= Time.deltaTime; //Если время которое нужно отсчитать еще осталось убавляем от него время обновления экрана (в одну секунду будет убавляться полная единица)
			if(TimerDown1 < 0) TimerDown1 = 0; //Если временная переменная ушла в отрицательное число (все возможно) то приравниваем ее к нулю
			if(TimerDown1 == 0)
			{
				TimerDown1 = Timer1; //Благодаря этой строке таймер запустится заново после выполнения всех действий в скобках
				if (procentMana<=100)
				{
					manaCur-=4;
					procentMana = manaCur / manaMax * 100;//Сюда дописываем действия которые произойдут после конца отсчета
					widthMana = manaCur / manaMax;
				}
			}
		}
		if(TimerDown > 0) TimerDown -= Time.deltaTime; //Если время которое нужно отсчитать еще осталось убавляем от него время обновления экрана (в одну секунду будет убавляться полная единица)
		if(TimerDown < 0) TimerDown = 0; //Если временная переменная ушла в отрицательное число (все возможно) то приравниваем ее к нулю
		if(TimerDown == 0)
		{
			TimerDown = Timer; //Благодаря этой строке таймер запустится заново после выполнения всех действий в скобках
			if (procentMana<100 && a!=1)
			{
				manaCur+=2;
				procentMana = manaCur / manaMax * 100;//Сюда дописываем действия которые произойдут после конца отсчета
				widthMana = manaCur / manaMax;
			}
		}
		if (procentMana<=1)
		{
			NotificationCenter.DefaultCenter.PostNotification (this, "ManaEmpty");
			NotificationCenter.DefaultCenter.PostNotification (this, "ManaEmpty1");
			
			NotificationCenter.DefaultCenter.PostNotification (this, "NormMaterial");
		}
		if (procentMana<0)
		{
			procentMana=0;
		}
		if (manaCur<0)
		{
			manaCur=0;
		}
		if (procentMana>0)
		{
			NotificationCenter.DefaultCenter.PostNotification (this, "ManaNorm");
			NotificationCenter.DefaultCenter.PostNotification (this, "ManaNorm1");
		}
		if (procentMana<10)
		{
			NotificationCenter.DefaultCenter.PostNotification (this, "ManaDanger");
			
			NotificationCenter.DefaultCenter.PostNotification (this, "ManaDanger1");
		}
		hpText1.text = "Жизней:" + procentHealth + "%";
		HealthImage.fillAmount = widthHealth;
		manaText1.text = "Мана:" + procentMana + "%";
		ManaImage.fillAmount = widthMana;
			}
}