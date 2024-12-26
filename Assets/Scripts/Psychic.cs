using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Psychic : Capybara
{
    private void Start()
    {
        this.capybaraName = "Psychic Capybara";
        this.type = "Psychic";

        this.firstAttackName = "Psybeam";
        this.thirdAttackName = "Cosmic Power";
        this.fourthAttackName = "Hypnosis";
    }

    public override void UseFirstAttack()
    {
        base.UseFirstAttack();

        Capybara other;

        other = CheckOpp();

        if (other.type == "Fairy") this.weaknessMultiplier = 2;

        else if (other.type == "Grass") this.resistance = 30;

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

        if (other.type == "Fairy") this.weaknessMultiplier = 2;

        else if (other.type == "Grass") this.resistance = 30;

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
