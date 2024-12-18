using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capture : MonoBehaviour
{
    public void CatchWildCapybara()
    {
        GameObject emptyCapybara = new GameObject();
        PlayerData playerData = FindAnyObjectByType<PlayerData>();
        emptyCapybara.transform.SetParent(playerData.transform, true);

        WildData wildData = FindAnyObjectByType<WildData>();

        switch (wildData.dataType)
        {
            case "Fire":
                emptyCapybara.AddComponent<Fire>();
                break;

            case "Water":
                emptyCapybara.AddComponent<Water>();
                break;

            case "Grass":
                emptyCapybara.AddComponent<Grass>();
                break;

            case "Normal":
                emptyCapybara.AddComponent<Normal>();
                break;

            case "Fairy":
                emptyCapybara.AddComponent<Fairy>();
                break;

            case "Psychic":
                emptyCapybara.AddComponent<Psychic>();
                break;

            case "Ghost":
                emptyCapybara.AddComponent<Ghost>();
                break;
        }

        emptyCapybara.name = wildData.dataName;
        Capybara capybara = emptyCapybara.GetComponent<Capybara>();
        capybara.state = "Players";

        BattleUI battleUI = FindAnyObjectByType<BattleUI>();
        battleUI.OpenOutputTab();
        battleUI.UpdateOutputText(capybara.capybaraName + " was caught!");
        battleUI.UpdateEffectivenessText("Congratulations!");

        playerData.allCapybaras.Add(emptyCapybara);
        if (playerData.teamCapybaras.Count < 3) playerData.teamCapybaras.Add(emptyCapybara); // 3 e o limite decapivaras no time
    }
}
