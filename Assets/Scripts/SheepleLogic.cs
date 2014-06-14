using UnityEngine;
using System.Collections;

public class SheepleLogic : MonoBehaviour {

	private Parties affiliation = Parties.none;


	public void SetAffiliation(Players toTargetPlayer){
		
		Parties targetParty = PlayerControl.mapParties[ toTargetPlayer ];
		
		if (affiliation == targetParty) return;	//zack was here.
		else {

			//remove old
			if (affiliation != Parties.none){ //OR THIS???
				GameLogic.score [ (int)affiliation ]--;				
			}

			//sets new 
			affiliation = targetParty;
			//int playerNum = int.Parse ( transform.parent.GetComponent<PlayerLogic>().player.ToString().Substring(6) )` - 1; //zack eliminated this
			GameLogic.score [ (int)toTargetPlayer ]++; //zack was here
			
			transform.renderer.material.color = PlayerControl.mapColor[ toTargetPlayer ];
			
		}


		//if ( affiliation == Parties.none ) {
		//}
	}
	
	




}
