using UnityEngine;
using System.Collections;

public class JoySticKTesT : MonoBehaviour {
	public string currentButton="";
	// Use this for initialization
	void Start () {
	
	}
	void getButton()
	{
		if(Input.GetButton("joystick button 0"))
			currentButton = "joystick button 0";
		
		if(Input.GetButton("joystick button 1"))
			currentButton = "joystick button 1";
		
		if(Input.GetButton("joystick button 2"))
			currentButton = "joystick button 2";
		
		if(Input.GetButton("joystick button 3"))
			currentButton = "joystick button 3";
		
		if(Input.GetButton("joystick button 4"))
			currentButton = "joystick button 4";
		
		if(Input.GetButton("joystick button 5"))
			currentButton = "joystick button 5";
		
		if(Input.GetButton("joystick button 6"))
			currentButton = "joystick button 6";
		
		if(Input.GetButton("joystick button 7"))
			currentButton = "joystick button 7";
		
		if(Input.GetButton("joystick button 8"))
			currentButton = "joystick button 8";
		
		if(Input.GetButton("joystick button 9"))
			currentButton = "joystick button 9";
		
		if(Input.GetButton("joystick button 10"))
			currentButton = "joystick button 10";
		
		if(Input.GetButton("joystick button 11"))
			currentButton = "joystick button 11";
		
		if(Input.GetButton("joystick button 12"))
			currentButton = "joystick button 12";
		
		if(Input.GetButton("joystick button 13"))
			currentButton = "joystick button 13";
		
		if(Input.GetButton("joystick button 14"))
			currentButton = "joystick button 14";
		
		if(Input.GetButton("joystick button 15"))
			currentButton = "joystick button 15";
		
		if(Input.GetButton("joystick button 16"))
			currentButton = "joystick button 16";
		
		if(Input.GetButton("joystick button 17"))
			currentButton = "joystick button 17";
		
		if(Input.GetButton("joystick button 18"))
			currentButton = "joystick button 18";
		
		if(Input.GetButton("joystick button 19"))
			currentButton = "joystick button 19";	   
	}
	// Update is called once per frame
	void Update () {
		getButton ();
	}
}
