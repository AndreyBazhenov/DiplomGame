using UnityEngine;
using System.Collections;

public class MagicSelect : MonoBehaviour {
	public GameObject stick1;
	public GameObject stick2;
	public GameObject inventar_Menu;
	public GameObject arms;
	public GameObject stickMenu;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("MagicArm2")&&!stickMenu.active){
			stick1.SetActive(true);
		}
		if (Input.GetButtonUp ("MagicArm2")) {
			stick1.SetActive(false);
		}
		if (Input.GetButtonDown("MagicArm1")&&!stickMenu.active){
			stick2.SetActive(true);
		}
		if (Input.GetButtonUp ("MagicArm1")) {
			stick2.SetActive(false);
		}

		if (Input.GetButtonUp ("Fire2")&&!stickMenu.active) {
			inventar_Menu.SetActive(true);
			NotificationCenter.DefaultCenter.PostNotification(this, "StartInv");
			arms.SetActive(false);	
		}
		if(inventar_Menu.active)
		{
			if (Input.GetButtonUp ("Fire1")) {
				NotificationCenter.DefaultCenter.PostNotification(this, "ClosedInv");
				inventar_Menu.SetActive(false);	
				arms.SetActive(true);	
			}
		}

	}
}
