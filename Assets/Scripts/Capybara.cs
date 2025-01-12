using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using static Unity.Burst.Intrinsics.X86.Avx;
using JetBrains.Annotations;

public class Capybara : MonoBehaviour
{
    [Header ("CAPYBARAS' STATS")]

    public string capybaraName; // caso de tempo de customizar o nome
    public string type; // elemento
    public string state; // se e selvagem, do jogador ou de treinador
    public int maxHealth;
    public int health; // vida
    public int strenght; // for�a no ataque
    public int speed; // pra ver quem inicia na batalha
    public int weaknessMultiplier = 1; // critico de fraqueza MULTIPLICA
    public int resistance = 0; // resistencia SUBTRAI

    public int capybaraLevel = 1;
    public int capybaraXP;

    [HideInInspector] public bool isFainted;
    [HideInInspector] public bool isBurned;
    [HideInInspector] public bool isParalyzed;

    [HideInInspector] public string firstAttackName;
    [HideInInspector] public string secondAttackName = "Tackle"; // ataque default de todas capivaras
    [HideInInspector] public string thirdAttackName;
    [HideInInspector] public string fourthAttackName;

    [HideInInspector] public string firstAttackType;
    [HideInInspector] public string secondAttackType = "Normal"; // todas tem o segundo ataque do tipo normal
    [HideInInspector] public string thirdAttackType;
    [HideInInspector] public string fourthAttackType;

    public bool canUseFirstAttack;
    public bool canUseSecondAttack;
    public bool canUseThirdAttack;
    public bool canUseFourthAttack;

    public int firstAttackCost;
    public int secondAttackCost;
    public int thirdAttackCost;
    public int fourthAttackCost;

    public int powerPoints; // custo para cada ataque
    public int maxPowerPoints;

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

    ///////////////////////////////////////////////////////////////////////////

    public virtual void UseFirstAttack()
    {
        if (isFainted || isParalyzed || !canUseFirstAttack || firstAttackCost > powerPoints) return;

        BattleUI battleUI = FindAnyObjectByType<BattleUI>();
        battleUI.UpdateOutputText(capybaraName + " used " + firstAttackName + "!");

        powerPoints -= firstAttackCost;
    }

    public virtual void UseSecondAttack()
    {
        if (isFainted || isParalyzed || !canUseSecondAttack || secondAttackCost > powerPoints) return;

        BattleUI battleUI = FindAnyObjectByType<BattleUI>();
        battleUI.UpdateOutputText(capybaraName + " used " + secondAttackName + "!");

        powerPoints -= secondAttackCost;
    }

    public virtual void UseThirdAttack()
    {
        if (isFainted || isParalyzed || !canUseThirdAttack || thirdAttackCost > powerPoints) return;

        BattleUI battleUI = FindAnyObjectByType<BattleUI>();
        battleUI.UpdateOutputText(capybaraName + " used " + thirdAttackName + "!");

        powerPoints -= thirdAttackCost;
    }

    public virtual void UseFourthAttack()
    {
        if (isFainted || isParalyzed || !canUseFourthAttack || fourthAttackCost > powerPoints) return;

        BattleUI battleUI = FindAnyObjectByType<BattleUI>();
        battleUI.UpdateOutputText(capybaraName + " used " + fourthAttackName + "!");

        powerPoints -= fourthAttackCost;
    }

    // // /// // // // // // // // // // // // // // // // // // // // // // // // // // // // // //

    protected Capybara CheckOpp()
    {
        Battle battle = FindAnyObjectByType<Battle>();
        Capybara other;

        if (this.state == "Players")
        {
            other = battle.activeEnemy.GetComponent<Capybara>();
            return other;
        }
        else if (this.state == "Wild")
        {
            other = battle.activeCapybara.GetComponent<Capybara>();
            return other;
        }
        else return null;
    }

    public virtual void TakeDamage(int  damage, int multiplier, int resist)
    {
        health -= (damage * multiplier) - resist;
        isFainted = health <= 0;

        if (isFainted)
        {
            health = 0;
            Invoke(nameof(Faint), 2.5f);
        }
    }

    protected int CalculateDamage(int strenght, float multiplier) // 0.75x para segundo ataque e 1.5x para terceiro ataque
    {
        float floatDamage = strenght * multiplier;
        int damage = Mathf.RoundToInt(floatDamage);
        return damage;
    }

    void Faint()
    {
        BattleUI battleUI = FindAnyObjectByType<BattleUI>();
        battleUI.UpdateOutputText(capybaraName + " was knocked out!");
        battleUI.UpdateEffectivenessText("");

        Battle battle = FindAnyObjectByType<Battle>();
        battle.DeactivateCapybara(this);
    }

    protected void SendDamageEffectivenessText(int weaknessMult, int resistance)
    {
        BattleUI battleUI = FindAnyObjectByType<BattleUI>();
        
        if (weaknessMult > 1)
        {
            battleUI.UpdateEffectivenessText("VERY EFFECTIVE!");
            Debug.Log("fraqueza");
        }
        if (resistance == 30)
        {
            battleUI.UpdateEffectivenessText("NOT VERY EFFECTIVE!");
            Debug.Log("resistencia");
        }
        else if (resistance == 0 && weaknessMult == 1)
        {
            battleUI.UpdateEffectivenessText("");
            Debug.Log("nada");
        }
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
        this.maxHealth = WildData.instance.dataMaxHealth;
        this.state = WildData.instance.dataState;
        this.strenght = WildData.instance.dataStrenght;
        this.speed = WildData.instance.dataSpeed;

        this.capybaraLevel = WildData.instance.dataLevel;
        this.capybaraXP = WildData.instance.dataXp;

        this.weaknessMultiplier = WildData.instance.dataWeaknessMultiplier;
        this.resistance = WildData.instance.dataResistence;

        this.canUseFirstAttack = WildData.instance.dataCanUseFirstAttack;
        this.canUseSecondAttack = WildData.instance.dataCanUseSecondAttack;
        this.canUseThirdAttack = WildData.instance.dataCanUseThirdAttack;
        this.canUseFourthAttack = WildData.instance.dataCanUseFourthAttack;

        this.firstAttackCost = WildData.instance.dataFirstAttackCost;
        this.secondAttackCost = WildData.instance.dataSecondAttackCost;
        this.thirdAttackCost = WildData.instance.dataThirdAttackCost;
        this.fourthAttackCost = WildData.instance.dataFourthAttackCost;

        this.powerPoints = WildData.instance.dataPowerPoints;
        this.maxPowerPoints = WildData.instance.dataMaxPowerPoints;
    }
}
