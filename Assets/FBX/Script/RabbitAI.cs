using UnityEngine;
using System.Collections;

public class RabbitAI : MonoBehaviour {
	//настраиваемое
	public Transform target;    // Цель
	public int moveSpeed;       // Скорость перемещения
	public int rotationSpeed;   // Скорость поворота
	public float maxDistance;      // Максимальное приближение к игроку
	private float curDistance; // Текущая дистанция
	public int ReactionDistance; // Дистанция на которой монстр реагирует
	private float PointDistance; // Дистанция до поинта
	public GameObject ObjPoint; // Объект поинта
	private Transform Point; // Трансформ поинта для возвращения
	
	private Transform myTransform;  // Временная переменная для хранения ссылки на свойство transform

	private int MasiveS;

	public bool lifeMonster = true;
	public int distanAttack;
	public int distanAttack1;
	public string a;
	public float Timer; //Время в секундах которое отсчитает таймер
	private float TimerDown; 
	public GameObject StasMat;
	int StasAct=0;
	public GameObject DeathPos, rab,MassStass,MassStass1;

	public int i = 1;

	
	public enum MonsterStat //перечисление всех состояний курсора
	{
		idle,
		walkPlayer,
		walkPoint,
		distAttack,
		attackPlayer,
		death

	}
	
	private MonsterStat _monsterStat;
	void OnTriggerEnter(Collider other) {
		if (other.collider.tag=="StasisBall")
		{
			a="StasisBall";
			StasActTrue();
			StasMat.SetActive(true);
		}
		if (other.collider.tag=="MetaBall")
		{
			a="MetaBall1";
		}
		if (other.collider.tag=="MetaBall2")
		{
			a="MetaBall2";
			Dead();
		}
		if (other.collider.tag=="DestroyBall")
		{
			a="DestroyBall";
		}
		if (other.collider.tag=="Ice")
		{
			moveSpeed=2;
			MasiveS=1;
		}
		
	}
	void OnTriggerExit(Collider other)
	{
		if (other.collider.tag == "Ice") {
			moveSpeed=4;
		}
	}
	void StasActTrue(){
		StasAct=1;
		}
	void StasActFalse(){
		StasAct=0;
	}

	
	void Awake(){
		//ссылка на transform чтоб сократить время обращения его в теле скрипта
		myTransform = transform;
		
	}
	void Dead ()
	{
		lifeMonster = false;
	}
	/*void OnParticleCollision(GameObject other)
	{
		lifeMonster=false;
	}*/
	// Use this for initialization
	void Start () {
		TimerDown = Timer;
		//ищем по тегу player
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		//поставить на него прицел
		target = go.transform;
		Point = ObjPoint.transform;		
		if(maxDistance == null) maxDistance = 3;
	}
	
	// Update is called once per frame
	void Update () {
	
		curDistance = Vector3.Distance(target.position, myTransform.position);
		PointDistance = Vector3.Distance(Point.position, myTransform.position);
		if (lifeMonster== false)
		{
			_monsterStat = MonsterStat.death;
		}
		//если позволяет дистанция двигаемся к цели(проверка на минимальную дистанцию)
		else if ((distanAttack<curDistance) && (distanAttack1>curDistance)&& (PointDistance < 1)&&StasAct==0)
		{	
			_monsterStat = MonsterStat.distAttack;
		}
		else if((curDistance >= maxDistance) && (curDistance <= ReactionDistance)&&StasAct==0){
			_monsterStat = MonsterStat.walkPlayer;

		}
		else if((curDistance > ReactionDistance) && (PointDistance > 1)&&StasAct==0)
		{
			_monsterStat = MonsterStat.walkPoint;
		}
		else if((distanAttack1 < curDistance) && (PointDistance < 1)||StasAct==1)
		{

			_monsterStat = MonsterStat.idle;
		}
		else if ((distanAttack<curDistance) && (distanAttack1>curDistance)&& (PointDistance < 1)&&StasAct==0)
		{
			_monsterStat = MonsterStat.distAttack;
		}
		else if (maxDistance >= curDistance&&StasAct==0)
		{
			_monsterStat = MonsterStat.attackPlayer;
		}
		
		switch(_monsterStat){
		case MonsterStat.idle:
			//чертим линию
			Debug.DrawLine(target.position,myTransform.position,Color.yellow);
			animation.CrossFade("Rabbit_Wait");
			break;			
		case MonsterStat.walkPlayer:
			//чертим линию
			Debug.DrawLine(target.position,myTransform.position,Color.red);
			
			// Разворачиваемся в сторону игрока
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,Quaternion.LookRotation(target.position - myTransform.position),rotationSpeed*Time.deltaTime);
			//двигаемся к цели
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
			animation.CrossFade("Rabbit_Run");
			break;			
		case MonsterStat.walkPoint:
			//чертим линию
			Debug.DrawLine(Point.position,myTransform.position,Color.green);
			Debug.DrawLine(target.position,myTransform.position,Color.yellow);			
			// Разворачиваемся в сторону игрока
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,Quaternion.LookRotation(Point.position - myTransform.position),rotationSpeed*Time.deltaTime);
			//двигаемся к цели
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;			
			animation.CrossFade("Rabbit_Run");
			break;
		case MonsterStat.attackPlayer:
			//чертим линию
			Debug.DrawLine(target.position,myTransform.position,Color.yellow);
			animation.CrossFade("Rabbit_Attack");
			NotificationCenter.DefaultCenter.PostNotification(this, "DamageHealth1");
			break;
		case MonsterStat.death:
			GameObject RabbitPrefab = Instantiate (rab, DeathPos.transform.position, DeathPos.transform.rotation) as GameObject;
			Destroy(gameObject);
			break;
		case MonsterStat.distAttack:
			// Разворачиваемся в сторону игрока
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,Quaternion.LookRotation(target.position - myTransform.position),rotationSpeed*Time.deltaTime);
			//двигаемся к цели
			myTransform.position += myTransform.forward * 0 * Time.deltaTime;
			animation.CrossFade("Rabbit_distAttack");
			break;
		}
		if(a=="StasisBall")
		{
			if(TimerDown > 0) TimerDown -= Time.deltaTime; //Если время которое нужно отсчитать еще осталось убавляем от него время обновления экрана (в одну секунду будет убавляться полная единица)
			if(TimerDown < 0) TimerDown = 0; //Если временная переменная ушла в отрицательное число (все возможно) то приравниваем ее к нулю
			if(TimerDown == 0)
			{
				TimerDown = Timer; //Благодаря этой строке таймер запустится заново после выполнения всех действий в скобках
				
				StasActFalse();//Сюда дописываем действия которые произойдут после конца отсчета
				a="123";
				StasMat.SetActive(false);
			}
		}
		if (!MassStass.active&&!MassStass1.active&&MasiveS==1) {
			moveSpeed=4;	
			MasiveS=0;
		}
	}
}