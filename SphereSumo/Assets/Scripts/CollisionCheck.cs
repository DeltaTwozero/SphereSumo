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
                myPlayerControls.CanMove(false);

                Vector3 direction = collision.contacts[0].point - this.transform.position;
                direction = -direction.normalized;
                this.GetComponent<Rigidbody>().AddForce(direction * force);
            }
        }
        
        else if(myAI != null)
        {
                if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "WeakSpot")
            {
                myAI.CanMove(false);

                Vector3 direction = collision.contacts[0].point - this.transform.position;
                direction = -direction.normalized;
                this.GetComponent<Rigidbody>().AddForce(direction * force);
            }
        }
    }
}
