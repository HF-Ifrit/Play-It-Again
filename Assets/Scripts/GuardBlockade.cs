using UnityEngine;
using System.Collections;

public class GuardBlockade : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Manager.talkedWithChief)
            Destroy(this.gameObject);
    }
    
}
