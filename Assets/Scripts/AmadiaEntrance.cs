using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AmadiaEntrance : MonoBehaviour
{

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
        if (col.gameObject.tag == "Player")
        {
            GameManager.Manager.OverworldPosition = col.transform.position;
            SceneManager.LoadScene("AmadiaTown");
        }
    }
}
