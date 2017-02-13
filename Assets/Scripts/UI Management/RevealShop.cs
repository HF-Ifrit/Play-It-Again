using UnityEngine;
using System.Collections;

public class RevealShop : MonoBehaviour
{
    public GameObject shopCanvas;
	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
            shopCanvas.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            shopCanvas.SetActive(false);
    }
}
