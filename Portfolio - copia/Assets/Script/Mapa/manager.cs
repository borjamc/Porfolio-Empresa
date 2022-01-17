using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour
{
    //UI
    public GameObject invUI;
    public Text moneyNumberUI;
    public Text objectDescriptionTitle;
    public Text objectDescriptionBody;

    //Referencia
    public Camera mainCamera;

    //Variables propias
    public int moneyNumber = 5;


    void Update()
    {
        //Activar od desactivar inventario UI
        if (Input.GetKeyDown(KeyCode.Tab))
            changeInv();
        if(Input.GetKeyDown(KeyCode.Escape) && invUI.active == true)
            invUI.SetActive(false);

    }

    public void changeMoneyUI()
    {
        moneyNumberUI.text = "" + moneyNumber;
    }

    public void addMoney(int money)
    {
        moneyNumber += money;
        changeMoneyUI();
    }

    private void changeInv()
    {
        if (invUI.active == true)
        {
            invUI.SetActive(false);
        }
        else
        {
            invUI.SetActive(true);
            changeMoneyUI();
        }
            
    }

    public void pruebaJSON(string nombre)
    {
        string[] obj;
        obj = gameObject.GetComponentInChildren<Json>().Load(nombre);
        objectDescriptionTitle.text = obj[0];
        objectDescriptionBody.text = obj[1];
    }

}
