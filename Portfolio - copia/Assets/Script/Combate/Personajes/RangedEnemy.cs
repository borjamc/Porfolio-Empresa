using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Fighter
{
    private void Awake()
    {
        speed = 2;
        lvl = 3;
        dmg = 20;
        critProb = 12.5f;
        currentHealth = 100;
        name = "juan";
        lvlUI.text = "lvl: " + lvl;
        nameUI.text = name;
        healthUI.maxValue = maxHealth;
        healthUI.value = currentHealth;
    }
}
