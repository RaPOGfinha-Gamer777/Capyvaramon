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
        
        if (Input.GetKeyDown(KeyCode.H))
        {
            Capybara cap = activeCapybara.GetComponent<Capybara>();
            cap.UseFirstAttack();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Capybara cap = activeCapybara.GetComponent<Capybara>();
            cap.UseSecondAttack();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Capybara cap = activeCapybara.GetComponent<Capybara>();
            cap.UseThirdAttack();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Capybara cap = activeCapybara.GetComponent<Capybara>();
            cap.UseFourthAttack();
        }
    }

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
