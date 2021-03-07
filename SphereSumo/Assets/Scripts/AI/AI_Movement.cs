using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Movement : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] 

    private bool isAbleToMove;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnDestroy()
    {
        gameManager.RemovePlayer(this.gameObject);
    }

    public void CanMove(bool condition)
    {
        isAbleToMove = condition;
        StartCoroutine("ResetMovementBool");
    }

    IEnumerator ResetMovementBool()
    {
        //Activating player movement
        yield return new WaitForSeconds(.5f);
        isAbleToMove = true;
        //print(isAbleToMove);
    }
}
