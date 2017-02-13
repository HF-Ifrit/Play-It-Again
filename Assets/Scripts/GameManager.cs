using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private static GameManager manager = null;
    public static GameManager Manager
    {
        get { return manager; }
    }

    private Character[] _party;
    private List<Item> _inven;
    private int _gold;
    private Vector3 _oWorldPosition;
    private Vector3 _dungeonPosition;
    private List<int> _completedBattleIDs;
    public bool loweredGate = false;
    public bool talkedWithChief = false;
    public bool finishedOzyman = false;

    
    //Party getter-setter method
    public Character[] Party
    {
        get { return _party; }
    }

    //Inventory getter-setter method
    public List<Item> Inventory
    {
        get { return _inven; }
    }

    //Gold getter-setter method
    public int Gold
    {
        get { return _gold; }
        set { _gold = value; }
    }

    //Overworld position getter-setter method
    public Vector3 OverworldPosition
    {
        get { return _oWorldPosition; }
        set { _oWorldPosition = value; }
    }

    //Dungeon position getter-setter method
    public Vector3 DungeonPosition
    {
        get { return _dungeonPosition; }
        set { _dungeonPosition = value; }
    }

    //Completed Battles getter-setters
    public List<int> BattleChecklist
    {
        get { return _completedBattleIDs; }
    }

    //Character class for party members
    public class Character
    {
        private string _name;
        private int _cHealth;
        private int _mHealth;
        private int _str;
        private int _spd;
        private int _def;

        public Character(string name,int mHealth,int str,int spd,int def)
        {
            this._name = name;
            this._mHealth = mHealth;
            this._cHealth = _mHealth;
            this._str = str;
            this._spd = spd;
            this._def = def;
        }

        //Getter-setters for properties
        public string Name
        {
            get { return this._name; }
        }

        public int CurrentHealth
        {
            get { return this._cHealth; }
            set { this._cHealth = value; }
        }

        public int MaxHealth
        {
            get { return this._mHealth; }
            set { this._mHealth = value; }
        }

        public int Strength
        {
            get { return this._str; }
            set { this._str = value; }
        }

        public int Defense
        {
            get { return this._def; }
            set { this._def = value; }
        }

        public int Speed
        {
            get { return this._spd; }
            set { this._spd = value; }
        }

    }

    //Weapon class for weapon items in shop
    public class Weapon : Item
    {
        private int _strBonus;
        private int _spdBonus;
        private int _defBonus;

        public Weapon(string name, int strengthBonus, int speedBonus, int defenseBonus) : base(name,1)
        {
            this._strBonus = strengthBonus;
            this._spdBonus = speedBonus;
            this._defBonus = defenseBonus;
        }

        //Getter methods for properties
        public int StrengthBonus
        {
            get { return _strBonus; }
        }

        public int SpeedBonus
        {
            get { return _spdBonus; }
        }

        public int DefenseBonus
        {
            get { return _defBonus; }
        }
    }

    //Item class for general use items
    public class Item : IEquatable<Item>
    {
        private int _quant; //quantity of item
        private string _name;
        private int _restoreAmt;

        public Item(string name, int quantity)
        {
            this._name = name;
            this._quant = quantity;
            this._restoreAmt = 0;
        }

        public Item(string name, int quantity, int restoreAmount)
        {
            this._name = name;
            this._quant = quantity;
            this._restoreAmt = restoreAmount;
        }

        public int Quantity
        {
            get { return _quant; }
            set { _quant = value; }
        }

        public string Name
        {
            get { return _name; }
        }

        public int RestoreAmount
        {
            get { return _restoreAmt; }
        }

        public void use()
        {
            foreach(Character c in GameManager.Manager.Party)
            {
                c.CurrentHealth = Mathf.Clamp(c.CurrentHealth += _restoreAmt, c.CurrentHealth, c.MaxHealth);
            }
            this.Quantity -= 1;
            GameManager.Manager.inventoryCheck();
        }

        public bool Equals(Item otherItem)
        {
            if (this.Name.CompareTo(otherItem.Name) == 0)
                return true;
            else
                return false;
        }
    }


    void Awake()
    {
        GetThisGameManager();
    }

	// Use this for initialization
	void Start ()
    {
        //Initialize Battle Checklist
        _completedBattleIDs = new List<int>();

        //Initialize player's first position for Overworld
        _oWorldPosition = new Vector3(-498f, 102.3f, 0f);

        //Initialize player's first position for Tacit Cave
        _dungeonPosition = new Vector3(223.197f, -831.3373f, 0f);

        //Initialize party
        Character char1 = new Character("MC", 10, 5, 5, 5);
        Character char2 = new Character("Lilin", 15, 5, 6, 3);
        Character char3 = new Character("Ariana", 20, 10, 3, 6);
        _party = new Character[3];
        _party[0] = char1;
        _party[1] = char2;
        _party[2] = char3;

        //Initialize inventory and gold
        _inven = new List<Item>();
        Inventory.Add(new Item("Potion", 1,5));
        Gold = 2000;

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //Assigns this gameobject as the Game Manager as long as no other Game Manager exists
    void GetThisGameManager()
    {
        if (manager != null && manager != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            manager = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void inventoryCheck()
    {
        for(int i = 0; i < Inventory.Count; i++)
        {
            if (Inventory[i].Quantity == 0)
                Inventory.RemoveAt(i);
        }
        Inventory.Sort();
    }
}
