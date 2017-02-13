using UnityEngine;
using System.Collections;

public class PositionManager : MonoBehaviour
{
    public GameObject player;
    public bool isDungeonCheckpoint;
	
    void Awake()
    {
        
    }
    
    // Use this for initialization
	void Start ()
    {
        if (isDungeonCheckpoint)
            transform.position = GameManager.Manager.DungeonPosition;
        else
            transform.position = GameManager.Manager.OverworldPosition;
        player.transform.position = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
