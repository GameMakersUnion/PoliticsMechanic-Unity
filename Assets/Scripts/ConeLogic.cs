using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConeLogic : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {

		if(other.tag == "Sheeple") {

			Players player = transform.parent.GetComponent<PlayerControl>().player;
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
