using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildData : MonoBehaviour
{
    public string dataName;

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
        }
    }
}
