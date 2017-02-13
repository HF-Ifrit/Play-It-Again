using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BattleGameManager : MonoBehaviour {

    [SerializeField]
    public static PartyManager MainParty;
    public static PartyManager enemyParty = null;

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void BeginCombat(PartyManager EnemyParty)
    {
        enemyParty = EnemyParty;
        SceneManager.LoadScene("BattleScene");

    }
}
