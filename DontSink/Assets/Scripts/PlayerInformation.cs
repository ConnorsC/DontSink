using UnityEngine;

public class PlayerInformation {

    private static PlayerShipObject ship;
    private int gold = 0;

    public PlayerInformation() { }

    public PlayerShipObject Ship { get { return ship; } set { ship = value; } }
    public int Gold { get { return gold; } set { gold = value; } }
}