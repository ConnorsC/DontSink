using UnityEngine;
using System.Collections;

public class EnemyShipObject : ShipObject
{
    //Fields 
    private ItemObject boon;
    private int difficulty;
    private string shipModel;
    //tmp
    static System.Collections.Generic.List<CrewObject> crew;
    static GameObject something;
    static string prefabPath = "Objects/Ships/Galleon";

    const int baseVal = 7;


    //Accessors
    public ItemObject Boon { get { return boon; } set { boon = value; } }
    public int Difficulty { get { return difficulty; } set { difficulty = value; } }
    new public string ShipModel { get { return shipModel; } set { shipModel = value; } }

    public EnemyShipObject() { }
    public EnemyShipObject(ItemObject boon, int difficulty) : base(InitHealth(difficulty), InitSpeed(difficulty), InitDamage(difficulty), null, CreateCannons(), crew, something, prefabPath)
    {
        this.boon = boon;
        this.difficulty = difficulty;
    }
    private static int InitHealth(int difficulty)
    {
        return (baseVal + difficulty) * 10;
    }
    private static int InitSpeed(int difficulty)
    {
        return (baseVal + difficulty);
    }
    private static int InitDamage(int difficulty)
    {
        return (baseVal + difficulty);
    }
    private static System.Collections.Generic.List<ItemObject> CreateCannons()
    {
        System.Collections.Generic.List<ItemObject> items = new System.Collections.Generic.List<ItemObject>();
        ItemGeneratorScript gen = new ItemGeneratorScript();
        items.Add(gen.makeCannon(6,0,5,Resources.Load<Sprite>("Images/cannon"),"Basic Cannon"));
        items.Add(gen.makeCannon(5, 0, 5, Resources.Load<Sprite>("Images/cannon"), "Basic Cannon"));
        return items;
    }
}
