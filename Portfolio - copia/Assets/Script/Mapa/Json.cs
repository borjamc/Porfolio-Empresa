using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Json : MonoBehaviour
{
    public string objectDescriptionTitle;
    public string[] a = new string[2];
    public string saveData;

    public string[] Load(string nombre)
    {
        objectDescriptionTitle = nombre;
        switch (objectDescriptionTitle)
        {
            case "food":
                a[0] = "Comida";
                a[1] = "Comida para no puto morirte no se";
                break;

            case "coin":
                a[0] = "Dinero";
                a[1] = "Usalo para aumentar to dinero total";
                break;
        }
        return a;
    }

}
