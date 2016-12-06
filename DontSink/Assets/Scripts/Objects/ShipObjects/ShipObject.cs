using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ShipObject : MonoBehaviour
{
    //Fields
    private int baseHealth;
    private int baseSpeed;
    private int baseDamage;
    private MaxCurrentPair<int> health;
    private int currentSpeed;
    private int currentDamage;
    private double reloadMultiplier = 1;
    private HullObject hull;
    private List<ItemObject> items;
    private List<CrewObject> crew;
    private GameObject shipModel;
    private string prefabPath;

    private static System.Random rnd = new System.Random();
    public ShipObject() { }

    public ShipObject(int health, int speed, int damage, HullObject hull, List<ItemObject> items, List<CrewObject> crew,GameObject shipModel, string prefabPath)
    {
        this.baseHealth = health;
        this.health = new MaxCurrentPair<int>(health);
        this.baseSpeed = speed;
        this.currentSpeed = speed;
        this.currentDamage = speed;
        this.baseDamage = damage;
        this.currentDamage = damage;
        this.hull = hull;
        this.items = items;
        this.crew = crew;
        this.shipModel = shipModel;
        this.prefabPath = prefabPath;
    }

    //Accessors
    public int BaseHealth { get { return baseHealth; } set { baseHealth = value; } }
    public int BaseSpeed { get { return baseSpeed; } set { baseSpeed = value; } }
    public int BaseDamage { get { return baseDamage; } set { baseDamage = value; } }
    public int MaxHealth { get { return health.Max; } set { health.Max = value; } }
    public int CurrentHealth { get { return health.Current; } set { health.Current = value; } }
    public int CurrentSpeed { get { return currentSpeed; } set { currentSpeed = value; } }
    public int CurrentDamage { get { return currentDamage; } set { currentDamage = value; } }
    public double ReloadMultiplier { get { return reloadMultiplier; } set { reloadMultiplier = value; } }
    public HullObject Hull { get { return hull; } set { hull = value; } }
    public List<ItemObject> Items { get { return items; } set { items = value; } }
    public List<CrewObject> Crew { get { return crew; } set { crew = value; } }
    public GameObject ShipModel { get { return shipModel; } set { shipModel = value; } }
    public string getPrefabPath { get { return prefabPath; } set { prefabPath = value; } }

    public void TakeDamage(int damage)
    {
        //print("Take Damage");
        if (rnd.Next(1, 25) > currentSpeed)
        {

            if (hull != null)
            {
                damage -= hull.Damage_Reduction;
                hull.TakeDamage();
            }
            if (damage >= health.Current)
            {
                health.Current = 0;
                //print("rip Ship");
                DestroyShip();
            }
            else
            {
                health.Current -= damage;
                //print("Damage taken: " + damage);
            }
        }
    }
    private void DestroyShip()
    {
        // Show Distruction Animation
        // If it is the player ship show the game over screen
    }
    public void AddCrew(CrewObject crewMember)
    {
        currentSpeed *= (int)(crewMember).Speed_Buff;
        reloadMultiplier *= (int)(crewMember).Reload_Buff;
        if (crew == null)
            crew = new List<CrewObject>();
        crew.Add(crewMember);
    }
    public void RemoveCrew(CrewObject crewMember)
    {
        if (crew.Contains(crewMember))
        {
            currentSpeed /= (int)(crewMember).Speed_Buff;
            reloadMultiplier /= (int)(crewMember).Reload_Buff;
            crew.Remove(crewMember);
        }
        //else
        //    print("The ship does not contain this crew member.");
    }
    public void AddItem(ItemObject item)
    {
        if (item is SailObject)
            currentSpeed += ((SailObject)item).Speed;
        else if (item is HullObject)
        {
            hull = (HullObject)item;
            return;
        }
        if(items == null)
            items = new List<ItemObject>();
        items.Add(item);
    }
    public void RemoveItem(ItemObject item)
    {
        if (items == null)
            items = new List<ItemObject>();
        if (items.Contains(item))
        {
            if (item is SailObject)
                currentSpeed -= ((SailObject)item).Speed;
            items.Remove(item);
        }
        else if (item is HullObject)
        {
            hull = null;
        }
        //else
        //    print("The ship does not contain this item.");
    }
    public List<CannonObject> GetCannons()
    {
        List<CannonObject> cannons = new List<CannonObject> ();

        foreach(ItemObject item in items)
        {
            if (item is CannonObject)
                cannons.Add(item as CannonObject);
        }

        return cannons;
    }
}

internal class MaxCurrentPair<T>
{
    // Fields 
    private T max;
    private T current;

    public MaxCurrentPair(T val)
    {
        max = val;
        current = val;
    }

    // Accessors
    public T Max { get { return max; } set { max = value; } }
    public T Current { get { return current; } set { current = value; } }
}