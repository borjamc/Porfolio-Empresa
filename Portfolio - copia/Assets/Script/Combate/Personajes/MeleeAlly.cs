using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeAlly : Fighter
{

    private void Awake()
    {
        armor = 3;
        speed = 3;
        lvl = 3;
        dmg = 20;
        critProb = 20;
        currentHealth = 100;
        name = "jojo";
        habilidad1 = "Puñetazo";
        habilidad2 = "Fortaleza";
        habilidad3 = "Taunt";
        habilidad4 = "puñetazo 4";


        lvlUI.text = "lvl: " + lvl;
        nameUI.text = name;
        healthUI.maxValue = maxHealth;
        healthUI.value = currentHealth;
    }

    //Daño base con mas probabilidad de critico
    public void Habilidad1(GameObject enemySelected)
    {
        int rand = Random.Range(0, 100);
        if (rand <= critProb + 5)
        {
            enemySelected.GetComponent<Fighter>().reciveDMG(dmg * 1.5f);
        }
        else
        {
            enemySelected.GetComponent<Fighter>().reciveDMG(dmg);
        }
        mang.activePlayers.Remove(this.gameObject);
        mang.Check();
    }

    //Aumenta la armadura
    public void Habilidad2()
    {
        armor += 2;
        mang.activePlayers.Remove(this.gameObject);
        mang.Check();
    }

    //Aumenta las probabilidades de que le peguen a el
    public void Habilidad3(GameObject enemySelected)
    {
        taunted = true;
        mang.activePlayers.Remove(this.gameObject);
        mang.Check();
    }

    //??
    public void Habilidad4(GameObject enemySelected)
    {
        int rand = Random.Range(0, 100);
        if (rand <= critProb + 5)
        {
            enemySelected.GetComponent<Fighter>().reciveDMG(dmg * 1.5f);
        }
        else
        {
            enemySelected.GetComponent<Fighter>().reciveDMG(dmg);
        }
        mang.activePlayers.Remove(this.gameObject);
        mang.Check();
    }

}
