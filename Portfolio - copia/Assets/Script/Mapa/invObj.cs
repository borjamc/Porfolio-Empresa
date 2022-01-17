using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invObj : MonoBehaviour
{
    public TopDownCharacterController Player;
    void Update()
    {
        if ((transform.position - Camera.main.transform.position).sqrMagnitude < Player.distanceSquared)
        {
            //Make it transparent: e.g.
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
