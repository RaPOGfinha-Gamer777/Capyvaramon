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
                Debug.Log(capybara.type);
            }
        }
    }
}
