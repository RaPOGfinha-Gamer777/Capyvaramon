using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("ATRIBUTOS AO SPAWNAR")]

    [Header("FOGO")]
    [SerializeField] private int fireMinHP;
    [SerializeField] private int fireMaxHP;
    [SerializeField] private int fireMinStrenght;
    [SerializeField] private int fireMaxStrenght;
    [SerializeField] private int fireMinSpeed;
    [SerializeField] private int fireMaxSpeed;

    [Header("ÁGUA")]
    [SerializeField] private int waterMinHP;
    [SerializeField] private int waterMaxHP;
    [SerializeField] private int waterMinStrenght;
    [SerializeField] private int waterMaxStrenght;
    [SerializeField] private int waterMinSpeed;
    [SerializeField] private int waterMaxSpeed;

    [Header("PLANTA")]
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

    [Header("FADA")]
    [SerializeField] private int fairyMinHP;
    [SerializeField] private int fairyMaxHP;
    [SerializeField] private int fairyMinStrenght;
    [SerializeField] private int fairyMaxStrenght;
    [SerializeField] private int fairyMinSpeed;
    [SerializeField] private int fairyMaxSpeed;

    [Header("PSIQUICA")]
    [SerializeField] private int psyMinHP;
    [SerializeField] private int psyMaxHP;
    [SerializeField] private int psyMinStrenght;
    [SerializeField] private int psyMaxStrenght;
    [SerializeField] private int psyMinSpeed;
    [SerializeField] private int psyMaxSpeed;

    [Header("FANTAMSA")]
    [SerializeField] private int ghostMinHP;
    [SerializeField] private int ghostMaxHP;
    [SerializeField] private int ghostMinStrenght;
    [SerializeField] private int ghostMaxStrenght;
    [SerializeField] private int ghostMinSpeed;
    [SerializeField] private int ghostMaxSpeed;

    public Capybara[] allCapybaras;

    void Start()
    {
        allCapybaras = FindObjectsOfType<Capybara>();

        foreach (var cap in allCapybaras)
        {
            if (cap.gameObject.tag == "CapivaraFogo")
            {
                SetFireStats(cap);
            }

            else if (cap.gameObject.tag == "CapivaraAgua")
            {
                SetWaterStats(cap);
            }

            else if (cap.gameObject.tag == "CapivaraPlanta")
            {
                SetGrassStats(cap);
            }

            else if (cap.gameObject.tag == "CapivaraNormal")
            {
                SetNormalStats(cap);
            }

            else if (cap.gameObject.tag == "CapivaraFada")
            {
                SetFairyStats(cap);
            }

            else if (cap.gameObject.tag == "CapivaraPsiquica")
            {
                SetPsyStats(cap);
            }

            else if (cap.gameObject.tag == "CapivaraFantasma")
            {
                SetGhostStats(cap);
            }
        }
    }

    int CalculateRandomStats(int minValue, int maxValue)
    {
        int value = Random.Range(minValue, maxValue + 1);
        return value;
    }

    void SetFireStats(Capybara capybara)
    {
        capybara.capybaraName = "Capivara de Fogo";
        capybara.type = "Fire";
        capybara.health = CalculateRandomStats(fireMinHP, fireMaxHP);
        capybara.strenght = CalculateRandomStats(fireMinStrenght, fireMaxStrenght);
        capybara.speed = CalculateRandomStats(fireMinSpeed, fireMaxSpeed);
    }

    void SetWaterStats(Capybara capybara)
    {
        capybara.capybaraName = "Capivara de Água";
        capybara.type = "Water";
        capybara.health = CalculateRandomStats(waterMinHP, waterMaxHP);
        capybara.strenght = CalculateRandomStats(waterMinStrenght, waterMaxStrenght);
        capybara.speed = CalculateRandomStats(waterMinSpeed, waterMaxSpeed);
    }

    void SetGrassStats(Capybara capybara)
    {
        capybara.capybaraName = "Capivara de Planta";
        capybara.type = "Grass";
        capybara.health = CalculateRandomStats(grassMinHP, grassMaxHP);
        capybara.strenght = CalculateRandomStats(grassMinStrenght, grassMaxStrenght);
        capybara.speed = CalculateRandomStats(grassMinSpeed, grassMaxSpeed);
    }

    void SetNormalStats(Capybara capybara)
    {
        capybara.capybaraName = "Capivara Normal";
        capybara.type = "Normal";
        capybara.health = CalculateRandomStats(normalMinHP, normalMaxHP);
        capybara.strenght = CalculateRandomStats(normalMinStrenght, normalMaxStrenght);
        capybara.speed = CalculateRandomStats(normalMinSpeed, normalMaxSpeed);
    }

    void SetFairyStats(Capybara capybara)
    {
        capybara.capybaraName = "Capivara Fada";
        capybara.type = "Fairy";
        capybara.health = CalculateRandomStats(fairyMinHP, fairyMaxHP);
        capybara.strenght = CalculateRandomStats(fairyMinStrenght, fairyMaxStrenght);
        capybara.speed = CalculateRandomStats(fairyMinSpeed, fairyMaxSpeed);
    }

    void SetPsyStats(Capybara capybara)
    {
        capybara.capybaraName = "Capivara Psiquica";
        capybara.type = "Psychic";
        capybara.health = CalculateRandomStats(fairyMinHP, fairyMaxHP);
        capybara.strenght = CalculateRandomStats(fairyMinStrenght, fairyMaxStrenght);
        capybara.speed = CalculateRandomStats(fairyMinSpeed, fairyMaxSpeed);
    }

    void SetGhostStats(Capybara capybara)
    {
        capybara.capybaraName = "Capivara Fantasma";
        capybara.type = "Ghost";
        capybara.health = CalculateRandomStats(ghostMinHP, ghostMaxHP);
        capybara.strenght = CalculateRandomStats(ghostMinStrenght, ghostMaxStrenght);
        capybara.speed = CalculateRandomStats(ghostMinSpeed, ghostMaxSpeed);
    }
}
