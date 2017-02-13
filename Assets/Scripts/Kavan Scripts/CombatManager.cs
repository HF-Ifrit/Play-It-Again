using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages battle during battle scene
/// </summary>
public class CombatManager : MonoBehaviour {

    public PartyManager party1;
    public PartyManager party2;

    public List<Character> combatants;
    public List<GameObject> enemyButtons;
    public List<GameObject> healthBars;
    public static List<speedOrder> moveCounter;

    public int PCCounter = 0;

    public GameObject button;
    public GameObject canvas;

    public GameObject attackButton;
    public GameObject itemButton;
    public GameObject runButton;

    public GameObject winTextBox;

    public GameObject Pointer;
    public GameObject ptr;

    public GameObject CombatText;

    public class speedOrder
    {
        int speed;
        int position;

        public speedOrder(int speed, int position)
        {
            this.speed = speed;
            this.position = position;
        }

        public int getSpeed() { return speed; }
        public int getPosition() { return position; }

    }

	// Use this for initialization
	void Start () {


        //set pointer
        ptr = Instantiate(Pointer) as GameObject;


        //Initialize Party1 using main cast's stats
        for (int i = 0; i < party1.getParty().Count; i++)
        {
            party1.getParty()[i].char_name = GameManager.Manager.Party[i].Name;
            party1.getParty()[i].totalHealth = GameManager.Manager.Party[i].MaxHealth;
            party1.getParty()[i].currHealth = GameManager.Manager.Party[i].CurrentHealth;
            party1.getParty()[i].strength = GameManager.Manager.Party[i].Strength;
            party1.getParty()[i].defense = GameManager.Manager.Party[i].Defense;
            party1.getParty()[i].speed = GameManager.Manager.Party[i].Speed;
        }

        //Initialize battle combatants and respective buttons and healthbars
        combatants = new List<Character>();
        enemyButtons = new List<GameObject>();
        healthBars = new List<GameObject>();
        moveCounter = new List<speedOrder>();

        //Add listeners for methods to the combat buttons
        attackButton.GetComponent<Button>().onClick.AddListener(getTarget);
        itemButton.GetComponent<Button>().onClick.AddListener(getItems);
        runButton.GetComponent<Button>().onClick.AddListener(leaveCombat);

        
        setButtons();
        setHealthBars();
	}
    
    // Update is called once per frame
    //handle death of party, need to stop time
    void Update ()
    {
        //Set pointer's position based on which character's actions are being inputted
        ptr.transform.position = new Vector3(-528.2f, -183.1f - 2 * (PCCounter % party1.Length()), -5);

        //Perform general flow of combat
        if (PCCounter == party1.Length() )
        {
            getCombatants();
            //Debug.Log("after getcombatants");
            getEnemyInput();
            getMoveOrder();
            Debug.Log("after getMoveorder");
            executeRound(); 
            Debug.Log("after executeRound");
            setButtons();

            PCCounter = 0;
        }

        //Check if enemies have been defeated after end of combat round
        if (party2.partyDefeated())
        {
            StartCoroutine(YouWIN());
        }

	}

    //Get list of all characters in the battle
    void getCombatants()
    {
        combatants.Clear();

        for (int x = 0; x < party1.Length(); x++)
        {
            combatants.Add(party1.getCharacter(x));
        }
        for (int x = 0; x < party2.Length(); x++)
        {
            combatants.Add(party2.getCharacter(x));
        }
    }

    //Determine the order of actions based on each character's speed
    public void getMoveOrder()
    {
        moveCounter.Clear();
        moveCounter = new List<speedOrder>();
        Debug.Log("getMoveOrder");

        for (int x = 0; x < combatants.Count; x++)
        {
            Character temp = combatants[x];
            moveCounter.Add(new speedOrder(temp.speed, x));
        }

        moveCounter = moveCounter.OrderBy(p => p.getSpeed()).ToList();
        moveCounter.Reverse();
    }

    //Perform respective character's action according to the ation queue
    public void executeRound()
    {
        Debug.Log("Combat begins!");

        Text txt = CombatText.GetComponentInChildren<Text>();
        txt.text = "";

        ptr.SetActive(false);

        foreach (speedOrder speedorder in moveCounter)
        {
            Character turn = combatants[speedorder.getPosition()];
            Debug.Log(turn.char_name + "'s turn!");
            Debug.Log("speed order:" + speedorder.getPosition());
            txt.text += turn.char_name + " attacks " + turn.target.char_name + "\n";
            actionEnemy(turn, turn.actionQueue, turn.target);
        }

        ptr.SetActive(true);
    }

   //Determine which random character the enemy will attack
    public void getEnemyInput()
    {
        List<Character> enemies = party2.getParty();
        Debug.Log("getEnemyInput()");
        foreach (Character x in enemies)
        {
            x.actionQueue = 0;
            int rand = Random.Range(0, party1.Length());
            x.target = party1.getCharacter(rand);
            Debug.Log("Enemy targetting:" + party1.getCharacter(0).char_name);
        }
    }

    /// <summary>
    /// Set buttons for enemies, but set disabled
    /// </summary>
    public void setButtons()
    {
        enemyButtons.Clear();

        for (int x = 0; x < party2.Length(); x++)
        {
            GameObject newButton = Instantiate(button) as GameObject;
            Character temp = party2.getCharacter(x);

            newButton.transform.SetParent(canvas.transform, false);

            //set button based on character's position
            newButton.transform.Translate(temp.transform.localPosition.x, temp.transform.localPosition.y - 2, 0);

            newButton.GetComponent<Button>().onClick.AddListener( () => onEnemyClick(temp) );

            newButton.SetActive(false);
            enemyButtons.Add(newButton);

            temp.button = newButton;
        }
    }

