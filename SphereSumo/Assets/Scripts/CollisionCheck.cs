using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    [SerializeField] PlayerControls myPlayerControls;
    [SerializeField] AI_Movement myAI;

    [SerializeField] float force;

    private void OnCollisionEnter(Collision collision)
    {
        if(myPlayerControls != null)
        {
            if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "WeakSpot")
            {
                myPlayerControls.CanMove(false, false);

                Vector3 direction = collision.contacts[0].point - this.transform.position;
                direction = -direction.normalized;
                this.GetComponent<Rigidbody>().AddForce(direction * force);
            }

            if(collision.gameObject.tag == "Ground")
            {
                myPlayerControls.CanMove(true, false);
            }
        }
        
        else if(myAI != null)
        {
            if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "WeakSpot")
            {
                myAI.CanMove(false, false);

                Vector3 direction = collision.contacts[0].point - this.transform.position;
                direction = -direction.normalized;
                this.GetComponent<Rigidbody>().AddForce(direction * force);
            }

            if(collision.gameObject.tag == "Ground")
            {
                myAI.CanMove(true, false);
            }
        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if(collision.gameObject.tag == "Ground")
    //    {
    //        if(myPlayerControls != null)
    //        {
    //            myPlayerControls.CanMove(false, true);
    //        }

    //        else if(myAI != null)
    //        {
    //            myAI.CanMove(false, true);
    //        }
    //    } 
    //}
}
