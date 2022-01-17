using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeAlly : Fighter
{
    private void Start()
    {
        speed = 3;
        lvl = 3;
        currentHealth = 50;
        name = "jojo";
        habilidad1 = "puñetazo";
        habilidad2 = "puñetazo 2";
        habilidad3 = "puñetazo 3";
        habilidad4 = "puñetazo 4";


        lvlUI.text = "lvl: " + lvl;
        nameUI.text = name;
        healthUI.maxValue = maxHealth;
        healthUI.value = currentHealth;

        

    }

    
}
