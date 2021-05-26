using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAbilities : MonoBehaviour
{
    public PlayerScript player;
    public GameObject Player;
    public Image tint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseAbility(int code)
    {
        switch (code)
        {
            case 0:
                if (player.smokeUpgrade == true && player.smokeLeft <= 0 && player.smokes > 0)
                {
                    Player.GetComponent<SpriteRenderer>().color = new Color(121, 121, 121, 121);
                    player.smokeLeft = player.smokeTime;
                    --player.smokes;
                    player.smokeActive = true;
                }
                break;
            case 1:
                if (player.shieldUpgrade == true && player.shieldLeft <= 0 && player.shields > 0)
                {
                    tint.color = new Color(0,140,255,90);
                    player.shieldLeft = player.shieldTime;
                    --player.shields;
                    player.shieldActive = true;
                }
                break;
            default:
                Debug.LogError("Ability Out of Range!");
                break;
        }
    }
}
