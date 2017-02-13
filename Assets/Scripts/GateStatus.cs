using UnityEngine;
using System.Collections;

public class GateStatus : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.Manager.loweredGate)
            this.gameObject.SetActive(false);
    }
}
