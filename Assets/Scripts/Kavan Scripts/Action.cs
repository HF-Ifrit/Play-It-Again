using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// Class conceptualize what action the character wants to take
/// Character passes in int value of what they want to do and GameObject of target
/// </summary>
public class Action : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void action(int value)
    {

    }

    public static void actionSelf(Character self, int moveIndex, int value)
    {

        switch (moveIndex)
        {
            //heal yourself (item or special move)
            case 0:
                self.changeHealth(value);
                break;

            default:
                Debug.Log("Invalid move index!!");
                break;
        }

    }

    public static void actionEnemy(Character self, int moveIndex, Character target)
    {

        switch (moveIndex)
        {
            //basic autoattack
            case 0:
                target.changeHealth(-1 * self.strength);
                break;


            //special attacks

            default:
                Debug.Log("Invalid move index!!");
                break;
        }
    }

    public static void actionAreaEffect(Character self, int moveIndex, PartyManager target)
    {

        //special move or item
        List<Character> enemies = target.getParty();

        switch (moveIndex)
        {

            //area of effect
            case 0:
                int value = self.strength * 4;

                for(int x = 0; x < enemies.Count; x++)
                {
                    enemies[x].changeHealth(-1 * value);
                }
                break;

            default:
                Debug.Log("Invalid move index!!");
                break;
        }

    }
}
