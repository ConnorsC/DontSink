using UnityEngine;

public class PlayerInformation {

    private static PlayerShipObject ship;

    public PlayerInformation() { }

    public PlayerShipObject Ship { get { return ship; } set { ship = value; } }
}