using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("SPAWN STATS")]

    [Header("FIRE")]
    [SerializeField] private int fireMinHP;
    [SerializeField] private int fireMaxHP;
    [SerializeField] private int fireMinStrenght;
    [SerializeField] private int fireMaxStrenght;
    [SerializeField] private int fireMinSpeed;
    [SerializeField] private int fireMaxSpeed;

    [Header("WATER")]
    [SerializeField] private int waterMinHP;
    [SerializeField] private int waterMaxHP;
    [SerializeField] private int waterMinStrenght;
    [SerializeField] private int waterMaxStrenght;
    [SerializeField] private int waterMinSpeed;
    [SerializeField] private int waterMaxSpeed;

    [Header("GRASS")]
    [SerializeField] private int grassMinHP;
    [SerializeField] private int grassMaxHP;
    [SerializeField] private int grassMinStrenght;
    [SerializeField] private int grassMaxStrenght;
    [SerializeField] private int grassMinSpeed;
    [SerializeField] private int grassMaxSpeed;

    [Header("NORMAL")]
    [SerializeField] private int normalMinHP;
    [SerializeField] private int normalMaxHP;
    [SerializeField] private int normalMinStrenght;
    [SerializeField] private int normalMaxStrenght;
    [SerializeField] private int normalMinSpeed;
    [SerializeField] private int normalMaxSpeed;

    [Header("FAIRY")]
    [SerializeField] private int fairyMinHP;
    [SerializeField] private int fairyMaxHP;
    [SerializeField] private int fairyMinStrenght;
    [SerializeField] private int fairyMaxStrenght;
    [SerializeField] private int fairyMinSpeed;
    [SerializeField] private int fairyMaxSpeed;

    [Header("PSYCHIC")]
    [SerializeField] private int psyMinHP;
    [SerializeField] private int psyMaxHP;
    [SerializeField] private int psyMinStrenght;
    [SerializeField] private int psyMaxStrenght;
    [SerializeField] private int psyMinSpeed;
    [SerializeField] private int psyMaxSpeed;

    [Header("GHOST")]
    [SerializeField] private int ghostMinHP;
    [SerializeField] private int ghostMaxHP;
    [SerializeField] private int ghostMinStrenght;
    [SerializeField] private int ghostMaxStrenght;
    [SerializeField] private int ghostMinSpeed;
    [SerializeField] private int ghostMaxSpeed;

    [Header("GENERAL")]
    [SerializeField] private int xpNeededToLevelUp;

    public Capybara[] allCapybaras;

    public int level;

    void Start()
    {
        allCapybaras = FindObjectsOfType<Capybara>();

        foreach (var cap in allCapybaras)
        {
            if (cap.state == "Wild")
            {
                if (cap.gameObject.tag == "FireCapybara")
                {
                    SetCapybaraStats(cap, fireMinHP, fireMaxHP, fireMinStrenght, fireMaxStrenght, fireMinSpeed, fireMaxSpeed);
                }

                else if (cap.gameObject.tag == "WaterCapybara")
                {
                    SetCapybaraStats(cap, waterMinHP, waterMaxHP, waterMinStrenght, waterMaxStrenght, waterMinSpeed, waterMaxSpeed);
                }

                else if (cap.gameObject.tag == "GrassCapybara")
                {
                    SetCapybaraStats(cap, grassMinHP, grassMaxHP, grassMinStrenght, grassMaxStrenght, grassMinSpeed, grassMaxSpeed);
                }

                else if (cap.gameObject.tag == "NormalCapybara")
                {
                    SetCapybaraStats(cap, normalMinHP, normalMaxHP, normalMinStrenght, normalMaxStrenght, normalMinSpeed, normalMaxSpeed);
                }

                else if (cap.gameObject.tag == "FairyCapybara")
                {
                    SetCapybaraStats(cap, fairyMinHP, fairyMaxHP, fairyMinStrenght, fairyMaxStrenght, fairyMinSpeed, fairyMaxSpeed);
                }

                else if (cap.gameObject.tag == "PsychicCapybara")
                {
                    SetCapybaraStats(cap, psyMinHP, psyMaxHP, psyMinStrenght, psyMaxStrenght, psyMinSpeed, psyMaxSpeed);
                }

                else if (cap.gameObject.tag == "GhostCapybara")
                {
                    SetCapybaraStats(cap, ghostMinHP, ghostMaxHP, ghostMinStrenght, ghostMaxStrenght, ghostMinSpeed, ghostMaxSpeed);
                }

                CalculateSpawnXP(cap);
            }   
        }
    }

    void SetCapybaraStats(Capybara cap, int hpMin, int hpMax, int strenghtMin, int strenghtMax, int speedMin, int speedMax)
    {
        cap.health = CalculateRandomStats(hpMin, hpMax);
        cap.strenght = CalculateRandomStats(strenghtMin, strenghtMax);
        cap.speed = CalculateRandomStats(speedMin, speedMax);
    }

    int CalculateRandomStats(int minValue, int maxValue)
    {
        int value = Random.Range(minValue, maxValue + 1);
        return value;
    }

    void CalculateSpawnXP(Capybara cap)
    {
        int firstRng = Random.Range(1, 101); // chance da capivara spawnar com um nivel mais alto
        int xp;
        int level = 1;

        if (firstRng <= 55)
        {
            xp = Random.Range(0, 50);
        }
        else if (firstRng <= 55 + 25)
        {
            xp = Random.Range(50, 100);
        }
        else if (firstRng <= 80 + 12)
        {
            xp = Random.Range(100, 150);
        }
        else if (firstRng <= 92 + 5)
        {
            xp = Random.Range(150, 200);
        }
        else if (firstRng <= 97 + 2)
        {
            xp = Random.Range(200, 250);
        }
        else
        {
            xp = Random.Range(250, 300);
        }

        while (xp >= 25)
        {
            xp -= 25;
            level++;
        }

        cap.capybaraLevel = level;
        cap.capybaraXP = xp;

        CheckAvailableAttacks(cap);
    }

    void CheckAvailableAttacks(Capybara cap)
    {
        if (cap.capybaraLevel >= 1) cap.canUseFirstAttack = true;
        if (cap.capybaraLevel >= 5) cap.canUseSecondAttack = true;
        if (cap.capybaraLevel >= 15) cap.canUseThirdAttack = true;
        if (cap.capybaraLevel >= 30) cap.canUseFourthAttack = true;
    }
}
