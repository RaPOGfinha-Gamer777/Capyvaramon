using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Capybara : MonoBehaviour
{
    [Header ("CAPYBARAS' STATS")]

    public string capybaraName; // caso de tempo de customizar o nome
    public string type; // elemento
    public string state; // se e selvagem, do jogador ou de treinador
    public int health; // vida
    public int strenght; // força no ataque
    public int speed; // pra ver quem inicia na batalha
    public int weaknessMultiplier = 1; // critico de fraqueza MULTIPLICA
    public int resistence = 0; // resistencia SUBTRAI

    public int capybaraLevel = 1;
    public int capybaraXP;

    protected bool isFainted;
    protected bool isBurned;
    protected bool isParalyzed;

    protected string firstAttackName;
    protected string secondAttackName;
    protected string thirdAttackName;

    public bool canUseFirstAttack;
    public bool canUseSecondAttack;
    public bool canUseThirdAttack;

    private void OnEnable()
    {
        if (IsCurrentScene("BattleScene"))
        {
            if (WildData.instance.dataState == "Wild")
            {
                SetWildStats();
            }
        }
    }

    // /////////////////////////////////////////////////////////////////////////

    public virtual void UseFirstAttack()
    {
        if (isFainted || isParalyzed || !canUseFirstAttack) return;
    }

    public virtual void UseSecondAttack()
    {
        if (isFainted || isParalyzed || !canUseSecondAttack) return;
    }

    public virtual void UseThirdAttack()
    {
        if (isFainted || isParalyzed || !canUseThirdAttack) return;
    }

    public virtual void TakeDamage(int  damage)
    {
        health -= (damage * weaknessMultiplier) - resistence;
        isFainted = health <= 0;
    }

    // ////////////////////////////////////////////////////////////////////////////////

    public void AddXP(int xpGainded)
    {
        this.capybaraXP += xpGainded;
        CalculateEarnedXp();
    }

    protected void CalculateEarnedXp() // acionar esse metodo ao ganhar xp em batalhas
    {
        while (this.capybaraXP >= 25)
        {
            this.capybaraXP -= 25;
            this.capybaraLevel++;
        }
        CheckAvailableAttacks();
    }

    protected void CheckAvailableAttacks()
    {
        if (this.capybaraLevel >= 1) this.canUseFirstAttack = true;
        if (this.capybaraLevel >= 5) this.canUseSecondAttack = true;
        if (this.capybaraLevel >= 15) this.canUseThirdAttack = true;
    }

    // /////////////////////////////////////////////////////////////////////////////////

    private bool IsCurrentScene(string sceneName)
    {
        return SceneManager.GetActiveScene().name == sceneName;
    }

    public void SetWildStats()
    {
        this.capybaraName = WildData.instance.dataName;
        this.type = WildData.instance.dataType;
        this.health = WildData.instance.dataHealth;
        this.state = WildData.instance.dataState;
        this.strenght = WildData.instance.dataStrenght;
        this.speed = WildData.instance.dataSpeed;

        this.capybaraLevel = WildData.instance.dataLevel;
        this.capybaraXP = WildData.instance.dataXp;

        this.weaknessMultiplier = WildData.instance.dataWeaknessMultiplier;
        this.resistence = WildData.instance.dataResistenceMultiplier;

        this.canUseFirstAttack = WildData.instance.dataCanUseFirstAttack;
        this.canUseSecondAttack = WildData.instance.dataCanUseSecondAttack;
        this.canUseThirdAttack = WildData.instance.dataCanUseThirdAttack;
    }
}
