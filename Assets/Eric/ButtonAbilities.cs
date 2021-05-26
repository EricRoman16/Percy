using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAbilities : MonoBehaviour
{
    public PlayerScript player;

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
                    player.smokeLeft = player.smokeTime;
                    --player.smokes;
                    player.smokeActive = true;
                }
                break;
            case 1:
                if (player.shieldUpgrade == true && player.shieldLeft <= 0 && player.shields > 0)
                {
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
