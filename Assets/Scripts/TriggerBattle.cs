using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TriggerBattle : MonoBehaviour
{
    public int battleID = 1;
    public bool isDungeonBattle;

	// Use this for initialization
	void Start ()
    {
	    if (GameManager.Manager.BattleChecklist.Contains(battleID))
                Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (isDungeonBattle)
                GameManager.Manager.DungeonPosition = col.transform.position;
            else
                GameManager.Manager.OverworldPosition = col.transform.position;
            SceneManager.LoadScene("BattleScene" + battleID);
            GameManager.Manager.BattleChecklist.Add(battleID);
        }
            
    }
}
