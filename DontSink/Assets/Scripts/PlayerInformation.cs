using UnityEngine;

public class PlayerInformation {

    private static PlayerShipObject ship;
    private int gold = 0;
    private bool loadTutorial = true;
    private string playerShipTag;

    public PlayerInformation() { }

    public PlayerShipObject Ship { get { return ship; } set { ship = value; } }
    public int Gold { get { return gold; } set { gold = value; } }
    public bool LoadTurotial { get { return loadTutorial; } set { loadTutorial = value; } }
    public string PlayerShipTag { get { return playerShipTag; } set { playerShipTag = value; } }
}