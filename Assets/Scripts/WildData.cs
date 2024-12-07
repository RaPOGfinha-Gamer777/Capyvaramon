using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildData : MonoBehaviour
{
    public string dataName;
    public string dataType;
    public int dataHealth;
    public int dataStrenght;
    public int dataSpeed;
    public int dataWeaknessMultiplier;
    public int dataResistenceMultiplier;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Teste(RaycastHit2D wildCapivara)
    {
        Capybara other = wildCapivara.collider.gameObject.GetComponent<Capybara>();

        if (other != null)
        {
            dataName = other.capybaraName;
            dataType = other.type;
            dataHealth = other.health;
            dataStrenght = other.strenght;
            dataSpeed = other.speed;
            dataWeaknessMultiplier = other.weaknessMultiplier;
            dataResistenceMultiplier = other.resistenceMultiplier;
        }
    }
}
