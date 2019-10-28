using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
//model hold onto the logic/rules
    
//switching players
//going through to check a match. looking through adjacent squares. 
//UI and tex should be done in View 

//I should have commented the code more when chapin was helping me. FML. 
    private View _view;

    public enum GridSquare
    {    //enums write numbers as words 
        Exmpty, 
        X, 
        O
    }

    public GridSquare[,] grid;
    public int width, height;
    
    // Start is called before the first frame update
    void Start()
    {
        //gets the View script off the game obj called "view".
        _view = GameObject.Find("View").GetComponent<View>();
    }

    public void Initialize()
    {
        width = 3; 
        height = 3;
        
        //grid = new GridSquare[width, height]; //this is supposed to do something but I don't know what. 
    }

    public void MoveMade(int x, int y)
    {
        Debug.Log("X to 0, 0 top left");
        _view.NewShape(x, y);
    }

    public void GetInput(int input)
    {
        //receive input
        //this is where I think it would set where to 
        //= changing value, == checking the value
        if (input == 1)    
        {
            MoveMade(-1, 1);
        }   
        if (input == 2)  
        {
            MoveMade(0, 1);
        }  
    }
    
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
