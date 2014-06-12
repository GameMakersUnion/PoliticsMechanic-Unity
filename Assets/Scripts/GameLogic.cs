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

	}
	
	void OnGUI () {
		GUI.Box (new Rect(20,20,50,30),score[0].ToString());
		GUI.Box (new Rect(Screen.width - 50,20,50,30),score[1].ToString());
		GUI.Box (new Rect(20,Screen.height-20,50,30),score[2].ToString());
		GUI.Box (new Rect(Screen.width - 50, Screen.height-20,50,30),score[3].ToString());
	}

}

