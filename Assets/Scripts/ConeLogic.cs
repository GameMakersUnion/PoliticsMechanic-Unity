using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConeLogic : MonoBehaviour {

	private Dictionary<Players, Color> mapColor = new Dictionary<Players, Color>(){
		{Players.player1,Color.green},
		{Players.player2,Color.red},
		{Players.player3,Color.yellow},
		{Players.player4,Color.blue}
	};

	void OnTriggerEnter2D(Collider2D other) {

		int player = int.Parse ( transform.parent.GetComponent<PlayerControl>().playerNum.ToString().Substring(6) ) - 1;
		//Debug.Log ( "player1".Substring(6) );   //this is like the above line, but much simpler



		//Debug.Log ( GameLogic.score [ player ] );

		if(other.tag == "Sheeple") {
			GameLogic.score [ player ]++;
			other.renderer.material.color = mapColor[ transform.parent.GetComponent<PlayerControl>().playerNum ];
			//other.SendMessage(
		}
	}

}
