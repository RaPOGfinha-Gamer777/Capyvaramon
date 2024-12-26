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

        Capybara other;

        other = CheckOpp();
        other.TakeDamage(this.strenght, this.weaknessMultiplier, this.resistance);

        SendDamageEffectivenessText(this.weaknessMultiplier, this.resistance);
    }

    public override void UseSecondAttack()
    {
        base.UseSecondAttack();

        Capybara other;

        other = CheckOpp();
        int damage = CalculateDamage(this.strenght, 0.75f);
        other.TakeDamage(damage, this.weaknessMultiplier, this.resistance);

        SendDamageEffectivenessText(this.weaknessMultiplier, this.resistance);
    }

    public override void UseThirdAttack()
    {
        base.UseThirdAttack();

        Capybara other;

        other = CheckOpp();
        int damage = CalculateDamage(this.strenght, 1.5f);
        other.TakeDamage(damage, this.weaknessMultiplier, this.resistance);

        SendDamageEffectivenessText(this.weaknessMultiplier, this.resistance);
    }

    public override void UseFourthAttack()
    {
        base.UseFourthAttack();

        SendDamageEffectivenessText(this.weaknessMultiplier, this.resistance);
    }
}
