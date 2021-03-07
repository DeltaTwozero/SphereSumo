using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCheck : MonoBehaviour
{
    bool isDead = false;

    public void KillPlayer()
    {
        isDead = true;
    }

    public bool GetIsDead()
    {
        return isDead;
    }
}
