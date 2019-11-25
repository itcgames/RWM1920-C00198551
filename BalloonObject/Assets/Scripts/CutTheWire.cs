using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTheWire : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "sharp")
        {
            Destroy(gameObject);
        }
    }
}
