using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Player reference
    [SerializeField] GameObject playerGO;

    //Following offset
    [SerializeField] float offsetX, offsetY, offsetZ;

    //Extra check
    bool isFollowing;
    void Start()
    {
        //playerGO = GameObject.FindGameObjectWithTag("Player");

        if(playerGO != null)
            isFollowing = true;
        else
            print("Player Object is null!");
    }
    private void FixedUpdate()
    {
        if (isFollowing)
        {
            this.transform.LookAt(playerGO.transform.position);
            this.transform.position = new Vector3(playerGO.transform.position.x + offsetX, 5 + offsetY, playerGO.transform.position.z + offsetZ);
        }
    }
}
