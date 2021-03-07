using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //Set reference in editor
    [SerializeField] FloatingJoystick moveJoystick;
    float joyVertical, joyHorizontal;

    //Movement values
    [SerializeField] float moveSpeed;

    void Update()
    {
        GetJoystickValues();
    }

    private void FixedUpdate()
    {
        MoveAndLookPlayer();
    }

    #region Movement
    void GetJoystickValues()
    {
        //Getting joystick values
        joyHorizontal = moveJoystick.Horizontal;
        joyVertical = moveJoystick.Vertical;
    }

    void MoveAndLookPlayer()
    {
        //Moving player
        Vector3 direction = new Vector3(joyHorizontal, 0, joyVertical).normalized;
        this.transform.Translate(direction * Time.deltaTime * moveSpeed, Space.World);

        //Rotating player
        Vector3 lookAtDirection = this.transform.position + direction;
        this.transform.LookAt(lookAtDirection);
    } 
    #endregion
}
