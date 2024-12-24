using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal : Capybara
{
    private void Start()
    {
        this.capybaraName = "Normal Capybara";
        this.type = "Normal";

        this.firstAttackName = "Headbutt";
        this.thirdAttackName = "Bite";
        this.fourthAttackName = "Fortify";
    }

    public override void UseFirstAttack()
    {
        base.UseFirstAttack();
    }

    public override void UseSecondAttack()
    {
        base.UseSecondAttack();
    }

    public override void UseThirdAttack()
    {
        base.UseThirdAttack();

        Battle battle = FindAnyObjectByType<Battle>();
        Capybara other = battle.activeEnemy.GetComponent<Capybara>();

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
