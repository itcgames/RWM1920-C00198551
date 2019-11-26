using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryCheck : MonoBehaviour
{
    public GameObject wire;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "box")
        {
            Debug.Log("check");
            wire.GetComponent<HingeJoint2D>().connectedBody = collision.GetComponent<Rigidbody2D>();
        }    
    }

}
