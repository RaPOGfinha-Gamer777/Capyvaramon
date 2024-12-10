using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterName;
    public string characterType;
    public int characterXP;

    public List<Capybara> capybarasInTeam;
    // lista de itens

    public virtual void Attack()
    {

    }

    public virtual void Retreat()
    {

    }

    public virtual void SwitchCapybara()
    {

    }
}