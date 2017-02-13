using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryDropDownManager : MonoBehaviour
{
    private Dropdown _invenDd;
    private Text _dropDownText;

    //Initialize components for the dropdown before adding any options
    void Awake()
    {
        _dropDownText = GetComponentInChildren<Text>();
        _invenDd = GetComponent<Dropdown>();
    }

    //After being hidden, when user opens inventory again the dropdown box will be updated with correct inventory items
    void OnEnable()
    {
        //clears previous options already in the dropdown
        _invenDd.ClearOptions();
        foreach (GameManager.Item i in GameManager.Manager.Inventory)
            _invenDd.options.Add(new Dropdown.OptionData() { text = i.Name + " x" + i.Quantity});

        _dropDownText.text = _invenDd.options[0].text;
    }

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