    public void setHealthBars()
    {

        healthBars.Clear();

        //cycle through party 2
        for (int x = 0; x < party2.Length(); x++)
        {
            GameObject newButton = Instantiate(button) as GameObject;
            Character temp = party2.getCharacter(x);
            newButton.transform.SetParent(canvas.transform, false);


            newButton.SetActive(true);
            healthBars.Add(newButton);
            newButton.GetComponentInChildren<Text>().text = temp.char_name + ":" + temp.currHealth;
            temp.healthBar = newButton;


            //set button based on character's position
            newButton.transform.Translate(temp.transform.localPosition.x + 4, temp.transform.localPosition.y - 2, 0);
            newButton.GetComponentInChildren<Button>().interactable = false;

            //Change button color and size
            ColorBlock cb = newButton.GetComponent<Button>().colors;
            cb.disabledColor = Color.red;
            newButton.GetComponent<RectTransform>().sizeDelta = new Vector2(135, 30);
            newButton.GetComponent<Button>().colors = cb;

        }
    }

    /// <summary>
    /// Create UI Buttons for each enemy for players to select
    /// </summary>
    public void getTarget()
    {
        foreach (GameObject x in enemyButtons)
            x.SetActive(true);
    }

    /// <summary>
    /// Remove UI Buttons after selecting target
    /// </summary>
    public void removeTargetButtons()
    {
        foreach (GameObject x in enemyButtons)
        {
            x.SetActive(false);
        }
    }

    public void hideInputButtons()
    {
        attackButton.SetActive(false);
        itemButton.SetActive(false);
        runButton.SetActive(false);
    }

    public void revealInputButtons()
    {
        attackButton.SetActive(true);
        itemButton.SetActive(true);
        runButton.SetActive(true);
    }

    //Let party escape from battle using Run command
    public void leaveCombat()
    {
        Debug.Log("Run away!!!");
    }

    //Access party's item inventory
    public void getItems()
    {
        Debug.Log("Open items!");
    }


    public static void actionSelf(Character self, int moveIndex, int value)
    {

        switch (moveIndex)
        {
            //heal yourself (item or special move)
            case 0:
                self.changeHealth(value);
                self.healthBar.GetComponent<Text>().text = self.char_name + ": " + self.currHealth;
                break;

            default:
                Debug.Log("Invalid move index!!");
                break;
        }

    }


    public void actionEnemy(Character self, int moveIndex, Character target)
    {
        Animator selfAnim = new Animator();
        
        Debug.Log("actionEnemy");
        if (target == null) return;

        if (self.party.name.CompareTo("My Party") == 0)
        {
            selfAnim = self.gameObject.GetComponentInChildren<Animator>();
        }

        switch (moveIndex)
        {
            //basic autoattack
            case 0:
                if(selfAnim != null)
                {
                    StartCoroutine(AttackAnimation(selfAnim));
                }

                target.changeHealth(-1 * self.strength);
                //Debug.Log(target.currHealth);
                break;


            //special attacks

            default:
                Debug.Log("Invalid move index!!");
                break;
        }

        Debug.Log(target.char_name + "health:"+target.currHealth);
        
    }

    public static void actionAreaEffect(Character self, int moveIndex, PartyManager target)
    {

        //special move or item
        List<Character> enemies = target.getParty();

        switch (moveIndex)
        {

            //area of effect
            case 0:
                int value = self.strength * 4;

                for (int x = 0; x < enemies.Count; x++)
                {
                    enemies[x].changeHealth(-1 * value);
                }
                break;

            default:
                Debug.Log("Invalid move index!!");
                break;
        }

    }

    public void onEnemyClick(Character target)
    {
        Debug.Log("onEnemyClick");
        //sets target for PC
        party1.getCharacter(PCCounter).target = target;

        //remove buttons
        removeTargetButtons();

        //move to next PC
        PCCounter++;
    }

    /// <summary>
    /// Play character's attacking animatiom before moving onto next character's action    
    /// </summary>
    IEnumerator AttackAnimation(Animator anim)
    {
        
        anim.SetBool("attacking", true);
        yield return new WaitForSeconds(2f);
    }

    /// <summary>
    /// Start the sequence for ending battle when the player wins
    /// </summary>
    IEnumerator YouWIN()
    {
        //Debug.Log("Win!");
        if (SceneManager.GetActiveScene().name == "OzymanFight")
            GameManager.Manager.finishedOzyman = true;
        //removes enemy target buttons
        removeTargetButtons();

        //removes user input buttons 
        hideInputButtons();

        //feedback win condition for 5 seconds, then moves back to world
        winTextBox.SetActive(true);
        ptr.SetActive(false);
        yield return new WaitForSeconds(5f);
        
        //Updated party's health in the game manager
        for(int i = 0; i < party1.getParty().Count; i++)
            GameManager.Manager.Party[i].CurrentHealth = party1.getParty()[i].currHealth;
        
        switch(SceneManager.GetActiveScene().name)
        {
            case "BattleScene1":
                SceneManager.LoadScene("Overworld");
                break;
            case "BattleScene2":
                SceneManager.LoadScene("Overworld");
                break;
            case "BattleScene3":
                SceneManager.LoadScene("Overworld");
                break;
            case "BattleScene4":
                SceneManager.LoadScene("TacitCave");
                break;
            case "BattleScene5":
                SceneManager.LoadScene("TacitCave");
                break;
            case "OzymanFight":
                SceneManager.LoadScene("EndScene");
                break;
        }
    }

}
