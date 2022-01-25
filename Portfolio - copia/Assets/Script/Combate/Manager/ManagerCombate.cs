using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCombate : MonoBehaviour
{

    public List<GameObject> players;
    public List<GameObject> activePlayers;
    public GameObject activePlayer;
    public List<GameObject> allyFighters;
    public List<GameObject> enemyFighters;

    public GameObject selectedEnemy;

    private void Start()
    {
        foreach (Transform item in GameObject.FindGameObjectWithTag("GameController").GetComponentsInChildren<Transform>())
        {
            players.Add(item.gameObject);
        }
        players.Remove(players[0]);

        for (int i = 0; i < players.Count; i++)
        {
            activePlayers.Add(players[i]);
        }

        Check();
    }

    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.name.StartsWith("Enemy", System.StringComparison.CurrentCultureIgnoreCase))
            {
                if (selectedEnemy!= null)
                    selectedEnemy.GetComponent<Fighter>().enemySelectedUI.active = false;
                
                
                selectedEnemy = hit.collider.gameObject;
                selectedEnemy.GetComponent<Fighter>().enemySelectedUI.active = true;
            }
        }
    }

    #region Check Turn

    public void Check()
    {

        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].GetComponent<Fighter>().currentHealth <= 0)
            {
                if (players[i] == selectedEnemy)
                {
                    selectedEnemy.GetComponent<Fighter>().enemySelectedUI.active = false;
                    selectedEnemy = null;
                }
                GameObject destroy = players[i];
                players.Remove(players[i]);
                activePlayers.Remove(destroy);
                Destroy(destroy);
            }
        }

        activePlayer = checkTurn();
        if (activePlayer.name.StartsWith("Player", System.StringComparison.CurrentCultureIgnoreCase))
        {
            activePlayer.GetComponent<Fighter>().changeHab();
        }
        else
        {
            activePlayer.GetComponent<Fighter>().enemyAbilty(allyFighters);
        }
    }

    public GameObject checkTurn()
    {

        for (int a = 0; a < allyFighters.Count; a++)
        {
            allyFighters.Remove(allyFighters[a]);
        }
        for (int a = 0; a < enemyFighters.Count; a++)
        {
            enemyFighters.Remove(enemyFighters[a]);
        }

        for (int i = 0; i < activePlayers.Count; i++)
        {
            if (players[i].name.StartsWith("Player", System.StringComparison.CurrentCultureIgnoreCase))
            {
                allyFighters.Add(players[i]);
            }
            else if (players[i].name.StartsWith("Enemy", System.StringComparison.CurrentCultureIgnoreCase))
            {
                enemyFighters.Add(players[i]);
            }
        }
        if (activePlayers.Count == 0)
        {
            for (int i = 0; i < players.Count; i++)
            {
                activePlayers.Add(players[i]);
            }
            checkTurn();
        }
        return checkSpeedTurn(activePlayers);

    }

    private GameObject checkSpeedTurn(List<GameObject> actualTurn)
    {
        GameObject turn = actualTurn[0];
        for (int i = 1; i < actualTurn.Count; i++)
        {
            if (actualTurn[i].GetComponent<Fighter>().speed > turn.GetComponent<Fighter>().speed)
            {
                turn = actualTurn[i];
            }
            else
            {
                turn = actualTurn[0];
            }
        }
        return turn;
    }

    #endregion

    #region Habilidades
    public void Hability1()
    {
        if (activePlayer.name.StartsWith("Player", System.StringComparison.CurrentCultureIgnoreCase) && selectedEnemy != null)
        {
            activePlayer.GetComponent<Fighter>().useAbility(1, selectedEnemy, enemyFighters);
        }
    }
    public void Hability2()
    {
        if (activePlayer.name.StartsWith("Player", System.StringComparison.CurrentCultureIgnoreCase))
        {
            activePlayer.GetComponent<Fighter>().useAbility(2, selectedEnemy, enemyFighters);
        }
    }

    public void Hability3()
    {
        if (activePlayer.name.StartsWith("Player", System.StringComparison.CurrentCultureIgnoreCase) && selectedEnemy != null)
        {
            activePlayer.GetComponent<Fighter>().useAbility(3, selectedEnemy, enemyFighters);
        }
        else if (activePlayer.name.StartsWith("Player", System.StringComparison.CurrentCultureIgnoreCase) && activePlayer.name.EndsWith("Mele", System.StringComparison.CurrentCultureIgnoreCase))
        {
            Debug.Log("a");
            activePlayer.GetComponent<Fighter>().useAbility(3, selectedEnemy, enemyFighters);
        }
    }

    public void Hability4()
    {
        if (activePlayer.name.StartsWith("Player", System.StringComparison.CurrentCultureIgnoreCase) && selectedEnemy != null)
        {
            activePlayer.GetComponent<Fighter>().useAbility(4, selectedEnemy, enemyFighters);
        }
    }
    #endregion
}
