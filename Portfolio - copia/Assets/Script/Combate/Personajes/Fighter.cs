using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fighter : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth = 100;
    public float dmg = 20;
    public float critProb = 15;
    public string name;
    public int lvl;
    public int speed;
    public float armor = 0;
    public bool taunted = false;

    public string habilidad1;
    public string habilidad2;
    public string habilidad3;
    public string habilidad4;

    public bool turnoTerminado = false;
    public bool turnoActual = false;

    public Text nameUI;
    public Slider healthUI;
    public Text lvlUI;
    public Button h1;
    public Button h2;
    public Button h3;
    public Button h4;

    public Text textSpeedUI;
    public Text textDmUI;
    public Text textHealthUI;
    public Text textCritProb;
    public GameObject statsContainer;
    public GameObject enemySelectedUI;

    public ManagerCombate mang;

    public void Start()
    {
        healthUI.maxValue = maxHealth;
        healthUI.value = currentHealth;
    }

    public void reciveDMG(float dmg)
    {
        this.currentHealth -= (dmg-armor);
        healthUI.value = currentHealth;
    }

    public void changeHab()
    {
        this.h1.GetComponentInChildren<Text>().text = habilidad1;
        this.h2.GetComponentInChildren<Text>().text = habilidad2;
        this.h3.GetComponentInChildren<Text>().text = habilidad3;
        this.h4.GetComponentInChildren<Text>().text = habilidad4;
    }

    public void OnMouseOver()
    {
        statsContainer.active = true;
        this.textCritProb.text = "" + critProb;
        this.textHealthUI.text = "" + currentHealth+"/"+maxHealth;
        this.textDmUI.text = "" + dmg;
        this.textSpeedUI.text = "" + speed;
    }

    public void OnMouseExit()
    {
        statsContainer.active=false;
    }
    public void useAbility(int i, GameObject enemySelected, List<GameObject> allEnemys)
    {
        switch (i)
        {
            case 1:
                if (this.gameObject.name.EndsWith("Ranged", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    this.gameObject.GetComponent<RangedAlly>().Habilidad1(enemySelected);
                }
                else if (this.gameObject.name.EndsWith("Mele", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    this.gameObject.GetComponent<MeleeAlly>().Habilidad1(enemySelected);
                }
                
                break;

            case 2:
                if (this.gameObject.name.EndsWith("Ranged", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    this.gameObject.GetComponent<RangedAlly>().Habilidad2(allEnemys);
                }
                else if (this.gameObject.name.EndsWith("Mele", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    this.gameObject.GetComponent<MeleeAlly>().Habilidad2();
                }
                break;

            case 3:
                if (this.gameObject.name.EndsWith("Ranged", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    this.gameObject.GetComponent<RangedAlly>().Habilidad3(enemySelected);
                }
                else if (this.gameObject.name.EndsWith("Mele", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    this.gameObject.GetComponent<MeleeAlly>().Habilidad3(enemySelected);
                }
                break;

            case 4:
                if (this.gameObject.name.EndsWith("Ranged", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    this.gameObject.GetComponent<RangedAlly>().Habilidad4(enemySelected);
                }
                else if (this.gameObject.name.EndsWith("Mele", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    this.gameObject.GetComponent<MeleeAlly>().Habilidad4(enemySelected);
                }
                break;
        }
    }
    /*
    public void dmgEnemy(GameObject enemySelected)
    {
        if (this.gameObject.name.EndsWith("Ranged", System.StringComparison.CurrentCultureIgnoreCase))
        {
            this.gameObject.GetComponent<RangedEnemy>().Habilidad(enemySelected);
        }
        else
        {

        }
    }
    */

    public void enemyAbilty(List<GameObject> targets)
    {
        int random = Random.Range(0, targets.Count - 1);
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i].GetComponent<Fighter>().taunted)
            {
                int a = Random.Range(0, 100);
                if (a < 75)
                {
                    random = i;
                }
            }
        }
        targets[random].GetComponent<Fighter>().reciveDMG(dmg);
        mang.activePlayers.Remove(this.gameObject);
        mang.Check();
    }

}
