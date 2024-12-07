using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildData : MonoBehaviour
{
    public string capybaraName;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Teste(RaycastHit2D wildCapivara)
    {
        capybaraName = wildCapivara.collider.gameObject.name;
    }
}
