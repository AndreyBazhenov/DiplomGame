using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectStick : MonoBehaviour {

	public GameObject select1;
	public GameObject select2;
	public GameObject select3;
	public GameObject select4;
	int a=0;

	public Texture testTexture;

	public GameObject menu;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {


		if(Input.GetAxis ("Vertical2")==-1&& a!=3)
		{

			Debug.Log("pravo");

			select1.SetActive(false);
			select2.SetActive(true);
			select3.SetActive(false);
			select4.SetActive(false);
			a=3;
		

		}
		if(Input.GetAxis ("Vertical2")==1&& a!=2)
		{
		
			Debug.Log("levo");

			select1.SetActive(false);
			select2.SetActive(false);
			select3.SetActive(false);
			select4.SetActive(true);
			a=2;

		}
		if(Input.GetAxis ("Horizontal2")==-1&& a!=1)
		{
			
			select1.SetActive(false);
			select2.SetActive(false);
			select3.SetActive(true);
			select4.SetActive(false);
			Debug.Log("Nniz");
			a=1;
		}

		if(Input.GetAxis ("Horizontal2")==1&& a!=0)
		{

			Debug.Log("Vverh");
			select1.SetActive(true);
			select2.SetActive(false);
			select3.SetActive(false);
			select4.SetActive(false);
				a=0;
			}
		
	}
}
