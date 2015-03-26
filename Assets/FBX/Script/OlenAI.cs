using UnityEngine;
using System.Collections;

public class OlenAI : MonoBehaviour {
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
	public GameObject AttackObj;


	public GameObject Ball1;
	
	public GameObject BallPos;



	private Transform myTransform;  // Временная переменная для хранения ссылки на свойство transform
	
	
	
	public enum MonsterStat //перечисление всех состояний курсора
	{
		idle,
		walkPlayer,
		walkPoint,
		attackPlayer
	}
	
	private MonsterStat _monsterStat;
	
	
	
	void Awake(){
		//ссылка на transform чтоб сократить время обращения его в теле скрипта
		myTransform = transform;
		
	}
	
	// Use this for initialization
	void Start () {
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
		
		//если позволяет дистанция двигаемся к цели(проверка на минимальную дистанцию)
		if((curDistance >= maxDistance) && (curDistance <= ReactionDistance)){
			_monsterStat = MonsterStat.walkPlayer;
		}
		else if((curDistance > ReactionDistance) && (PointDistance > 1))
		{
			_monsterStat = MonsterStat.walkPoint;
		}
		else if((curDistance > ReactionDistance) && (PointDistance < 1))
		{
			_monsterStat = MonsterStat.idle;
		}
		else
		{
			_monsterStat = MonsterStat.attackPlayer;
		}
		
		switch(_monsterStat){
		case MonsterStat.idle:
			//чертим линию
			Debug.DrawLine(target.position,myTransform.position,Color.yellow);
			animation.CrossFade("Olen_Wait");
			break;
			
		case MonsterStat.walkPlayer:
			//чертим линию
			Debug.DrawLine(target.position,myTransform.position,Color.red);
			
			// Разворачиваемся в сторону игрока
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,Quaternion.LookRotation(target.position - myTransform.position),rotationSpeed*Time.deltaTime);
			//двигаемся к цели
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
			AttackObj.SetActive(false);
			animation.CrossFade("Olen_Run");
			break;

		case MonsterStat.walkPoint:
			//чертим линию
			Debug.DrawLine(Point.position,myTransform.position,Color.green);
			Debug.DrawLine(target.position,myTransform.position,Color.yellow);
			
			// Разворачиваемся в сторону игрока
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,Quaternion.LookRotation(Point.position - myTransform.position),rotationSpeed*Time.deltaTime);
			//двигаемся к цели
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
			
			animation.CrossFade("Olen_Run");
			break;
		case MonsterStat.attackPlayer:
			//чертим линию
			Debug.DrawLine(target.position,myTransform.position,Color.yellow);

			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,Quaternion.LookRotation(target.position - myTransform.position),rotationSpeed*Time.deltaTime);
			//двигаемся к цели
			myTransform.position += myTransform.forward * 0 * Time.deltaTime;
			AttackObj.SetActive(true);
			animation.CrossFade("Olen_Attack");
			GameObject Ball1Linst = Instantiate (Ball1, BallPos.transform.position, BallPos.transform.rotation) as GameObject;
			break;
		}
	}
}