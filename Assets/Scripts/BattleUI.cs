using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BattleUI : MonoBehaviour
{
    public GameObject[] attackButtons;
    public GameObject[] battleTabs;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI powerText;

    public TextMeshProUGUI outputText;
    public TextMeshProUGUI effectivenessText;

    public void AlternateFirstButton(bool canUse, string attackName, string attackCost)
    {
        attackButtons[0].SetActive(canUse);

        if (canUse)
        {
            attackButtons[0].GetComponentInChildren<TextMeshProUGUI>().text = attackName + ": " + attackCost;
        }
    }

    public void AlternateSecondButton(bool canUse, string attackName, string attackCost)
    {
        attackButtons[1].SetActive(canUse);

        if (canUse)
        {
            attackButtons[1].GetComponentInChildren<TextMeshProUGUI>().text = attackName + ": " + attackCost;
        }
    }

    public void AlternateThirdButton(bool canUse, string attackName, string attackCost)
    {
        attackButtons[2].SetActive(canUse);

        if (canUse)
        {
            attackButtons[2].GetComponentInChildren<TextMeshProUGUI>().text = attackName + ": " + attackCost;
        }
    }

    public void AlternateFourthButton(bool canUse, string attackName, string attackCost)
    {
        attackButtons[3].SetActive(canUse);

        if (canUse)
        {
            attackButtons[3].GetComponentInChildren<TextMeshProUGUI>().text = attackName + ": " + attackCost;
        }
    }

    // // // // // // // // // // // // // // // // // // //

    public void UpdateUICard(string name, int level, int health, int maxHealth, int power, int maxPower)
    {
        nameText.text = name;
        levelText.text = "Lv: " + level.ToString();
        healthText.text = "HP: " + health.ToString() + "/" + maxHealth.ToString();
        powerText.text = "PP: " + power.ToString() + "/" + maxPower.ToString();
    }

    public void UpdateOutputText(string output)
    {
        outputText.text = output;
    }

    public void UpdateEffectivenessText(string output)
    {
        effectivenessText.text = output;
    }

    // // // // // // // // // // // // // //

    public void RunAway()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenOutputTab()
    {
        CloseUITabs();
        battleTabs[0].SetActive(true);
    }

    public void OpenFightTab()
    {
        CloseUITabs();
        battleTabs[1].SetActive(true);
    }

    public void OpenBagTab()
    {
        CloseUITabs();
        battleTabs[2].SetActive(true);
    }

    void CloseUITabs()
    {
        for (int i = 0; i < battleTabs.Length; i++)
        { 
            battleTabs[i].SetActive(false);
        }
    }
}
