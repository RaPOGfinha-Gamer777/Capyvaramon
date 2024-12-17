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
        CheckActiveAttacks();
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
            battleUI.AlternateFirstButton(true, cap.firstAttackName);           
        }
        else
        {
            battleUI.AlternateFirstButton(false, cap.firstAttackName);
        }

        if (cap.canUseSecondAttack)
        {
            battleUI.AlternateSecondButton(true, cap.secondAttackName);
        }
        else
        {
            battleUI.AlternateSecondButton(false, cap.secondAttackName);
        }

        if (cap.canUseThirdAttack)
        {
            battleUI.AlternateThirdButton(true, cap.thirdAttackName);
        }
        else
        {
            battleUI.AlternateThirdButton(false, cap.thirdAttackName);
        }

        if (cap.canUseFourthAttack)
        {
            battleUI.AlternateFourthButton(true, cap.fourthAttackName);
        }
        else
        {
            battleUI.AlternateFourthButton(false, cap.fourthAttackName);
        }
    }
}
