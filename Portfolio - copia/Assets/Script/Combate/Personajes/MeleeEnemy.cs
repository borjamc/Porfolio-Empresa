using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Fighter
{
    private void Awake()
    {
        speed = 7;
        lvl = 2;
        dmg = 15;
        critProb = 14;
        currentHealth = 100;
        name = "Pol";
        lvlUI.text = "lvl: " + lvl;
        nameUI.text = name;
        healthUI.maxValue = maxHealth;
        healthUI.value = currentHealth;
    }
}
