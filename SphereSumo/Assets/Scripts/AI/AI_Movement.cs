using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Movement : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] NavMeshAgent myAgent;
    [SerializeField] GameObject player;

    private bool isAbleToMove;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        myAgent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        if(myAgent.isActiveAndEnabled)
            myAgent.destination = player.transform.position;
    }

    private void OnDestroy()
    {
        gameManager.RemovePlayer(this.gameObject);
    }

    public void CanMove(bool canIMove, bool disableForever)
    {
        isAbleToMove = canIMove;
        myAgent.enabled = canIMove;
        if(!disableForever)
            StartCoroutine("ResetMovementBool");
    }

    IEnumerator ResetMovementBool()
    {
        //Activating player movement
        yield return new WaitForSeconds(.5f);
        isAbleToMove = true;
        myAgent.enabled = true;
        //print(isAbleToMove);
    }
}
