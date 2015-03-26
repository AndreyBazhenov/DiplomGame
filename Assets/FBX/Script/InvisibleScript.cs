using UnityEngine;
using System.Collections;

public class InvisibleScript : MonoBehaviour {
	public Material Invise;
	public Material Normal;


	public GameObject Arms;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter.AddObserver(this, "InviseMaterial");
		NotificationCenter.DefaultCenter.AddObserver(this, "NormMaterial");
	}

	void InviseMaterial()
	{
		Arms.renderer.material = Invise;
	}
	void NormMaterial()
	{
		Arms.renderer.material = Normal;
	}


	// Update is called once per frame
	void Update () {
	
	}
}
