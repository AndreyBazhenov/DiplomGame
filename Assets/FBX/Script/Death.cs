using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {
	public GameObject deer;
	public GameObject deerComp;
	public Vector3 pointTr;
	public ParticleSystem deadPart;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter.AddObserver(this, "DeathMonster");
	}
	void DeathMonster()
	{
		deerComp=Instantiate(deer ,new Vector3(0, 0, 0) , Quaternion.identity)as GameObject;

		Destroy(deerComp, 10);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
