using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum Players{
	player1,
	player2,
	player3,
	player4
}

public enum Parties{
	GreenParty,
	Liberals,
	NDP,
	PCs,
	none
}

public class PlayerControl : MonoBehaviour {

	public Players player;
	
	private float distance = 3f;
	private float y;
	private float x;
	
	float anglePrev = 0f;
	float angleNext = 0f;
	float rotationDegRelative = 0f;

	public static Dictionary<Players, Color> mapColor = new Dictionary<Players, Color>(){
		{Players.player1, Color.green},
		{Players.player2, Color.red},
		{Players.player3, Color.yellow},
		{Players.player4, Color.blue}
	};
	
	public static Dictionary<Players, Parties> mapParties = new Dictionary<Players, Parties>(){
		{Players.player1, Parties.GreenParty},
		{Players.player2, Parties.Liberals},
		{Players.player3, Parties.NDP},
		{Players.player4, Parties.PCs},
	};

	private Dictionary<Players,KeyCode> mapJoystickKeyCodes = new Dictionary<Players,KeyCode>()
	{
		{Players.player1, KeyCode.Joystick1Button0},
		{Players.player2, KeyCode.Joystick2Button0},
		{Players.player3, KeyCode.Joystick3Button0},
		{Players.player4, KeyCode.Joystick4Button0}
	};


	/*
	//UNUSED REFERENCE DATA STRUCTURE
	private class Directions{
		KeyCode Up;
		KeyCode Down;
		KeyCode Left;
		KeyCode Right;
	}

	private Dictionary<Players, KeyCode> mapKeyboard = new Dictionary<Players, Directions>(){
		{Players.player1, new Directions(KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D) },
		{Players.player2, new Directions(KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow) },
		{Players.player3, new Directions(KeyCode.O, KeyCode.L, KeyCode.K, KeyCode.Colon) },
		{Players.player4, new Directions(KeyCode.Keypad8, KeyCode.Keypad2, KeyCode.Keypad4, KeyCode.Keypad6) }
	};
	*/

	
	// Use this for initialization
	void Start () {

	}


	// Update is called once per frame
	void Update () {

		//accepts overriding input of both keyboard and joysticks for same player. laziest implementation possible.
		//also note most keyboards cannot handle >2 players due to their limited key cache size

		x = Input.GetAxis(player.ToString() + "kx");
		y = Input.GetAxis(player.ToString() + "ky");
		Motion();


		x = Input.GetAxis(player.ToString() + "x");
		y = Input.GetAxis(player.ToString() + "y");
		Motion();


	}

	void Motion(){

		//movement
		if (  x!=0 || y!=0 ){
			transform.position = new Vector3 ( transform.position.x + x * distance * Time.deltaTime, transform.position.y+ y * -distance * Time.deltaTime, transform.position.z );
		}
		
		//rotation
		if (x!=0 && y !=0) angleNext = Mathf.Atan2(y,-x) * Mathf.Rad2Deg;
		transform.eulerAngles = new Vector3(transform.eulerAngles.x ,transform.eulerAngles.y, angleNext);

	}
}
