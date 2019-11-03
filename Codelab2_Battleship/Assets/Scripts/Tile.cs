using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tile : MonoBehaviour
{
    //where is the tile
    //x and y position 
    //is the tile a ship?
    
    public bool isShip = false;
    public bool isClicked = false; 
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Vector3 position = isClicked;    
        }
    }
}
