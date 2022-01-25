using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAlly : Fighter
{
    private void Awake()
    {
        speed = 15;
        lvl = 5;
        dmg = 25;
        critProb = 18f;
        currentHealth = 100;
        name = "cait";

        habilidad1 = "Tiro Fuerte";
        habilidad2 = "Tiro Penetrante";
        habilidad3 = "Metralleta";
        habilidad4 = "Esquive";

        lvlUI.text = "lvl: " + lvl;
        nameUI.text = name;
        healthUI.maxValue = maxHealth;
        healthUI.value = currentHealth;
    }

    //Daño base con mas probabilidad de critico
    public void Habilidad1(GameObject enemySelected)
    {
        int rand = Random.Range(0, 100);
        if (rand <= critProb+10)
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

    //Daña a todos los enemigos con un 30% del daño total
    public void Habilidad2(List<GameObject> allEnemys)
    {
        int rand = Random.Range(0, 100);
        for (int i = 0; i < allEnemys.Count; i++)
        {
            if (rand <= critProb)
            {
                allEnemys[i].GetComponent<Fighter>().reciveDMG((dmg * 1.5f) * 0.4f);
            }
            else
            {
                allEnemys[i].GetComponent<Fighter>().reciveDMG(dmg*0.4f);
            }
        }
        mang.activePlayers.Remove(this.gameObject);
        mang.Check();
    }

    //Daña entre 3 y 5 veces a un enemigo con un 30% del daño total
    public void Habilidad3(GameObject enemySelected)
    {
        int randH = Random.Range(3, 5);
        int rand = Random.Range(0, 100);
        for (int i = 0; i < randH; i++)
        {
            if (rand <= critProb)
            {
                enemySelected.GetComponent<Fighter>().reciveDMG((dmg * 1.5f) * 0.3f);
            }
            else
            {
                enemySelected.GetComponent<Fighter>().reciveDMG(dmg*0.3f);
            }
        }
        mang.activePlayers.Remove(this.gameObject);
        mang.Check();
    }

    //Esquiva los dos siguientes ataques
    public void Habilidad4(GameObject enemySelected)
    {
        int rand = Random.Range(0, 100);
        if (rand <= critProb + 10)
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
