using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OverworldTransition : MonoBehaviour
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
            if (SceneManager.GetActiveScene().name == "AmadiaTown")
                GameManager.Manager.OverworldPosition = new Vector3(-498f, 102.3f, 0f);
        }
            SceneManager.LoadScene("Overworld");
    }
}
