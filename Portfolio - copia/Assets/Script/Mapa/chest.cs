using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chest : MonoBehaviour
{
    public enum objeto { chest, reading };
    public objeto obj;
    public bool interactuable = false;
    private bool abierto = false;

    //UI
    public GameObject readingUI;
    public GameObject lootUI;

    //Loot
    public GameObject[] loot = new GameObject[5];
    public Image[] lootSlotUI = new Image[5];

    private void Awake()
    {
        readingUI.SetActive(false);
    }

    private void Update()
    {
        if (interactuable == true && Input.GetKey(KeyCode.E))
        {
            switch (obj)
            {
                case objeto.chest:
                    if (abierto == false)
                    {
                        chestF();
                        abierto = true;
                    }
                    
                    break;
                case objeto.reading:
                    readingUI.SetActive(true);
                    break;
                default:
                    break;
            }
        }
        if (lootUI.active == true && Input.GetKeyDown(KeyCode.Escape))
        {
            lootUI.SetActive(false);
        }
    }

    private void chestF()
    {
        int rand = Random.Range(1, 5);
        Debug.Log(rand);
        lootUI.SetActive(true);
        for (int i = 0; i < rand; i++)
        {
            int randL = Random.Range(0, 2);
            lootSlotUI[i].sprite = loot[randL].GetComponent<SpriteRenderer>().sprite;
        }
        for (int i = 0; i < lootSlotUI.Length; i++)
        {
            
            if (lootSlotUI[i].sprite == null)
            {
                lootSlotUI[i].color = new Color32(54, 22, 8, 255);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            interactuable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            interactuable = false;
    }

    public Sprite addToInv(string obj)
    {
        for (int i = 0; i < loot.Length; i++)
        {
            if (loot[i].GetComponent<SpriteRenderer>().sprite.name == obj)
            {
                Sprite lotRet = loot[i].GetComponent<SpriteRenderer>().sprite;
                return lotRet;
            }
        }
        return null;
        
    }

}
