using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : Capybara
{
    private void Start()
    {
        this.capybaraName = "Grass Capybara";
        this.type = "Grass";

        this.firstAttackName = "Seed Throw";
        this.thirdAttackName = "Vine Slash";
        this.fourthAttackName = "Friendly Nature";
    }

    public override void UseFirstAttack()
    {
        base.UseFirstAttack();

        Capybara other;

        other = CheckOpp();

        if (other.type == "Water") this.weaknessMultiplier = 2;

        else if (other.type == "Fairy") this.resistance = 30;

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

        if (other.type == "Water") this.weaknessMultiplier = 2;

        else if (other.type == "Fairy") this.resistance = 30;

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
