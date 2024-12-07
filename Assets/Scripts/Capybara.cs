using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Capybara : MonoBehaviour
{
    [Header ("ATRIBUTOS DA CAPIVARA")]

    public string capybaraName; // caso de tempo de customizar o nome
    public string type; // elemento
    public int health; // vida
    public int strenght; // força no ataque
    public int speed; // pra ver quem inicia na batalha
    public int weaknessMultiplier = 1; // critico de fraqueza MULTIPLICA
    public int resistenceMultiplier = 1; // resistencia DIVIDE

    protected bool isFainted;
    protected bool isBurned;
    protected bool isParalyzed;


    public virtual void Attack()
    {
        if (isParalyzed || isFainted) return;
    }

    public virtual void TakingDamage(int damage)
    {
        health -= (strenght * weaknessMultiplier) / resistenceMultiplier;
        isFainted = health <= 0;
        if (isFainted) KnockOut();
    }

    public virtual void KnockOut()
    {
        Debug.Log(gameObject.name + " foi nocauteado!");
    }
}
