using UnityEngine;

public class PlayerInformation {

    private static PlayerShipObject ship;
<<<<<<< HEAD
    private int gold = 0;
=======
    private bool loadTurotial = true;
>>>>>>> refs/remotes/origin/Dev

    public PlayerInformation() { }

    public PlayerShipObject Ship { get { return ship; } set { ship = value; } }
<<<<<<< HEAD
    public int Gold { get { return gold; } set { gold = value; } }
=======
    public bool LoadTurotial { get { return loadTurotial; } set { loadTurotial = value; } }
>>>>>>> refs/remotes/origin/Dev
}