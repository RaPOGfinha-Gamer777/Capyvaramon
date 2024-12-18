using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Capybara
{
    private void Start()
    {
        this.capybaraName = "Ghost Capybara";
        this.type = "Ghost";

        this.firstAttackName = "Shadow Hit";
        this.thirdAttackName = "Jumpscare";
        this.fourthAttackName = "Cowardice";
    }

    public override void UseFirstAttack()
    {
        base.UseFirstAttack();

        Battle battle = FindAnyObjectByType<Battle>();
        Capybara other = battle.activeEnemy.GetComponent<Capybara>();

        if (other.type == "Psychic") this.weaknessMultiplier = 2;

        else if (other.type == "Fire") this.resistance = 30;

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

        if (other.type == "Psychic") this.weaknessMultiplier = 2;

        else if (other.type == "Fire") this.resistance = 30;

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
