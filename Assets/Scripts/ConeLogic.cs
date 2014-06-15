using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConeLogic : MonoBehaviour {

	private Players player;

	private static Dictionary<Players,List<Collider2D>> collidersAll = new Dictionary<Players, List<Collider2D>>(){
		{Players.player1, new List<Collider2D>()},
		{Players.player2, new List<Collider2D>()},
		{Players.player3, new List<Collider2D>()},
		{Players.player4, new List<Collider2D>()}
	};

	void Start(){
		player = transform.parent.GetComponent<PlayerControl>().player;
	}

	void OnTriggerExit2D(Collider2D other){
		if ( collidersAll[player].Contains(other) ) collidersAll[player].Remove(other);
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if(other.tag == "Sheeple") {
			
			if ( !collidersAll[player].Contains(other) ) collidersAll[player].Add(other);

			/*
			//DISGUSTING LOGIC COMMENTED OUT!
			int overlapCount = 0;
			foreach (KeyValuePair<Players,List<Collider2D>> p in collidersAll) {
			
				foreach (Collider2D c in p.Value){
					//check all others... 
					foreach(KeyValuePair<Players,List<Collider2D>> p2 in collidersAll) {
						if ( p2.Key != p.Key && p2.Value.Contains(c)){
							overlapCount++;
							Debug.Log ( "Colli! " + overlapCount);
						}
					}
				}
			}
			*/
			other.gameObject.GetComponent<SheepleLogic>().SetAffiliation( player );
			

		}

//		int player = int.Parse ( transform.parent.GetComponent<PlayerControl>().player.ToString().Substring(6) ) - 1;
//		//Debug.Log ( "player1".Substring(6) );   //this is like the above line, but much simpler
//
//
//
//		//Debug.Log ( GameLogic.score [ player ] );
//
//		if(other.tag == "Sheeple") {
//			GameLogic.score [ player ]++;
//			other.renderer.material.color = PlayerControl.mapColor[ transform.parent.GetComponent<PlayerControl>().player ];
//			//other.SendMessage(
//		}
	}

}
