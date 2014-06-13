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

	public Players playerNum;
	
	private float distance = 3f;
	private float y;
	private float x;
	
	float anglePrev = 0f;
	float angleNext = 0f;
	float rotationDegRelative = 0f;

	private Dictionary<Players,KeyCode> mapKeyCodes = new Dictionary<Players,KeyCode>()
	{
		{Players.player1, KeyCode.Joystick1Button0},
		{Players.player2, KeyCode.Joystick2Button0},
		{Players.player3, KeyCode.Joystick3Button0},
		{Players.player4, KeyCode.Joystick4Button0}
	};
	
	
	// Use this for initialization
	void Start () {

	}


	// Update is called once per frame
	void Update () {

		//accepts overriding input of both keyboard and joysticks for same player. laziest implementation possible.
		//also note most keyboards cannot handle >2 players due to their limited key cache size

		x = Input.GetAxis(playerNum.ToString() + "kx");
		y = Input.GetAxis(playerNum.ToString() + "ky");
		Motion();


		x = Input.GetAxis(playerNum.ToString() + "x");
		y = Input.GetAxis(playerNum.ToString() + "y");
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
