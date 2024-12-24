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

    void CheckEnemyConditions()
    {

    }
}
