using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InitializeStatText : MonoBehaviour
{
    private Text[] _statTextBoxes;
    public int partyID;

	// Use this for initialization
	void Start ()
    {
        _statTextBoxes = gameObject.GetComponentsInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        _statTextBoxes[0].text = "Strength: " + GameManager.Manager.Party[partyID].Strength;
        _statTextBoxes[1].text = "Defense: " + GameManager.Manager.Party[partyID].Defense;
        _statTextBoxes[2].text = "Speed: " + GameManager.Manager.Party[partyID].Speed;
        _statTextBoxes[3].text = "Health: " + GameManager.Manager.Party[partyID].CurrentHealth + "/" + GameManager.Manager.Party[partyID].MaxHealth;
	}
}
