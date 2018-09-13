using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	void Update ()
    {
	    if (Input.GetKey(KeyCode.A))
        {
            transform.Find("Body").GetComponent<Rigidbody2D>().rotation += 20;
            Debug.Log(transform.Find("Body").GetComponent<Rigidbody2D>().rotation);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Find("Body").GetComponent<Rigidbody2D>().rotation += -20;
            Debug.Log(transform.Find("Body").GetComponent<Rigidbody2D>().rotation);
        }

    }
}
