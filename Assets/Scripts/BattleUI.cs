using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleUI : MonoBehaviour
{
    public GameObject[] attackButtons;

    public void AlternateFirstButton(bool canUse, string attackName)
    {
        attackButtons[0].SetActive(canUse);

        if (canUse)
        {
            attackButtons[0].GetComponentInChildren<TextMeshProUGUI>().text = attackName;
        }
    }

    public void AlternateSecondButton(bool canUse, string attackName)
    {
        attackButtons[1].SetActive(canUse);

        if (canUse)
        {
            attackButtons[1].GetComponentInChildren<TextMeshProUGUI>().text = attackName;
        }
    }

    public void AlternateThirdButton(bool canUse, string attackName)
    {
        attackButtons[2].SetActive(canUse);

        if (canUse)
        {
            attackButtons[2].GetComponentInChildren<TextMeshProUGUI>().text = attackName;
        }
    }

    public void AlternateFourthButton(bool canUse, string attackName)
    {
        attackButtons[3].SetActive(canUse);

        if (canUse)
        {
            attackButtons[3].GetComponentInChildren<TextMeshProUGUI>().text = attackName;
        }
    }
}
