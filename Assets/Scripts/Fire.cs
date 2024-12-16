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
        Debug.Log("primeiro ataque");
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
