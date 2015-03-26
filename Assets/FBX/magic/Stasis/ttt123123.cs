using UnityEngine;
using System.Collections;

public class ttt123123 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnParticleCollision(GameObject other) {
		if(other.tag =="Stasis"){
			Debug.Log("Brrr its cold");
		}
		}
	// Update is called once per frame
	void Update () {
	
	}

}
