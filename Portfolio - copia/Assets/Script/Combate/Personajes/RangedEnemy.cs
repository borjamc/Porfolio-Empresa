using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Fighter
{
    private void Start()
    {
        speed = 2;
        lvl = 3;
        currentHealth = 50;
        name = "juan";
        lvlUI.text = "lvl: " + lvl;
        nameUI.text = name;
        healthUI.maxValue = maxHealth;
        healthUI.value = currentHealth;
    }
}
