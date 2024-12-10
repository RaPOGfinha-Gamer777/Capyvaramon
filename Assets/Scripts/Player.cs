using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public static Player instance;

    [SerializeField] protected List<Capybara> allCapybaras;

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

    private void Start()
    {
        this.characterName = "Jorge";
        this.characterType = "Player";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            CaptureWildCapybara();
        }
    }

    void CaptureWildCapybara()
    {
        Capybara wildCapybara = FindAnyObjectByType<Capybara>();

        if (wildCapybara != null)
        {
            
        }
    }
}
