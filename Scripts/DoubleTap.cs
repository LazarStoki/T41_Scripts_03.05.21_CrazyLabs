using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoubleTap : MonoBehaviour
{
	private Rigidbody rb;
    
	void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {	if (!(EventSystem.current.IsPointerOverGameObject(0)))
			{
				Touch currTouch = Input.GetTouch(i);
				if (currTouch.phase == TouchPhase.Began)
				{
					if (currTouch.tapCount == 2)
					{
						rb.AddForce(0, 300f, 0);
					}
				}
			}
			
        }
    }
}
