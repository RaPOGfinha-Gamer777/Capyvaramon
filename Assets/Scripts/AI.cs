using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    Capybara thisCapybara;
    Capybara playersCapybara;

    private void Start()
    {
        thisCapybara = GetComponent<Capybara>();

        Battle battle = FindAnyObjectByType<Battle>();

        if (battle.activeCapybara != null) playersCapybara = battle.activeCapybara.GetComponent<Capybara>();
    }

    public void CheckThisConditions()
    {
        switch (thisCapybara.canUseFirstAttack)
        {
            case true:
                Invoke(nameof(AttackWithFirst), 3);
                break;
        }
    }

    void AttackWithFirst()
    {
        thisCapybara.UseFirstAttack();

        UpdateTurnControllerAndUI();
    }

    void UpdateTurnControllerAndUI()
    {
        BattleUI battleUI = FindAnyObjectByType<BattleUI>();
        battleUI.UpdateUICard(playersCapybara.capybaraName, playersCapybara.capybaraLevel, playersCapybara.health, playersCapybara.maxHealth, playersCapybara.powerPoints, playersCapybara.maxPowerPoints);

        TurnController turnController = FindAnyObjectByType<TurnController>();
        turnController.AlternateTurn();
    }
}
