using UnityEngine;

public class PlayerInformation {

    private static PlayerShipObject ship;
    private bool loadTurotial = true;

    public PlayerInformation() { }

    public PlayerShipObject Ship { get { return ship; } set { ship = value; } }
    public bool LoadTurotial { get { return loadTurotial; } set { loadTurotial = value; } }
}