using UnityEngine;
using System.Collections;

/*
 * 	Stores and operates game-wide logic.
 */

public class GameLogic : MonoBehaviour {
	public GameObject Sheeple;
	private GameObject[] Sheeples;
	private const int SheepHerdSize = 100;
	private const int SheepPopSize = SheepHerdSize * 2;
	public static int[] score = new int[4];

	private GameObject[] PlayerGOs; 
	
	void Start () {

		//spawn the sheeples
		Sheeples = new GameObject[SheepPopSize];
		int range = 5;
		for	(int i=0; i < SheepHerdSize; i++){
			Sheeples[i] = (GameObject)Instantiate(Sheeple,new Vector3(Random.Range(-range,range), Random.Range(-range,range),0.0f),Quaternion.identity);
			//Sheeples[i] = (GameObject)Instantiate(Sheeple,new Vector3(3.0f + rand,3.0f + rand,0.0f),Quaternion.identity);
		}
		//Sheeples[0].transform.position = new Vector3(0.1f,0.1f,0.1f);
		//Sheeples[1].transform.position = new Vector3(0.1f,0.1f,0.1f);

		PlayerGOs = GameObject.FindGameObjectsWithTag("Player");

	}

	void Update(){

		//constantly check player positions..
		//find furthest apart X, Y
		//adjust camera accordingly
		Vector2 min = Vector2.zero; 
		Vector2 max = Vector2.zero;
		float biggest = 0;

		//ASK ZACK: what's best way to initalize this?
		if ( PlayerGOs != null ) {

			foreach ( GameObject PlayerGO in PlayerGOs ){
				if ( min == Vector2.zero ) min = new Vector2 (PlayerGO.transform.position.x, PlayerGO.transform.position.y );
				if ( max == Vector2.zero ) max = new Vector2 (PlayerGO.transform.position.x, PlayerGO.transform.position.y );

				if ( PlayerGO.transform.position.x < min.x ) min.x = PlayerGO.transform.position.x;
				if ( PlayerGO.transform.position.x > max.x ) max.x = PlayerGO.transform.position.x;
				if ( PlayerGO.transform.position.y < min.y ) min.y = PlayerGO.transform.position.y;
				if ( PlayerGO.transform.position.y > max.y ) max.y = PlayerGO.transform.position.y;
			}

			float x = max.x - min.x;
			float y = max.y - min.y;
			Vector2 delta = max - min;

			biggest = delta.x;
			if ( y > x ) biggest = delta.y;
			Camera.main.orthographicSize = biggest;
			Camera.main.transform.position = new Vector3 ( min.x + delta.x/2, min.y + delta.y/2, Camera.main.transform.position.z );
		}

	}
	
	void OnGUI () {
		GUI.Box (new Rect(20,20,50,30),score[0].ToString());
		GUI.Box (new Rect(Screen.width - 50,20,50,30),score[1].ToString());
		GUI.Box (new Rect(20,Screen.height-20,50,30),score[2].ToString());
		GUI.Box (new Rect(Screen.width - 50, Screen.height-20,50,30),score[3].ToString());
	}

}

