using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAlly : Fighter
{
    private void Start()
    {
        speed = 8;
        lvl = 5;
        currentHealth = 80;
        name = "cait";

        habilidad1 = "tiro 1";
        habilidad2 = "tiro 2";
        habilidad3 = "tiro 3";
        habilidad4 = "tiro 4";

        lvlUI.text = "lvl: " + lvl;
        nameUI.text = name;
        healthUI.maxValue = maxHealth;
        healthUI.value = currentHealth;

        changeHab();
    }
}
