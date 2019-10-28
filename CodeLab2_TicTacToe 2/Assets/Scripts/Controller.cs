using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //Controller takes in user input that the view gets from the model and updates the model?
    //Or it would but the input isn't mouse position, it's keypresses. 
    private Model _model;
    void Start()
    {
        _model = GameObject.Find("Model").GetComponent<Model>(); //gets the script off of the game obj called "Model"
    }
   
    
    //a button press has happened
    //where on the screen?
    // Update is called once per frame
    void Update()
    {
        //tell model what the keypress was 
        //Still somewhat confused about this - GetInput and KeyKeyDown seem like they do pretty much the same thing. 
        //_model.GetInput(1) looks like it's setting a number to be used later 
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _model.GetInput(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _model.GetInput(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _model.GetInput(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _model.GetInput(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _model.GetInput(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            _model.GetInput(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            _model.GetInput(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            _model.GetInput(8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            _model.GetInput(9);
        }
    }
}


