using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerGoldText : MonoBehaviour
{
    private Text _shopGoldText;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        _shopGoldText = GetComponent<Text>();
        _shopGoldText.text = GameManager.Manager.Gold + " Gold";
	}
}
