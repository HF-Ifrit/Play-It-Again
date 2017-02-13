using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    [SerializeField]
    
    public int level;
    public int totalHealth;
    public int currHealth;
    public int totalEnergy;
    public int currEnergy;
    public int defense;
    public int strength;
    public int speed;
	public Skill thisCharSkill;


    public GameObject[] equipInventory;
    public int xpTotal;
    public GameObject[] specialMoveList;
    public bool isConscious;

    public Character target;
    public PartyManager party;

    public int actionQueue;

    public string char_name;

    public GameObject button;

    public GameObject healthBar;

    public float x;
    public float y;
    


    // Use this for initialization
    void Start () {
        x = this.transform.position.x;
        y = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
	    healthBar.GetComponent<Button>().GetComponentInChildren<Text>().text = "Health: " 
            + this.currHealth.ToString() + "/" + this.totalHealth.ToString() ; 
	}

    /// <summary>
    /// Increases stats for character upon level up
    /// Stat increase not official
    /// </summary>
    public void levelUp()
    {
        totalHealth += 10;
        totalEnergy += 10;
        defense += 2;
        strength += 2;
        speed += 2;
    }
    

    public void changeHealth(int value)
    {
        currHealth += value;

        Debug.Log("change health");

        //jingle();


        if (currHealth <= 0)
        {
            //this.transform.Translate(new Vector2(3, 0));
            this.transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
            party.killCharacter(this);

            if (button != null) Destroy(button);
            if (healthBar != null) Destroy(healthBar);

            this.gameObject.SetActive(false);
        }
    }

    public IEnumerator jingle()
    {
        this.transform.Translate(new Vector2(3, 0));
        //sleep
        yield return new WaitForSeconds(1f);
        Debug.Log("jingle"); //not getting hit
        this.transform.Translate(new Vector2(-3, 0));
    }

 
}
