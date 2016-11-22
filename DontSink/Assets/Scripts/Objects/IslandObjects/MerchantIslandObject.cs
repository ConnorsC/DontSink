using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MerchantIslandObject : IslandObject
{
    //Fields
    private List<ShopObject> shop;

    //Accessors
    public List<ShopObject> Shop { get { return shop; } set { shop = value; } }

    public MerchantIslandObject() { }
    public MerchantIslandObject(List<ShopObject> shops)
    {
        this.shop = shops;
    }
}
