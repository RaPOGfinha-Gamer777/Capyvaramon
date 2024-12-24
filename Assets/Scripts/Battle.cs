using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public GameObject[] teamSprites; // sprites das capivaras na cena de batalha
    // array do time inimigo
    private GameObject activeSprite; // sprite ativa

    public GameObject activeCapybara;
    public GameObject activeEnemy;

    private void Start()
    {
        if (teamSprites.Length > 0)
        {
            foreach (var sprite in teamSprites)
            {
                sprite.SetActive(false);
            }
            teamSprites[0].SetActive(true);
            activeSprite = teamSprites[0];

            PlayerData playerData = FindAnyObjectByType<PlayerData>();
            activeCapybara = playerData.teamCapybaras[0];
        }

        activeEnemy = GameObject.FindGameObjectWithTag("Enemy");
        Capybara cap = activeEnemy.GetComponent<Capybara>();
        SendEnemyUIInfo();

        SendOutputText("A wild " + cap.capybaraName + " appeared!");

        if (activeCapybara != null)
        {
            Capybara activeCap = activeCapybara.GetComponent<Capybara>();

            CheckActiveAttacks();
            SendUIInfo();
        }
    }

    public void AttackWithFirst()
    {
        Capybara cap = activeCapybara.GetComponent<Capybara>();

        if (cap.firstAttackCost <= cap.powerPoints)
        {
            cap.UseFirstAttack();
            SendUIInfo();
            SendEnemyUIInfo();

            EndTurn();
        }
        else
        {
            SendOutputText("Not enough power points!");
            SendEffectivenessText("");
        }
    }

    public void AttackWithSecond()
    {
        Capybara cap = activeCapybara.GetComponent<Capybara>();

        if (cap.secondAttackCost <= cap.powerPoints)
        {
            cap.UseSecondAttack();
            SendUIInfo();
            SendEnemyUIInfo();

            EndTurn();
        }
        else
        {
            SendOutputText("Not enough power points!");
            SendEffectivenessText("");
        }
    }

    public void AttackWithThird()
    {
        Capybara cap = activeCapybara.GetComponent<Capybara>();

        if (cap.thirdAttackCost <= cap.powerPoints)
        {
            cap.UseThirdAttack();
            SendUIInfo();
            SendEnemyUIInfo();

            EndTurn();
        }
        else
        {
            SendOutputText("Not enough power points!");
            SendEffectivenessText("");
        }
    }

    public void AttackWithFourth()
    {
        Capybara cap = activeCapybara.GetComponent<Capybara>();

        if (cap.fourthAttackCost <= cap.powerPoints)
        {
            cap.UseFourthAttack();
            SendUIInfo();
            SendEnemyUIInfo();

            EndTurn();
        }
        else
        {
            SendOutputText("Not enough power points!");
            SendEffectivenessText("");
        }
    }

    // // // // // // // // // // // // // // // // // // // // // 

    public void SwitchWitchFirst()
    {
        if (activeSprite != teamSprites[0])
        {
            Capybara currentActive = activeCapybara.GetComponent<Capybara>();
            SendOutputText("Go get some rest " + currentActive.capybaraName + "!");

            activeSprite.SetActive(false);
            activeSprite = teamSprites[0];
            activeSprite.SetActive(true);

            PlayerData playerData = FindAnyObjectByType<PlayerData>();
            activeCapybara = playerData.teamCapybaras[0];

            Capybara newActive = activeCapybara.GetComponent<Capybara>();
            SendEffectivenessText("Go " + newActive.capybaraName + "!");

            CheckActiveAttacks();
            SendUIInfo();

            EndTurn();
        }
        else
        {
            SendOutputText("This is already your active capybara!");
            SendEffectivenessText("");
        }
    }

    public void SwitchWitchSecond()
    {
        if (activeSprite != teamSprites[1])
        {
            Capybara currentActive = activeCapybara.GetComponent<Capybara>();
            SendOutputText("Go get some rest " + currentActive.capybaraName + "!");

            activeSprite.SetActive(false);
            activeSprite = teamSprites[1];
            activeSprite.SetActive(true);

            PlayerData playerData = FindAnyObjectByType<PlayerData>();
            activeCapybara = playerData.teamCapybaras[1];

            Capybara newActive = activeCapybara.GetComponent<Capybara>();
            SendEffectivenessText("Go " + newActive.capybaraName + "!");

            CheckActiveAttacks();
            SendUIInfo();

            EndTurn();

        }
        else
        {
            SendOutputText("This is already your active capybara!");
            SendEffectivenessText("");
        }
    }

    public void SwitchWitchThird()
    {
        if (activeSprite != teamSprites[2])
        {
            Capybara currentActive = activeCapybara.GetComponent<Capybara>();
            SendOutputText("Go get some rest " + currentActive.capybaraName + "!");

            activeSprite.SetActive(false);
            activeSprite = teamSprites[2];
            activeSprite.SetActive(true);

            PlayerData playerData = FindAnyObjectByType<PlayerData>();
            activeCapybara = playerData.teamCapybaras[2];

            Capybara newActive = activeCapybara.GetComponent<Capybara>();
            SendEffectivenessText("Go " + newActive.capybaraName + "!");

            CheckActiveAttacks();
            SendUIInfo();

            EndTurn();
        }
        else
        {
            SendOutputText("This is already your active capybara!");
            SendEffectivenessText("");
        }
    }

    // // // // // // // // // // // // // // // // // // // // // // //

    void CheckActiveAttacks()
    {
        Capybara cap = activeCapybara.GetComponent<Capybara>();
        BattleUI battleUI = FindAnyObjectByType<BattleUI>();

        if (cap.canUseFirstAttack)
        {
            battleUI.AlternateFirstButton(true, cap.firstAttackName, cap.firstAttackCost.ToString());           
        }
        else
        {
            battleUI.AlternateFirstButton(false, cap.firstAttackName, cap.firstAttackCost.ToString());
        }

        if (cap.canUseSecondAttack)
        {
            battleUI.AlternateSecondButton(true, cap.secondAttackName, cap.secondAttackCost.ToString());
        }
        else
        {
            battleUI.AlternateSecondButton(false, cap.secondAttackName, cap.secondAttackCost.ToString());
        }

        if (cap.canUseThirdAttack)
        {
            battleUI.AlternateThirdButton(true, cap.thirdAttackName, cap.thirdAttackCost.ToString());
        }
        else
        {
            battleUI.AlternateThirdButton(false, cap.thirdAttackName, cap.thirdAttackCost.ToString());
        }

        if (cap.canUseFourthAttack)
        {
            battleUI.AlternateFourthButton(true, cap.fourthAttackName, cap.fourthAttackCost.ToString());
        }
        else
        {
            battleUI.AlternateFourthButton(false, cap.fourthAttackName, cap.fourthAttackCost.ToString());
        }
    }

    // // // // // // // // // // // // // // // // // //

    public void DeactivateCapybara(Capybara capybara)
    {
        SpriteRenderer spriteRenderer = capybara.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            capybara.gameObject.SetActive(false);

            // adicionar if que verifica se todo time inimigo esta nocauteado

            // adicionar if que verifica se o inimigo era uma capivara selvagem ou um treinador
            SendOutputText(capybara.capybaraName + " was defeated!");
            SendEffectivenessText("Congratulations!");

            BattleUI battleUI = FindAnyObjectByType<BattleUI>();
            battleUI.QuitAfterCaptureOrBattleEnd();
        }
        else
        {
            activeCapybara.SetActive(false);
        }

        // GetComponent no animator e play na animacao
    }

    // // // // // // // // // // // // // // // // //

    void SendUIInfo()
    {
        Capybara capybara = activeCapybara.GetComponent<Capybara>();
        BattleUI battleUI = FindAnyObjectByType<BattleUI>();

        battleUI.UpdateUICard(capybara.capybaraName, capybara.capybaraLevel, capybara.health, capybara.maxHealth, capybara.powerPoints, capybara.maxPowerPoints);
    }

    void SendEnemyUIInfo()
    {
        Capybara capybara = activeEnemy.GetComponent<Capybara>();
        BattleUI battleUI = FindAnyObjectByType<BattleUI>();

        battleUI.UpdateEnemyUICard(capybara.capybaraName, capybara.capybaraLevel, capybara.health, capybara.maxHealth, capybara.powerPoints, capybara.maxPowerPoints);
    }

    void SendOutputText(string output)
    {
        BattleUI battleUI = FindAnyObjectByType<BattleUI>();
        battleUI.UpdateOutputText(output);
    }

    void SendEffectivenessText(string output)
    {
        BattleUI battleUI = FindAnyObjectByType<BattleUI>();
        battleUI.UpdateEffectivenessText(output);
    }

    // // // // // // // // // // // // // // // // // // //

    void EndTurn()
    {
        Capybara capybara = activeCapybara.GetComponent<Capybara>();
        Capybara enemy = activeEnemy.GetComponent<Capybara>();

        if (capybara.type != "Normal") // para prevalecer o critico ao usar o especial
        {
            capybara.weaknessMultiplier = 1;
        }

        if (enemy.type != "Normal") // para prevalecer o critico ao usar o especial
        {
            enemy.weaknessMultiplier = 1;
        }

        capybara.resistance = 0;      
        enemy.resistance = 0;

        TurnController turnController = FindAnyObjectByType<TurnController>();
        turnController.AlternateTurn();
    }
}
