using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WildData : MonoBehaviour
{
    public string dataName;
    public string dataType;
    public int dataHealth;
    public int dataStrenght;
    public int dataSpeed;
    public int dataWeaknessMultiplier;
    public int dataResistenceMultiplier;

    private void Awake()
    {
        DontDestroyOnLoad(this);
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
                GameObject obj = Resources.Load<GameObject>("CapivaraAgua");
                if (obj != null) Instantiate(obj);
            }

            else if (dataType == "Fire")
            {
                GameObject obj = Resources.Load<GameObject>("CapivaraFogo");
                if (obj != null) Instantiate(obj);
            }

            else if (dataType == "Grass")
            {
                GameObject obj = Resources.Load<GameObject>("CapivaraPlanta");
                if (obj != null) Instantiate(obj);
            }

            else if (dataType == "Normal")
            {
                GameObject obj = Resources.Load<GameObject>("CapivaraNormal");
                if (obj != null) Instantiate(obj);
            }

            else if (dataType == "Fairy")
            {
                GameObject obj = Resources.Load<GameObject>("CapivaraFada");
                if (obj != null) Instantiate(obj);
            }

            else if (dataType == "Psychic")
            {
                GameObject obj = Resources.Load<GameObject>("CapivaraPsiquica");
                if (obj != null) Instantiate(obj);
            }

            else if (dataType == "Ghost")
            {
                GameObject obj = Resources.Load<GameObject>("CapivaraFantasma");
                if (obj != null) Instantiate(obj);
            }
        }
    }
}
