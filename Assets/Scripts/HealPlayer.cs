using UnityEngine;
using System.Collections;

public class HealPlayer : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        foreach (GameManager.Character c in GameManager.Manager.Party)
            c.CurrentHealth = c.MaxHealth;
    }
}
