using UnityEngine;
using System.Collections;

public class RepopulateScript : MonoBehaviour {
	
	protected GameManagerScript gameManager;

	public virtual void Start () {
		gameManager = GetComponent<GameManagerScript>();
	}

	public virtual void AddNewTokensToRepopulateGrid(){
		for(int x = 0; x < gameManager.gridWidth; x++){
			GameObject token = gameManager.gridArray[x, gameManager.gridHeight - 1];
			//took out the -1 to test and the grid didn't repopulate which is what I knew would happen,
			//but I'm still not sure what the -1 does. Tried it with +1 but results did not get me closer to an answer. 
			//I'm going to come back to this when my brain isn't jello. 
			if(token == null){
				gameManager.AddTokenToPosInGrid(x, gameManager.gridHeight - 1, gameManager.grid);
			}
		}
	}
}
