using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fairy : Capybara
{
    private void Start()
    {
        this.capybaraName = "Fairy Capybara";
        this.type = "Fairy";

        this.firstAttackName = "Magic Hit";
        this.thirdAttackName = "Sweet Kiss";
        this.fourthAttackName = "Pink Miracle";
    }

    public override void UseFirstAttack()
    {
        base.UseFirstAttack();

        Battle battle = FindAnyObjectByType<Battle>();
        Capybara other = battle.activeEnemy.GetComponent<Capybara>();

        if (other.type == "Ghost") this.weaknessMultiplier = 2;

        else if (other.type == "Water") this.resistance = 30;

        this.powerPoints -= this.firstAttackCost;

        SendDamageEffectivenessText(this.weaknessMultiplier, this.resistance);

        other.TakeDamage(this.strenght, this.weaknessMultiplier, this.resistance);
    }

    public override void UseSecondAttack()
    {
        base.UseSecondAttack();

        Battle battle = FindAnyObjectByType<Battle>();
        Capybara other = battle.activeEnemy.GetComponent<Capybara>();

        this.powerPoints -= this.secondAttackCost;

        SendDamageEffectivenessText(this.weaknessMultiplier, this.resistance);

        int damage = CalculateDamage(this.strenght, 0.75f);
        other.TakeDamage(damage, this.weaknessMultiplier, this.resistance);
    }

    public override void UseThirdAttack()
    {
        base.UseThirdAttack();

        Battle battle = FindAnyObjectByType<Battle>();
        Capybara other = battle.activeEnemy.GetComponent<Capybara>();

        if (other.type == "Ghost") this.weaknessMultiplier = 2;

        else if (other.type == "Water") this.resistance = 30;

        this.powerPoints -= this.thirdAttackCost;

        SendDamageEffectivenessText(this.weaknessMultiplier, this.resistance);

        int damage = CalculateDamage(this.strenght, 1.5f);
        other.TakeDamage(damage, this.weaknessMultiplier, this.resistance);
    }

    public override void UseFourthAttack()
    {
        base.UseFourthAttack();

        SendDamageEffectivenessText(this.weaknessMultiplier, this.resistance);
    }
}
