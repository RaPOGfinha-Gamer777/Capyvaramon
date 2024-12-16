using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class WildData : MonoBehaviour
{
    public static WildData instance;

    public string dataName;
    public string dataType;
    public string dataState;
    public int dataHealth;
    public int dataStrenght;
    public int dataSpeed;
    public int dataLevel;
    public int dataXp;

    public int dataWeaknessMultiplier;
    public int dataResistenceMultiplier;

    public bool dataCanUseFirstAttack;
    public bool dataCanUseSecondAttack;
    public bool dataCanUseThirdAttack;
    public bool dataCanUseFourthAttack;

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

    public void GetCapybaraStats(RaycastHit2D wildCapivara)
    {
        Capybara other = wildCapivara.collider.gameObject.GetComponent<Capybara>();

        if (other != null)
        {
            dataName = other.capybaraName;
            dataType = other.type;
            dataState = other.state;
            dataHealth = other.health;
            dataStrenght = other.strenght;
            dataSpeed = other.speed;

            dataLevel = other.capybaraLevel;
            dataXp = other.capybaraXP;

            dataWeaknessMultiplier = other.weaknessMultiplier;
            dataResistenceMultiplier = other.resistance;

            dataCanUseFirstAttack = other.canUseFirstAttack;
            dataCanUseSecondAttack = other.canUseSecondAttack;
            dataCanUseThirdAttack = other.canUseThirdAttack;
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
        if (scene.name == "BattleScene")
        {
            if (dataType == "Water")
            {
                instantiatedCapybara = Resources.Load<GameObject>("CapivaraAgua");
                if (instantiatedCapybara != null) Instantiate(instantiatedCapybara, new Vector3(5.52f, 1.78f, 0), Quaternion.identity); // posicao do inimigo na tela
            }

            else if (dataType == "Fire")
            {
                instantiatedCapybara = Resources.Load<GameObject>("CapivaraFogo");
                if (instantiatedCapybara != null) Instantiate(instantiatedCapybara, new Vector3(5.52f, 1.78f, 0), Quaternion.identity); // posicao do inimigo na tela
            }

            else if (dataType == "Grass")
            {
                instantiatedCapybara = Resources.Load<GameObject>("CapivaraPlanta");
                if (instantiatedCapybara != null) Instantiate(instantiatedCapybara, new Vector3(5.52f, 1.78f, 0), Quaternion.identity); // posicao do inimigo na tela
            }

            else if (dataType == "Normal")
            {
                instantiatedCapybara = Resources.Load<GameObject>("CapivaraNormal");
                if (instantiatedCapybara != null) Instantiate(instantiatedCapybara, new Vector3(5.52f, 1.78f, 0), Quaternion.identity); // posicao do inimigo na tela
            }

            else if (dataType == "Fairy")
            {
                instantiatedCapybara = Resources.Load<GameObject>("CapivaraFada");
                if (instantiatedCapybara != null) Instantiate(instantiatedCapybara, new Vector3(5.52f, 1.78f, 0), Quaternion.identity); // posicao do inimigo na tela
            }

            else if (dataType == "Psychic")
            {
                instantiatedCapybara = Resources.Load<GameObject>("CapivaraPsiquica");
                if (instantiatedCapybara != null) Instantiate(instantiatedCapybara, new Vector3(5.52f, 1.78f, 0), Quaternion.identity); // posicao do inimigo na tela
            }

            else if (dataType == "Ghost")
            {
                instantiatedCapybara = Resources.Load<GameObject>("CapivaraFantasma");
                if (instantiatedCapybara != null) Instantiate(instantiatedCapybara, new Vector3(5.52f, 1.78f, 0), Quaternion.identity); // posicao do inimigo na tela
            }
        }

        if (scene.name == "GameScene")
        {
            dataName = null;
            dataType = null;
            dataState = null;
            dataHealth = 0;
            dataStrenght = 0;
            dataSpeed = 0;
            dataWeaknessMultiplier = 0;
            dataResistenceMultiplier = 0;

            dataCanUseFirstAttack = false;
            dataCanUseSecondAttack = false;
            dataCanUseThirdAttack = false;
            dataCanUseFourthAttack = false;
        }
    }
}
