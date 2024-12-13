using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Capybara
{
    private void Start()
    {
        this.capybaraName = "Ghost Capybara";
        this.type = "Ghost";
    }
}
