using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Capybara : MonoBehaviour
{
    [Header ("ATRIBUTOS DA CAPIVARA")]

    [SerializeField] protected string capName; // caso de tempo de customizar o nome
    [SerializeField] protected string type; // elemento
    [SerializeField] protected float health; // vida
    [SerializeField] protected float strenght; // força no ataque
    [SerializeField] protected float speed; // pra ver quem inicia na batalha
    [SerializeField] protected float weaknessMultiplier = 1; // critico de fraqueza MULTIPLICA
    [SerializeField] protected float resistenceMultiplier = 1; // resistencia DIVIDE

    protected bool isFainted;
    protected bool isBurned;
    protected bool isParalyzed;


    public virtual void Attack()
    {
        if (isParalyzed || isFainted) return;
    }

    public virtual void TakingDamage(float damage)
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
