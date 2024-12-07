using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WildData : MonoBehaviour
{
    public static WildData instance;

    public string dataName;
    public string dataType;
    public int dataHealth;
    public int dataStrenght;
    public int dataSpeed;
    public int dataWeaknessMultiplier;
    public int dataResistenceMultiplier;

    private GameObject instantiatedCapybara;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Teste(RaycastHit2D wildCapivara)
    {
        Capybara other = wildCapivara.collider.gameObject.GetComponent<Capybara>();

        if (other != null)
        {
            dataName = other.capybaraName;
            dataType = other.type;
            dataHealth = other.health;
            dataStrenght = other.strenght;
            dataSpeed = other.speed;
            dataWeaknessMultiplier = other.weaknessMultiplier;
            dataResistenceMultiplier = other.resistenceMultiplier;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "TestesBatalha")
        {
            if (dataType == "Water")
            {
                instantiatedCapybara = Resources.Load<GameObject>("CapivaraAgua");
                if (instantiatedCapybara != null) Instantiate(instantiatedCapybara);
            }

            else if (dataType == "Fire")
            {
                instantiatedCapybara = Resources.Load<GameObject>("CapivaraFogo");
                if (instantiatedCapybara != null) Instantiate(instantiatedCapybara);
            }

            else if (dataType == "Grass")
            {
                instantiatedCapybara = Resources.Load<GameObject>("CapivaraPlanta");
                if (instantiatedCapybara != null) Instantiate(instantiatedCapybara);
            }

            else if (dataType == "Normal")
            {
                instantiatedCapybara = Resources.Load<GameObject>("CapivaraNormal");
                if (instantiatedCapybara != null) Instantiate(instantiatedCapybara);
            }

            else if (dataType == "Fairy")
            {
                instantiatedCapybara = Resources.Load<GameObject>("CapivaraFada");
                if (instantiatedCapybara != null) Instantiate(instantiatedCapybara);
            }

            else if (dataType == "Psychic")
            {
                instantiatedCapybara = Resources.Load<GameObject>("CapivaraPsiquica");
                if (instantiatedCapybara != null) Instantiate(instantiatedCapybara);
            }

            else if (dataType == "Ghost")
            {
                instantiatedCapybara = Resources.Load<GameObject>("CapivaraFantasma");
                if (instantiatedCapybara != null) Instantiate(instantiatedCapybara);
            }            
        }
    }
}
