using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class BoardManager : MonoBehaviour
{
    //breakout tagged bricks
    
    public int squaresPerLine = 6; //length and width of grid. 
    //public int shipNumber = 5; //number of ships to place on the grid. 
    public GameObject tile; //prefab for the squares.
    public float tileOffset = 1.1f; //space so we can see them. 
    
    

    // Start is called before the first frame update
    void Start()
    {
        MakeGrid(); //make grid at the beginning of the game
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeGrid() 
    {
        for (int y = 0; y < squaresPerLine; y++)    //y axis
        {
            for (int x = 0; x < squaresPerLine; x++)    //x axis
            {
                GameObject gridSquare = Instantiate(tile);   
                
                gridSquare.transform.position = new Vector3(x, y) * tileOffset; 
            }

        }
    }
}


/*
Tag bricks and ball.
When ball collides with brick, destroy brick.

Mouse X pos determines paddle x pos


*/