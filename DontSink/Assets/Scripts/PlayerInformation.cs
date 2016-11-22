using UnityEngine;

public class PlayerInformation {

    private  PlayerShipObject ship;

    public PlayerInformation() { }

    public PlayerShipObject Ship { get { return ship; } set { ship = value; } }
}