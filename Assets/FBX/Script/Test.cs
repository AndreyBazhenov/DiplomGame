using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Test : MonoBehaviour {
	public RawImage[]a = new RawImage[6];
	public RawImage[]b = new RawImage[6];
	public RawImage[]c = new RawImage[6];
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter.AddObserver(this, "Damage");
	}
	


	// Update is called once per frame
	void Update () {
	
	}

	void Damage() {


	}
}
