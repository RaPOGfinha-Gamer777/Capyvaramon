using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.LightingExplorerTableColumn;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;

    // MOVIMENTO //
    public Vector3 positionInGameScene;
    private GameObject player;

    // CAPIVARAS //
    public List<GameObject> allCapybaras;
    public List<GameObject> teamCapybaras;

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
        if (scene.name == "GameScene")
        {
            if (positionInGameScene != Vector3.zero)
            {
                player = GameObject.Find("Player");
                player.transform.position = positionInGameScene;          
            }
        }

        if (scene.name == "BattleScene")
        {
            foreach (var cap in teamCapybaras)
            {
                Capybara capybara = cap.GetComponent<Capybara>();

                switch (capybara.type)
                {
                    case "Fire":
                        GameObject capPrefab1 = Resources.Load<GameObject>("VisualFireSprite");
                        if (capPrefab1 != null) Instantiate(capPrefab1, new Vector3(-5f, -2f, 0), Quaternion.identity); // posicao das capivaras do jogador
                     
                        break;

                    case "Water":
                        GameObject capPrefab2 = Resources.Load<GameObject>("VisualWaterSprite");
                        if (capPrefab2 != null) Instantiate(capPrefab2, new Vector3(-5f, -2f, 0), Quaternion.identity); // posicao das capivaras do jogador

                        break;

                    case "Grass":
                        GameObject capPrefab3 = Resources.Load<GameObject>("VisualGrassSprite");
                        if (capPrefab3 != null) Instantiate(capPrefab3, new Vector3(-5f, -2f, 0), Quaternion.identity); // posicao das capivaras do jogador

                        break;

                    case "Normal":
                        GameObject capPrefab4 = Resources.Load<GameObject>("VisualNormalSprite");
                        if (capPrefab4 != null) Instantiate(capPrefab4, new Vector3(-5f, -2f, 0), Quaternion.identity); // posicao das capivaras do jogador

                        break;

                    case "Fairy":
                        GameObject capPrefab5 = Resources.Load<GameObject>("VisualFairySprite");
                        if (capPrefab5 != null) Instantiate(capPrefab5, new Vector3(-5f, -2f, 0), Quaternion.identity); // posicao das capivaras do jogador

                        break;

                    case "Psychic":
                        GameObject capPrefab6 = Resources.Load<GameObject>("VisualPsychicSprite");
                        if (capPrefab6 != null) Instantiate(capPrefab6, new Vector3(-5f, -2f, 0), Quaternion.identity); // posicao das capivaras do jogador

                        break;

                    case "Ghost":
                        GameObject capPrefab7 = Resources.Load<GameObject>("VisualGhostSprite");
                        if (capPrefab7 != null) Instantiate(capPrefab7, new Vector3(-5f, -2f, 0), Quaternion.identity); // posicao das capivaras do jogador

                        break;
                }
            }

            Battle battle = FindAnyObjectByType<Battle>();
            battle.teamSprites = GameObject.FindGameObjectsWithTag("Visual");
        }
    }
}
