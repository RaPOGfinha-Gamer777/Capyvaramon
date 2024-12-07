using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class GameController : MonoBehaviour
{
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
        }
    }

    void SetFireStats(Capybara capybara)
    {
        capybara.capybaraName = "Capivara de Fogo";
    }

    void SetWaterStats(Capybara capybara)
    {
        capybara.capybaraName = "Capivara de Água";
    }

    void SetGrassStats(Capybara capybara)
    {
        capybara.capybaraName = "Capivara de Planta";
    }
}
