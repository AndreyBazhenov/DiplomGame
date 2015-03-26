using UnityEngine;
using System.Collections;

public class MagicAnim : MonoBehaviour {

	public ParticleSystem Attack1;
	public GameObject Shield1;
	private Vector3 tr1;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			if(!Attack1.isPlaying){
			animation.Play("Arm_Attack");
			}
			Attack1.Play();
		}

		if (Input.GetAxis ("Vertical")!=0 && Input.GetButtonDown ("Fire3")) {
			animation.Play("Arm_Loop_Run");
		}
		if (Input.GetButtonDown("Jump")){
			animation.Play("Arm_Begin_Jump");
			animation.Stop("Arm_Begin_Jump");
			animation.Play("Arm_End_Jump");

		}
		if (Input.GetButtonDown("Fire2")){
			animation.Play("Arm_Begin_shield");
			Shield1.SetActive(true);
		}
		if (Input.GetButtonUp ("Fire2")) {
			animation.Play("Arm_End_Shield");
			Shield1.SetActive(false);
		}
	}
}
