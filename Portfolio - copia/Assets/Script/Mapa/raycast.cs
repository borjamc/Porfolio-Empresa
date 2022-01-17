using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class raycast : MonoBehaviour
{
    //RayCast
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    //UI
    public Image[] invUI = new Image[10];


    private string[] loot = new string[2];

    //Referencias a otros scripts
    public chest lootScript;
    public manager managerController;

    void Start()
    {
        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();

        loot[0] = "food";
        loot[1] = "coin";
    }



    void Update()
    {

        //Set up the new Pointer Event
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();

        m_Raycaster.Raycast(m_PointerEventData, results);


        foreach (RaycastResult result in results)
        {
            if (result.gameObject.tag == "inv" && result.gameObject.GetComponent<Image>().sprite != null)
            {
                managerController.pruebaJSON(results[0].gameObject.GetComponent<Image>().sprite.name);

                if (Input.GetMouseButtonDown(0))
                {
                    #region UseItem
                    if (results[0].gameObject.tag == "inv")
                    {
                        if (results[0].gameObject.GetComponent<Image>().sprite.name == loot[0])
                        {
                            //Funcion de comida;
                            vaciarSlot(results[0]);
                        }
                        else if (results[0].gameObject.GetComponent<Image>().sprite.name == loot[1])
                        {
                            managerController.addMoney(5);
                            vaciarSlot(results[0]);
                        }

                    }
                    #endregion
                }


                return;
            }
        }
        


        if (Input.GetMouseButtonDown(0))
        {
            #region LootFromChest
            if (results[0].gameObject.tag == "chest")
            {
                if (results[0].gameObject.GetComponent<Image>().sprite.name == loot[0])
                {
                    for (int i = 0; i < invUI.Length; i++)
                    {
                        if (invUI[i].GetComponent<Image>().sprite == null)
                        {
                            addToInv(loot[0], i);
                            vaciarSlot(results[0]);
                            return;
                        }
                    }

                }
                else if (results[0].gameObject.GetComponent<Image>().sprite.name == loot[1])
                {
                    for (int i = 0; i < invUI.Length; i++)
                    {
                        if (invUI[i].GetComponent<Image>().sprite == null)
                        {
                            addToInv(loot[1], i);
                            vaciarSlot(results[0]);
                            return;
                        }
                    }
                }
            }
            #endregion
        }
    }

    private void vaciarSlot(RaycastResult result)
    {
        result.gameObject.GetComponent<Image>().sprite = null;
        result.gameObject.GetComponent<Image>().color = new Color32(54, 22, 8, 255);
    }
    private void addToInv(string lootName, int i)
    {
        invUI[i].GetComponent<Image>().sprite = lootScript.addToInv(lootName);
        invUI[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }

}
