using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    
    //private int speed = 1;
    private Rigidbody2D rb;
    //public int speed = 1;
    //private Vector3 pos = Input.mousePosition;
    //Vector3 mousePosition;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //pos = rb.transform.position;
    }
    
    

    // Update is called once per frame
    void Update()
    {
        //paddles moves with the mouse cursor
        //pos.x = Input.GetAxis("Horizontal") * speed;
        //this.transform.position = Input.mousePosition;    //lol nope 
        //transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition.x));
        //mousePosition = new Vector3(mousePosition.x, mousePosition.y);
        var mousePos = Input.mousePosition;    
        var wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, 1, 10));
        //took me a good 30 mins to figure out that i couldnt see it moving because it was behind the camera for some reason. 
        transform.position = wantedPos;
        //I dont know why the ball keeps passing through the paddle, they both have rigidbodies... 
    }
}
