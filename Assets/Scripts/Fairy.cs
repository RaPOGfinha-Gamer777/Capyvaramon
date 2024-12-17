using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : Capybara
{
    private void Start()
    {
        this.capybaraName = "Fairy Capybara";
        this.type = "Fairy";

        this.firstAttackName = "Magic Hits";
        this.thirdAttackName = "Sweet Kiss";
        this.fourthAttackName = "Pink Miracle";
    }

    public override void UseFirstAttack()
    {
        base.UseFirstAttack();

        Battle battle = FindAnyObjectByType<Battle>();
        Capybara other = battle.activeEnemy.GetComponent<Capybara>();

        if (other.type == "Ghost")
        {
            this.weaknessMultiplier = 2;
            Debug.Log("VERY EFFECTIVE!!!");
        }
        else if (other.type == "Water")
        {
            this.resistance = 30; // resistencia base em todas as capivaras
            Debug.Log("NOT VERY EFFECTIVE!!!");
        }

        this.powerPoints -= this.firstAttackCost;

        other.TakeDamage(this.strenght, this.weaknessMultiplier, this.resistance);
    }

    public override void UseSecondAttack()
    {
        base.UseSecondAttack();

        Battle battle = FindAnyObjectByType<Battle>();
        Capybara other = battle.activeEnemy.GetComponent<Capybara>();

        this.powerPoints -= this.secondAttackCost;

        int damage = CalculateDamage(this.strenght, 0.75f);
        other.TakeDamage(damage, this.weaknessMultiplier, this.resistance);
    }

    public override void UseThirdAttack()
    {
        base.UseThirdAttack();

        Battle battle = FindAnyObjectByType<Battle>();
        Capybara other = battle.activeEnemy.GetComponent<Capybara>();

        if (other.type == "Water")
        {
            this.weaknessMultiplier = 2;
            Debug.Log("VERY EFFECTIVE!!!");
        }
        else if (other.type == "Fairy")
        {
            this.resistance = 30; // resistencia base em todas as capivaras
            Debug.Log("NOT VERY EFFECTIVE!!!");
        }

        this.powerPoints -= this.thirdAttackCost;

        int damage = CalculateDamage(this.strenght, 1.5f);
        other.TakeDamage(damage, this.weaknessMultiplier, this.resistance);
    }

    public override void UseFourthAttack()
    {
        base.UseFourthAttack();
        Debug.Log("SPECIAL MOVE!!!");
    }
}
