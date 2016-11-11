using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NavalShop : ShopObject
{
    //Fields
    private List<ItemObject> items;

    //Accessors
    public List<ItemObject> Items { get { return items; } set { items = value; } }
}
