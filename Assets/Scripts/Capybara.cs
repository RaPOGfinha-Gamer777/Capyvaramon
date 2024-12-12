using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Capybara : MonoBehaviour
{
    [Header ("ATRIBUTOS DA CAPIVARA")]

    public string capybaraName; // caso de tempo de customizar o nome
    public string type; // elemento
    public string state; // se e selvagem, do jogador ou de treinador
    public int health; // vida
    public int strenght; // força no ataque
    public int speed; // pra ver quem inicia na batalha
    public int weaknessMultiplier = 1; // critico de fraqueza MULTIPLICA
    public int resistenceMultiplier = 1; // resistencia DIVIDE

    public int capybaraXP;
    public int capybaraLevel;

    protected bool isFainted;
    protected bool isBurned;
    protected bool isParalyzed;

    private void OnEnable()
    {
        if (IsCurrentScene("TestesBatalha"))
        {
            if (WildData.instance.dataState == "Wild") SetWildStats();
        }
    }

    private bool IsCurrentScene(string sceneName)
    {
        return SceneManager.GetActiveScene().name == sceneName;
    }

    void SetWildStats()
    {
        this.capybaraName = WildData.instance.dataName;
        this.type = WildData.instance.dataType;
        this.health = WildData.instance.dataHealth;
        this.state = WildData.instance.dataState;
        this.strenght = WildData.instance.dataStrenght;
        this.speed = WildData.instance.dataSpeed;
        this.weaknessMultiplier = WildData.instance.dataWeaknessMultiplier;
        this.resistenceMultiplier = WildData.instance.dataResistenceMultiplier;
    }
}
