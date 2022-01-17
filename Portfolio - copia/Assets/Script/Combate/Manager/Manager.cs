using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public List<GameObject> players;

    private void Start()
    {
        foreach (Transform item in GameObject.FindGameObjectWithTag("GameController").GetComponentsInChildren<Transform>())
        {
            players.Add(item.gameObject);
        }
        for (int i = 0; i < players.Count; i++)
        {
            bool startsWithSearchResult = players[i].name.StartsWith("Player", System.StringComparison.CurrentCultureIgnoreCase);
            Debug.Log($"Start with 'Player'? {startsWithSearchResult}");

            bool endsWithSearchResult = players[i].name.EndsWith("Mele", System.StringComparison.CurrentCultureIgnoreCase);
            Debug.Log($"Ends with 'Mele'? {endsWithSearchResult}");
        }
        

    }
}
