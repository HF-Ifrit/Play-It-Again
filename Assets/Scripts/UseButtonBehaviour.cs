using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UseButtonBehaviour : MonoBehaviour
{
    public Dropdown invenList;
	
    // Use this for initialization
	void Start ()
    {
        GetComponent<Button>().onClick.AddListener(useItem);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void useItem()
    {
        GameManager.Manager.Inventory[invenList.value].use();
        Debug.Log(GameManager.Manager.Inventory[invenList.value].Name + "used!");
    }
}
