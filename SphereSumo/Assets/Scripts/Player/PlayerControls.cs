using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    //Set reference in editor
    [SerializeField] FloatingJoystick moveJoystick;
    float joyVertical, joyHorizontal;

    //Movement values
    [SerializeField] float currentSpeed, maxSpeed;

    //Modifiers
    [SerializeField] DeathCheck deathCheck;
    [SerializeField] GroundCheck groundCheck;
    bool isAbleToMove = true;
    bool isDead;

    void Update()
    {
        GetJoystickValues();

        //isDead = deathCheck.GetIsDead();
        isDead = groundCheck.GetIsDead();
    }

    private void FixedUpdate()
    {
        if(!isDead)
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

        if(isAbleToMove)
            this.transform.Translate(direction * Time.deltaTime * currentSpeed, Space.World);
            
        //Rotating player
        Vector3 lookAtDirection = this.transform.position + direction;
        this.transform.LookAt(lookAtDirection);
    }

    IEnumerator ResetMovementBool()
    {
        //Activating player movement
        yield return new WaitForSeconds(.5f);
        isAbleToMove = true;
        //print(isAbleToMove);
    }
    #endregion

    #region Get & Set

    public void CanMove(bool condition, bool disableForever)
    {
        isAbleToMove = condition;

        if(!disableForever)
            StartCoroutine("ResetMovementBool");
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
    #endregion

    private void OnDestroy()
    {
        SceneManager.LoadScene(2);
    }
}
