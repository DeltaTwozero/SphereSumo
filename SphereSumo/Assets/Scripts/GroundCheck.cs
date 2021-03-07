using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    bool isDead = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isDead = false;
            print(isDead);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isDead = true;
            print(isDead);
        }
    }

    public bool GetIsDead()
    {
        return isDead;
    }
}
