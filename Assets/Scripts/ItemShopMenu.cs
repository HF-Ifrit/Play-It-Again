using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemShopMenu : MonoBehaviour
{
    private Dictionary<string, int> _prices;
	// Use this for initialization
	void Start ()
    {
        _prices = new Dictionary<string, int>();
        _prices.Add("Potion", 20);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //Make transaction using name of item to be purchased
    public void Purchase(string itemName)
    {
        //Check if player has gold for the item to continue transaction; If not, reveal message saying otherwise
        int cost = GetPrices()[itemName];
        if (GameManager.Manager.Gold >= GetPrices()[itemName])
        {
            //Increment quantity of item if its in players inventory; 
            //otherwise add it to player's inventory
            if (GameManager.Manager.Inventory.Contains(new GameManager.Item(itemName, 0)))
            {  
                GameManager.Manager.Inventory.Find(x => x.Name.CompareTo(itemName) == 0).Quantity += 1;

            }
            else
            {
                GameManager.Manager.Inventory.Add(new GameManager.Item(itemName, 1));
                GameManager.Manager.Inventory.Sort();
            }

            //Subtract gold for purchase
            GameManager.Manager.Gold -= cost;
        }
    }

    Dictionary<string, int> GetPrices()
    {
        return _prices;
    }
}
