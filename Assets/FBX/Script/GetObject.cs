using UnityEngine;
using System.Collections;

public class GetObject : MonoBehaviour {
	int a;
	public GameObject inventary;
	// Use this for initialization
	void Start () {

	}
	void OnTriggerEnter(Collider other) {
		if (other.collider.tag=="HealthPotion")
		{
			a=1;
			Debug.Log("HealthCollider");
		}
		if (other.collider.tag=="ManaPotion")
		{
			a=2;
			Debug.Log("ManaCollider");
		}
		if (other.collider.tag=="Artefact")
		{
			
		}
	}

	// Update is called once per frame
	void Update () {
		if(a==1)
		{
			inventary.SetActive(true);
			NotificationCenter.DefaultCenter.PostNotification(this, "getObjectHealth");
			a+=5;
			NotificationCenter.DefaultCenter.PostNotification(this, "ClosedInv");
			inventary.SetActive(false);
		}
		if(a==2)
		{
			inventary.SetActive(true);
			NotificationCenter.DefaultCenter.PostNotification(this, "getObjectMana");
			a+=5;
			NotificationCenter.DefaultCenter.PostNotification(this, "ClosedInv");
			inventary.SetActive(false);
		}

	}
}
