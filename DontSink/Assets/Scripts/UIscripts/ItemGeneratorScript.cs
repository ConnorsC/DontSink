using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ItemGeneratorScript : MonoBehaviour {

    string[] firstNames;
    string[] lastNames;
    string[] prePhrase;
    string[] postPhrase;
    // Use this for initialization
    void Start () {
	
	}

    //generates potentially more valuable items for later levels
    public List<ItemObject> GenerateItems( int level, System.Random rnd)
    {
        List<ItemObject> itemList = new List<ItemObject>();
        int listLength = 6 + level;

        firstNames = new string[] { "Bob", "Joe", "Steve", "Scurvy", "Wise man", "One-Eyed",
                                    "Dangerous", "Blind", "Peg Leg", "Carson", "Kevan", "Chris",
                                    "Benny", "Yeller" };
        lastNames = new string[] { "McGee", "McTeller", "Gumby", "Jacker", "Fanno", "Mc-Pete",
                                   "Jenkins", "Leeroy"};
        prePhrase = new string[] { "Super Cool", "Amazing", "Crappy", "Slimey", "Antique", "High Tech",
                                   "Makeshift", "Overpriced", "ARRR", "Worthless", "Best", "Better",
                                   "Buttered", "Metal", "Wooden", "Cobweb", "Carson's", "Kevan's", "Chris'"};
        postPhrase = new string[] { "Cannon", "Hull", "Sail" };
        //System.Random rnd = new System.Random();

        for (int i = 0; i < listLength; i++)
        {



            int itemType = rnd.Next(0, 5);

            switch (itemType)
            {
                case 0://crew object
                    {
                        int p = rnd.Next(0, 4);
                        double spd = 1 + (rnd.NextDouble() * level);
                        double rl = 1 + (rnd.NextDouble() * level);
                        string name = firstNames[rnd.Next(0, (firstNames.Length - 1))] + " " + lastNames[rnd.Next(0, (lastNames.Length - 1))];
                        int val = rnd.Next(5, 13);
                        Sprite icon;
                        if (p == 0)
                            icon = Resources.Load<Sprite>("Images/sailoricon");
                        else if (p == 1)
                            icon = Resources.Load<Sprite>("Images/sailoricon2");
                        else if (p == 2)
                            icon = Resources.Load<Sprite>("Images/pirateicon");
                        else
                            icon = Resources.Load<Sprite>("Images/pirateicon2");
                        CrewObject temp = makeCrew(spd, rl, val, icon, name);
                        itemList.Add(temp);
                    }
                    break;
                case 1://repairman object
                    {
                        int p = rnd.Next(0, 4);
                        double spd = 1 + (rnd.NextDouble() * level);
                        double rl = 1 + (rnd.NextDouble() * level);
                        int rr = rnd.Next(1, 5*level);
                        double maxrep = rnd.NextDouble() * 100;

                        string name = firstNames[rnd.Next(0, (firstNames.Length - 1))] + " " + lastNames[rnd.Next(0, (lastNames.Length - 1))];
                        int val = rnd.Next(5, 13);
                        Sprite icon;
                        if (p == 0)
                            icon = Resources.Load<Sprite>("Images/sailoricon");
                        else if (p == 1)
                            icon = Resources.Load<Sprite>("Images/sailoricon2");
                        else if (p == 2)
                            icon = Resources.Load<Sprite>("Images/pirateicon");
                        else
                            icon = Resources.Load<Sprite>("Images/pirateicon2");
                        RepairmanObject temp = makeRepairman(rr, maxrep, spd, rl, val, icon, name);
                        itemList.Add(temp);
                    }
                    break;
                case 2://cannon
                    {
                        int fr = rnd.Next(5, 14);
                        int dmg = rnd.Next(5, 10 + (2 * level));

                        string name = prePhrase[rnd.Next(0, (prePhrase.Length - 1))] + " " + postPhrase[0];
                        int val = rnd.Next(5, 13);
                        Sprite icon = Resources.Load<Sprite>("Images/cannon");
                        
                        CannonObject temp = makeCannon(fr, dmg, val, icon, name);
                        itemList.Add(temp);
                    }
                    break;
                case 3://hull
                    {
                        int dr = rnd.Next(1, 2*level);
                        int hlth = rnd.Next(5, 5 + ( 5*level));

                        string name = prePhrase[rnd.Next(0, (prePhrase.Length - 1))] + " " + postPhrase[1];
                        int val = rnd.Next(5, 15);
                        Sprite icon = Resources.Load<Sprite>("Images/cannon");
                        if (dr <= 2)
                            icon = Resources.Load<Sprite>("Images/hullicon");
                        else if (dr <= 4)
                            icon = Resources.Load<Sprite>("Images/reinforcedhullicon");
                        else
                            icon = Resources.Load<Sprite>("Images/superreinforcedhullicon");

                        HullObject temp = makeHull(dr, hlth, val, icon, name);
                        itemList.Add(temp);
                    }
                    break;
                case 4://sail
                    {
                        int speed = rnd.Next(1, 5*level);

                        string name = prePhrase[rnd.Next(0, (prePhrase.Length - 1))] + " " + postPhrase[2];
                        int val = rnd.Next(5, 5 + (5*level));
                        Sprite icon = Resources.Load<Sprite>("Images/sailboaticon100");

                        SailObject temp = makeSail(speed, val, icon, name);
                        itemList.Add(temp);
                    }
                    break;
                default:
                    break;
            }

        }

        return itemList;
    }

    public CrewObject makeCrew(double speedbuff, double reloadbuff, int val, Sprite icon, string name)
    {
        CrewObject temp = new CrewObject();
        temp.Speed_Buff = speedbuff;
        temp.Reload_Buff = reloadbuff;
        temp.Icon = icon;
        temp.Name = name;
        temp.Value = val;
        return temp;
    }

    public RepairmanObject makeRepairman(int rr, double maxre, double speedbuff, double reloadbuff, int val, Sprite icon, string name)
    {
        RepairmanObject temp = new RepairmanObject();
        temp.Speed_Buff = speedbuff;
        temp.Reload_Buff = reloadbuff;
        temp.Repair_Rate = rr;
        temp.Max_Repair = maxre;
        temp.Icon = icon;
        temp.Name = name;
        temp.Value = val;
        return temp;
    }

    public CannonObject makeCannon(int fr, int dmg, int val, Sprite icon, string name)
    {
        CannonObject temp = new CannonObject();
        temp.Fire_Rate = fr;
        temp.Damage = dmg;
        temp.Icon = icon;
        temp.Name = name;
        temp.Value = val;
        return temp;
    }

    public HullObject makeHull(int dr, int hp, int val, Sprite icon, string name)
    {
        HullObject temp = new HullObject(dr, hp);
        temp.Icon = icon;
        temp.Name = name;
        temp.Value = val;

        return temp;
    }

    public SailObject makeSail(int speed, int val, Sprite icon, string name)
    {
        SailObject temp = new SailObject(icon, name, val, speed);

        return temp;
    }


}
