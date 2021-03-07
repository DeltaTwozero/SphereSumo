using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> playerList;

    private void Start()
    {
        playerList = new List<GameObject>();

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            playerList.Add(player);
        }
    }

    public void RemovePlayer(GameObject gameObject)
    {
        playerList.Remove(gameObject);
        print(gameObject.name + " was destroyed");
    }
}
