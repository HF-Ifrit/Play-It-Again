using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{
    public GameObject moveLocation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Move player to moveLocation when entering collider of object
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.transform.position = moveLocation.transform.position;
        }
    }
}
