using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BulletDestroyer")
        {
            Destroy(this.gameObject);
        }
       
    }
}

