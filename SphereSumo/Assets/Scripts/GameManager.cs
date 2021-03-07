using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> playerList;
    GameObject randomTarget;

    private void Start()
    {
        playerList = new List<GameObject>();

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            playerList.Add(player);
        }
    }

    public GameObject GetRandomTarget()
    {
        int random = Random.Range(0, playerList.Count);
        print(random);
        randomTarget = playerList[random];

        return randomTarget;
    }

    public void RemovePlayer(GameObject gameObject)
    {
        playerList.Remove(gameObject);
        //print(gameObject.name + " was destroyed");
    }
}
