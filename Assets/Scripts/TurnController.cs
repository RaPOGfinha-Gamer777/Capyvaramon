using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public bool isPlayersTurn;

    private void Start()
    {
        Invoke(nameof(CheckCapybaraSpeed), 0.15f);
    }

    void CheckCapybaraSpeed()
    {
        Battle battle = FindAnyObjectByType<Battle>();
        BattleUI battleUI = FindAnyObjectByType<BattleUI>();

        if (battle.activeCapybara != null)
        {
            Capybara active = battle.activeCapybara.GetComponent<Capybara>();
            Capybara enemy = battle.activeEnemy.GetComponent<Capybara>();

            if (active.speed >= enemy.speed)
            {
                battleUI.optionsTab.SetActive(true);
                battleUI.UpdateEffectivenessText("What will " + active.capybaraName + " do?");
            }
            else
            {
                battleUI.optionsTab.SetActive(false);
                battleUI.UpdateEffectivenessText("(" + enemy.capybaraName + " will go first" + ")");
            }
        }
    }

    public void AlternateTurn()
    {
        isPlayersTurn = !isPlayersTurn;

    }
}
