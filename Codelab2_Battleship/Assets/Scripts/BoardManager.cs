using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class BoardManager : MonoBehaviour
{
    //for loop to make the grid. Add square game obj while the number is less than the squaresPerLine
    //do this horizontally and vertically to make a square board.
    //place a # of ships randomly through the grid (on the game objs or separate?)
    //get mouse input to see which square was clicked
    //if the square is also a ship - "You sunk my battleship!" 
    
    public int squaresPerLine = 6; //length and width of grid. 
    public int shipNumber = 5; //number of ships to place on the grid. 
    public GameObject tile; //prefab for the squares.
    public float tileOffset = 1.1f; //space so we can see them. 
    

    // Start is called before the first frame update
    void Start()
    {
        MakeGrid(); //make grid at the beginning of the game
        PlaceShipsRandomly(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeGrid() 
    {
        
        
        //I know it's gotta be 2 for loops, so that's something. 
        for (int y = 0; y < squaresPerLine; y++)    //y axis
        {
            for (int x = 0; x < squaresPerLine; x++)    //x axis
            {
                //gridsquare = Instantiate<GameObject>(fuckYouSquare);
                //gridSquare = GameObject.CreatePrimitive(Quad); //nope
                //gridSquare = GameObject.CreatePrimitive(PrimitiveType.Quad); //also no
                // - 14 chrome tabs later - 
                //GameObject gridSquare = GameObject.CreatePrimitive(PrimitiveType.Quad); //yes but also bad
                
                //I looked at an old CodeLab 1 project. 
                GameObject gridSquare = Instantiate(tile);    //noice
                //ok now they're all on top of each other

                //spread the fuck out
                //gridSquare.transform.position = new Vector3(x, y); // It just looks like 1 big square:( 
                gridSquare.transform.position = new Vector3(x, y) * tileOffset; 
                //I didn't know how to separate them and Siddarth told me where to put the offset. Thank you, Siddarth. 
                

                //get the ships and put on the grid. 
            }

        }
    }

    void PlaceShipsRandomly()    //put 5 ships throughout the grid
    {
        //need to assign "battleship" to 5 random tiles in grid. 
        //place 5 ships on the grid 
        //I have no idea how to do this. 
        //probs should have made the grid an array

        
        
        
        
        
    }
}
