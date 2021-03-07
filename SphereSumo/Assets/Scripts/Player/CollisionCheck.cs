using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    [SerializeField] PlayerControls myPlayerControls;

    [SerializeField] float force;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            myPlayerControls.CanMove(false);

            Vector3 direction = collision.contacts[0].point - this.transform.position;
            direction = -direction.normalized;
            this.GetComponent<Rigidbody>().AddForce(direction * force);
        }
    }
}
