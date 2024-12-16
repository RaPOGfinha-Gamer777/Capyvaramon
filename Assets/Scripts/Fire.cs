using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Capybara
{
    private void Start()
    {
        this.capybaraName = "Fire Capybara";
        this.type = "Fire";
    }

    public override void UseFirstAttack()
    {
        base.UseFirstAttack();
        
        Battle battle = FindAnyObjectByType<Battle>();
        Capybara other = battle.activeEnemy.GetComponent<Capybara>();

        if (other.type == "Grass")
        {
            this.weaknessMultiplier = 2;
            Debug.Log("acertou na fraqueza");
        }
        else if (other.type == "Psychic")
        {
            this.resistence = 20; // resistencia base em todas as capivaras
            Debug.Log("acertou na resistencia");
        }

        other.TakeDamage(this.strenght, this.weaknessMultiplier, this.resistence);
    }

    public override void UseSecondAttack()
    {
        base.UseSecondAttack();
        Debug.Log("segundo ataque");
    }

    public override void UseThirdAttack()
    {
        base.UseThirdAttack();
        Debug.Log("terceiro ataque");
    }
}
