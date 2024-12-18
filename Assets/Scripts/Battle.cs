using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public GameObject[] teamSprites; // sprites das capivaras na cena de batalha
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

        if (activeCapybara != null)
        {
            CheckActiveAttacks();
            SendUIInfo();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SwitchWitchFirst();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SwitchWitchSecond();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            SwitchWitchThird();
        }
    }

    public void AttackWithFirst()
    {
        Capybara cap = activeCapybara.GetComponent<Capybara>();

        if (cap.firstAttackCost <= cap.powerPoints)
        {
            cap.UseFirstAttack();
            SendUIInfo();
            // funcao para passar o turno
        }
        else Debug.Log("pontos insuficientes!");
    }

    public void AttackWithSecond()
    {
        Capybara cap = activeCapybara.GetComponent<Capybara>();

        if (cap.secondAttackCost <= cap.powerPoints)
        {
            cap.UseSecondAttack();
            SendUIInfo();
            // funcao para passar o turno
        }
        else Debug.Log("pontos insuficientes!");
    }

    public void AttackWithThird()
    {
        Capybara cap = activeCapybara.GetComponent<Capybara>();

        if (cap.thirdAttackCost <= cap.powerPoints)
        {
            cap.UseThirdAttack();
            SendUIInfo();
            // funcao para passar o turno
        }
        else Debug.Log("pontos insuficientes!");
    }

    public void AttackWithFourth()
    {
        Capybara cap = activeCapybara.GetComponent<Capybara>();

        if (cap.fourthAttackCost <= cap.powerPoints)
        {
            cap.UseFourthAttack();
            SendUIInfo();
            // funcao para passar o turno
        }
        else Debug.Log("pontos insuficientes!");
    }

    // // // // // // // // // // // // // // // // // // // // // 

    public void SwitchWitchFirst()
    {
        if (activeSprite != teamSprites[0])
        {
            activeSprite.SetActive(false);
            activeSprite = teamSprites[0];
            activeSprite.SetActive(true);

            PlayerData playerData = FindAnyObjectByType<PlayerData>();
            activeCapybara = playerData.teamCapybaras[0];

            CheckActiveAttacks();
            SendUIInfo();
        }
        else Debug.Log("Essa já é sua capivara ativa");
    }

    public void SwitchWitchSecond()
    {
        if (activeSprite != teamSprites[1])
        {
            activeSprite.SetActive(false);
            activeSprite = teamSprites[1];
            activeSprite.SetActive(true);

            PlayerData playerData = FindAnyObjectByType<PlayerData>();
            activeCapybara = playerData.teamCapybaras[1];

            CheckActiveAttacks();
            SendUIInfo();
        }
        else Debug.Log("Essa já é sua capivara ativa");
    }

    public void SwitchWitchThird()
    {
        if (activeSprite != teamSprites[2])
        {
            activeSprite.SetActive(false);
            activeSprite = teamSprites[2];
            activeSprite.SetActive(true);

            PlayerData playerData = FindAnyObjectByType<PlayerData>();
            activeCapybara = playerData.teamCapybaras[2];

            CheckActiveAttacks();
            SendUIInfo();
        }
        else Debug.Log("Essa já é sua capivara ativa");
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

    void SendUIInfo()
    {
        Capybara capybara = activeCapybara.GetComponent<Capybara>();
        BattleUI battleUI = FindAnyObjectByType<BattleUI>();

        battleUI.UpdateUICard(capybara.capybaraName, capybara.capybaraLevel, capybara.health, capybara.maxHealth, capybara.powerPoints, capybara.maxPowerPoints);
    }
}
