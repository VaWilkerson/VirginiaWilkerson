using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        //rb.AddForce(Vector2.up * 6);
        //rb.velocity = new Vector2(5,3 );
        //I dont understand why this has to be a new vector 2. 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) //I guess 'other' is the other collider? it lets me rename it so idk.
    {
        if (other.transform.CompareTag("Brick"))    
        {
            Destroy(other.gameObject);
        }
        
        //if ()
    }
}
