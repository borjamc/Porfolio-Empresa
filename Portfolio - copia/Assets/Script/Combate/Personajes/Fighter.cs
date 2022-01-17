using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fighter : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public int dmg = 20;
    public string name;
    public int lvl;
    public int speed;

    public string habilidad1;
    public string habilidad2;
    public string habilidad3;
    public string habilidad4;


    public Text nameUI;
    public Slider healthUI;
    public Text lvlUI;
    public Button h1;
    public Button h2;
    public Button h3;
    public Button h4;

    public void reciveDMG(int dmg)
    {
        this.currentHealth -= dmg;
    }

    public void changeHab()
    {
        this.h1.GetComponentInChildren<Text>().text = habilidad1;
        this.h2.GetComponentInChildren<Text>().text = habilidad2;
        this.h3.GetComponentInChildren<Text>().text = habilidad3;
        this.h4.GetComponentInChildren<Text>().text = habilidad4;
    }

}
