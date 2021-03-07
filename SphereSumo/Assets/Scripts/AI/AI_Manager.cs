using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Manager : MonoBehaviour
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
}
