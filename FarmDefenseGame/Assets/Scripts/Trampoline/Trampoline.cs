using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);

        if (collision.gameObject.tag == "Player")
        {
            collision.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100.0f, ForceMode2D.Impulse);
        }
    }
}
