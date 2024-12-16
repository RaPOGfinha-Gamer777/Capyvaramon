using System.Collections;
using System.Collections.Generic;
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

        if (other.type == "Grass")
        {
            this.weaknessMultiplier = 2;
            Debug.Log("VERY EFFECTIVE!!!");
        }
        else if (other.type == "Psychic")
        {
            this.resistance = 20; // resistencia base em todas as capivaras
            Debug.Log("NOT VERY EFFECTIVE!!!");
        }

        other.TakeDamage(this.strenght, this.weaknessMultiplier, this.resistance);
    }

    public override void UseSecondAttack()
    {
        base.UseSecondAttack();

    }

    public override void UseThirdAttack()
    {
        base.UseThirdAttack();

    }

    public override void UseFourthAttack()
    {
        base.UseFourthAttack();

    }
}
