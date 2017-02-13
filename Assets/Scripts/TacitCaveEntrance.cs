using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TacitCaveEntrance : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameManager.Manager.OverworldPosition = col.gameObject.transform.position - new Vector3(0,10,0);
            SceneManager.LoadScene("TacitCave");
        }
    }
}
