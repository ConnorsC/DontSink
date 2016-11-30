using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CannonUIController : MonoBehaviour
{
    private GameObject button;
    private Slider cooldownBar;
    private Text text;

    public float cooldown = 2;
    public string cannonName = "Cannon";
    private float cooldownTimer;

    // Use this for initialization
    void Start () {
        button = this.gameObject.transform.parent.Find("CannonSelect").gameObject;
        cooldownBar = this.gameObject.transform.parent.Find("CannonCooldown").GetComponent<Slider>();
        text = button.transform.Find("CannonName").GetComponent<Text>();

        text.text = cannonName;
        cooldownBar.maxValue = cooldown;
        cooldownBar.value = cooldown;
        cooldownTimer = 0.0f;
    }
    void Update()
    {
        if (cooldownTimer < cooldown)
            cooldownTimer += Time.deltaTime;
        cooldownBar.value = cooldownTimer;
    }
    public void Click()
    {
        if(cooldownTimer >= cooldown)
            cooldownTimer = 0.0f;
        cooldownBar.value = cooldownTimer;
        print("Button Clicked");
    }
}
