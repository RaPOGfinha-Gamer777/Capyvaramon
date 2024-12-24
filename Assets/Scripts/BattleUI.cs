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
    public GameObject[] teamButtons;

    public GameObject optionsTab;

    public GameObject introPanel;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI powerText;

    public TextMeshProUGUI enemyNameText;
    public TextMeshProUGUI enemyLevelText;
    public TextMeshProUGUI enemyHealthText;
    public TextMeshProUGUI enemyPowerText;

    public TextMeshProUGUI outputText;
    public TextMeshProUGUI effectivenessText;

    private void Start()
    {
        PlayerData playerData = FindAnyObjectByType<PlayerData>();

        for (int i = 0; i < playerData.teamCapybaras.Count; i++)
        {
            teamButtons[i].SetActive(true);
        }

        Invoke(nameof(DeactivateIntroPanel), 2);
    }

    void DeactivateIntroPanel()
    {
        introPanel.SetActive(false);
    }

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

    public void UpdateEnemyUICard(string name, int level, int health, int maxHealth, int power, int maxPower)
    {
        enemyNameText.text = name;
        enemyLevelText.text = "Lv: " + level.ToString();
        enemyHealthText.text = "HP: " + health.ToString() + "/" + maxHealth.ToString();
        enemyPowerText.text = "PP: " + power.ToString() + "/" + maxPower.ToString();
    }

    public void UpdateOutputText(string output)
    {
        OpenOutputTab();
        outputText.text = output;
    }

    public void UpdateEffectivenessText(string output)
    {
        OpenOutputTab();
        effectivenessText.text = output;
    }

    // // // // // // // // // // // // // //

    public void RunAway()
    {
        PlayerData playerData = FindAnyObjectByType<PlayerData>();
        
        for (int i = 0; i < playerData.teamCapybaras.Count; i++) // para resetar o especial das capivaras normais 
        {
            Capybara capybara = playerData.teamCapybaras[i].GetComponent<Capybara>();
            capybara.weaknessMultiplier = 1;
        }

        SceneManager.LoadScene("GameScene");
    }

    public void QuitAfterCaptureOrBattleEnd()
    {
        optionsTab.gameObject.SetActive(false);
        Invoke(nameof(RunAway), 3); // tempo da musica de captura
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

    public void OpenTeamTab()
    {
        CloseUITabs();
        battleTabs[3].SetActive(true);
    }

    void CloseUITabs()
    {
        for (int i = 0; i < battleTabs.Length; i++)
        { 
            battleTabs[i].SetActive(false);
        }
    }
}
