using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public bool isPlayersTurn;

    Capybara active;
    Capybara enemy;

    Battle battle;
    BattleUI battleUI;

    private void Start()
    {
        battle = FindAnyObjectByType<Battle>();
        battleUI = FindAnyObjectByType<BattleUI>();

        Invoke(nameof(CheckCapybaraSpeed), 0.15f);
    }

    void CheckCapybaraSpeed()
    {
        battle = FindAnyObjectByType<Battle>();
        battleUI = FindAnyObjectByType<BattleUI>();

        if (battle.activeCapybara != null)
        {
            active = battle.activeCapybara.GetComponent<Capybara>();
            enemy = battle.activeEnemy.GetComponent<Capybara>();

            if (active.speed >= enemy.speed)
            {
                isPlayersTurn = true;
                StartPlayersTurn(battle, battleUI, active);
            }
            else
            {
                isPlayersTurn = false;
                StartEnemysTurn(battle, battleUI, enemy);
            }
        }
    }

    public void AlternateTurn()
    {
        isPlayersTurn = !isPlayersTurn;

        if (isPlayersTurn) StartPlayersTurn(battle, battleUI, active);
        else StartEnemysTurn(battle, battleUI, enemy);
    }

    void StartPlayersTurn(Battle battle, BattleUI battleUI, Capybara capybara)
    {
        capybara = battle.activeCapybara.GetComponent<Capybara>();

        battleUI.optionsTab.SetActive(true);
        battleUI.UpdateEffectivenessText("What will " + capybara.capybaraName + " do?");
    }

    void StartEnemysTurn(Battle battle, BattleUI battleUI, Capybara capybara)
    {
        capybara = battle.activeEnemy.GetComponent<Capybara>();

        battleUI.optionsTab.SetActive(false);
        battleUI.UpdateEffectivenessText("(" + capybara.capybaraName + " is deciding what to do" + ")");
    }
}
