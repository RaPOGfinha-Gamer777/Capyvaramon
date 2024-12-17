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
        }
        else Debug.Log("Essa já é sua capivara ativa");
    }
}
