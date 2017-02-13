using UnityEngine;
using System.Collections.Generic;

public class PartyManager : MonoBehaviour {


    [SerializeField]
    //public Character[] party;
    public List<Character> party;
    public List<GameObject> sharedInventory;
    public List<GameObject> keyInventory;
    public long money;


    public bool Alive = true;


    public List<Character> getParty() { return party; }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}

    public Character getCharacter(int x) { return party[x]; }

    public int Length() { return party.Count; }

    public bool isAlive() {

        if (party.Count != 0) return true;
        else return false;


    } //may be better to do in CombatManager


    public void killCharacter(Character character)
    {
        //int index = party.FindIndex(a => a.Equals(character));
        party.Remove(character);
    }

    /// <summary>
    /// When all party members are defeated, delete game object
    /// </summary>
    public bool partyDefeated()
    {
        if (party.Count == 0) return true;
        else return false;
    }


}
