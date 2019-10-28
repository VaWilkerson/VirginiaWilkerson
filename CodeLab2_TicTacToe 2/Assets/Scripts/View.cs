using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;

public class View : MonoBehaviour
{
    //View knows nothing, Jon Snow. 
    //view puts the sprites on the screen.
   
    private GameObject _xprefab, _oPrefab; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        _oPrefab = Resources.Load<GameObject>("Prefabs/O");
        _xprefab = Resources.Load<GameObject>("Prefabs/X");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewShape(int x, int y) //I thought I understood what this did and now I don't again.
                                       //int x and y are what is being passed into the function, like what the function is going to need? 
                                       //but I don't know what those two ints are or why I need them. 
    {
        Instantiate(_oPrefab);// if x == 0, and y == 0, instantiate at _____ location. over and over for each square. 
        //it seems like this should be where the code tells the view where to put the Os and Xs. 
        
        // this is as far as I got with Chapin helping me and now I'm lost again. 
    }
    
    
}
