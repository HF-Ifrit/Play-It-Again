using UnityEngine;
using System.Collections;
//Skill system scrapped for time being
public class Skill : MonoBehaviour {

	private string skillName;
	private int amount; //integer amount of healing/damage/buffs done
	private int type; //determines healing/damage/buff status; 0 = heal, 1 = damage, 2= buff/nerf
	private int cost; //energy cost

	void Start() {
	}

	void Update() {
	}

	private Skill(int charid) {
		switch (charid) 
		{
		case 0:  //MC
			skillName = "A Happy Song";
			amount = Random.Range (5, 10);
			type = 0;
			cost = 4;
			break;
		case 1: //Lilin
			skillName = "Witch's Lament";
			amount = Random.Range (7, 12);
			type = 1;
			cost = 6;
			break;
		case 2: //Ariana
			skillName = "Call To Arms";
			amount = Random.Range (5, 10);
			type = 2;
			cost = 5;
			break;
		case 3: //Ozyman
			skillName = "Hell's Lullaby";
			amount = 5;
			type = 2;
			cost = 8;
			break;
		case 4: //Ozyman pt 2
			skillName = "Requiem of the Hermit";
			amount = Random.Range (5, 9);
			type = 1;
			cost = 12;
			break;
		case 5: //Ozyman Ult
			skillName = "Dirge of Hades";
			amount = 15;
			type = 1;
			cost = 50;
			break;
		}
	}
}