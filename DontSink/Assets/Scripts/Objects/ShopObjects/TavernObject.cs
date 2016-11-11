using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TavernObject : ShopObject
{
    //Fields
    private List<CrewObject> crew; 

    //Accessors
    public List<CrewObject> Crew { get { return crew; } set { crew = value; } }
}
