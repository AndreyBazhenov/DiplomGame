using UnityEngine;
using System.Collections;

public class GameAttack : MonoBehaviour {
	public GameObject Attack1Ball;
	public GameObject PositBall1;
	// Use this for initialization
	void Start () {
	}
	void Att()
	{
		GameObject Ball1Linst = Instantiate (Attack1Ball, PositBall1.transform.position, PositBall1.transform.rotation) as GameObject;
	}

	void Update () {

		}
}
