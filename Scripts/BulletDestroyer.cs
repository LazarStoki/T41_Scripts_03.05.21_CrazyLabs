using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Metak")
        {
            Destroy(other.gameObject);
        }
        
    }
}
