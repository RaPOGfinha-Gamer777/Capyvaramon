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
                SetCapybaraStats(cap, fireMinHP, fireMaxHP, fireMinStrenght, fireMaxStrenght, fireMinSpeed, fireMaxSpeed);
            }

            else if (cap.gameObject.tag == "CapivaraAgua")
            {
                SetCapybaraStats(cap, waterMinHP, waterMaxHP, waterMinStrenght, waterMaxStrenght, waterMinSpeed, waterMaxSpeed);
            }

            else if (cap.gameObject.tag == "CapivaraPlanta")
            {
                SetCapybaraStats(cap, grassMinHP, grassMaxHP, grassMinStrenght, grassMaxStrenght, grassMinSpeed, grassMaxSpeed);
            }

            else if (cap.gameObject.tag == "CapivaraNormal")
            {
                SetCapybaraStats(cap, normalMinHP, normalMaxHP, normalMinStrenght, normalMaxStrenght, normalMinSpeed, normalMaxSpeed);
            }

            else if (cap.gameObject.tag == "CapivaraFada")
            {
                SetCapybaraStats(cap, fairyMinHP, fairyMaxHP, fairyMinStrenght, fairyMaxStrenght, fairyMinSpeed, fairyMaxSpeed);
            }

            else if (cap.gameObject.tag == "CapivaraPsiquica")
            {
                SetCapybaraStats(cap, psyMinHP, psyMaxHP, psyMinStrenght, psyMaxStrenght, psyMinSpeed, psyMaxSpeed);
            }

            else if (cap.gameObject.tag == "CapivaraFantasma")
            {
                SetCapybaraStats(cap, ghostMinHP, ghostMaxHP, ghostMinStrenght, ghostMaxStrenght, ghostMinSpeed, ghostMaxSpeed);
            }
            
            cap.state = "Wild";
            
        }
    }

    void SetCapybaraStats(Capybara cap, int hpMin, int hpMax, int strenghtMin, int strenghtMax, int speedMin, int speedMax)
    {
        cap.capybaraName = "Jorge";
        cap.type = "Bug";
        cap.health = CalculateRandomStats(hpMin, hpMax);
        cap.strenght = CalculateRandomStats(strenghtMin, strenghtMax);
        cap.speed = CalculateRandomStats(speedMin, speedMax);
    }

    int CalculateRandomStats(int minValue, int maxValue)
    {
        int value = Random.Range(minValue, maxValue + 1);
        return value;
    }
}
