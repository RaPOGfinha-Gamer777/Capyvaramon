using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : Capybara
{
    private void Start()
    {
        this.capybaraName = "Fire Capybara";
        this.type = "Fire";

        this.firstAttackName = "Fire Blast";
        this.thirdAttackName = "Lava Burst";
        this.fourthAttackName = "Magma Pulse";
    }

    public override void UseFirstAttack()
    {
        base.UseFirstAttack();

        Battle battle = FindAnyObjectByType<Battle>();
        Capybara other = battle.activeEnemy.GetComponent<Capybara>();

        if (other.type == "Grass") this.weaknessMultiplier = 2;

        else if (other.type == "Psychic") this.resistance = 30;

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

        if (other.type == "Grass") this.weaknessMultiplier = 2;

        else if (other.type == "Psychic") this.resistance = 30;

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
