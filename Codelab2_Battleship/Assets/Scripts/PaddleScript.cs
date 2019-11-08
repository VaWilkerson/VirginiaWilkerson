using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    
    //private int speed = 1;
    private Rigidbody2D rb;
    public int speed = 1;
    

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    
    

    // Update is called once per frame
    void Update()
    {
        //paddles moves with the mouse only on the x axis
        
    }
}
