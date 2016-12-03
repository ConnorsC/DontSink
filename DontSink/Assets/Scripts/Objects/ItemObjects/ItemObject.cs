using UnityEngine;
using System.Collections;

public class ItemObject
{
    //Fields
    private GameObject item_texture;
    private Texture icon;
    private string name;
    private int val;

    //Accessors
    public GameObject Item_Texture { get { return item_texture; } set { item_texture = value; } }
    public Texture Icon { get { return icon; } set { icon = value; } }
    public string Name { get { return name; } set { name = value; } }
    public int Value { get { return val; } set { val = value; } }
}
