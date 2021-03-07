using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Movement : MonoBehaviour
{
    //Reference to Game Manager
    [SerializeField] GameManager gameManager;

    //Reference to Death Check
    [SerializeField] DeathCheck deathCheck;

    //AI varibales
    [SerializeField] NavMeshAgent myAgent;
    [SerializeField] GameObject myTarget;
    private bool isAbleToMove;
    bool isDead;
    int colCount;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        StartCoroutine("CoroutineGetTarget");
    }

    private void Update()
    {
        isDead = deathCheck.GetIsDead();

        if(isDead)
            myAgent.updatePosition = false;

        if(myTarget == null)
        {
            GetTarget();
        }
    }

    private void FixedUpdate()
    {
        if(myAgent.isActiveAndEnabled && isAbleToMove)
            myAgent.destination = myTarget.transform.position;
    }

    public void CanMove(bool canIMove, bool disableForever)
    {
        isAbleToMove = canIMove;
        myAgent.enabled = canIMove;

        if(!disableForever)
            StartCoroutine("ResetMovementBool");
    }

    //Immediate target acquisition
    void GetTarget()
    {
        myTarget = gameManager.GetRandomTarget();

        //if (myTarget = this.gameObject)
        //    GetTarget();
    }

    IEnumerator ResetMovementBool()
    {
        //Activating player movement
        yield return new WaitForSeconds(1f);
        isAbleToMove = true;
        myAgent.enabled = true;
    }

    //Delayed target acquisition
    IEnumerator CoroutineGetTarget()
    {
        yield return new WaitForSeconds(.2f);
        myTarget = gameManager.GetRandomTarget();

        /*if(myTarget == this.gameObject)
            GetTarget();*/

        print(myTarget.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            colCount++;

            if(colCount >= 3)
            {
                GetTarget();
            }
        }
    }

    private void OnDestroy()
    {
        gameManager.RemovePlayer(this.gameObject);
    }
}
