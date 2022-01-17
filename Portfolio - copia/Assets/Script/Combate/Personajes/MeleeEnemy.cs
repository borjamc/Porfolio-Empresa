using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Fighter
{
    private void Start()
    {
        speed = 4;
        lvl = 2;
        currentHealth = 30;
        name = "Pol";
        lvlUI.text = "lvl: " + lvl;
        nameUI.text = name;
        healthUI.maxValue = maxHealth;
        healthUI.value = currentHealth;
    }
}
