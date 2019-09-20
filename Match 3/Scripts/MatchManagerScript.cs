using UnityEngine;

public class MatchManagerScript : MonoBehaviour {
	
	private GameManagerScript _gameManager;

	public virtual void Start () {
		_gameManager = GetComponent<GameManagerScript>();
	}

	public virtual bool GridHasMatch(){ //needs 2 for loops to solve. 
		//I'm not sure where to put the GridHasVerticalMatch in here. I tried a bunch of places and it just broke. 
		bool match = false;
		
		for(int x = 0; x < _gameManager.gridWidth; x++){
			for(int y = 0; y < _gameManager.gridHeight ; y++){
				if(x < _gameManager.gridWidth - 2){
					match = match || GridHasHorizontalMatch(x, y); 
				}
			}
		}
		
		return match;
	}

	public bool GridHasHorizontalMatch(int x, int y){
		GameObject token1 = _gameManager.gridArray[x + 0, y]; //gets tokens from 3 sequential horizontal grid squares. 
		GameObject token2 = _gameManager.gridArray[x + 1, y];
		GameObject token3 = _gameManager.gridArray[x + 2, y];
		
		if(token1 != null && token2 != null && token3 != null){ //Get the sprites and then compare them to each other. 
			SpriteRenderer sr1 = token1.GetComponent<SpriteRenderer>(); 
			SpriteRenderer sr2 = token2.GetComponent<SpriteRenderer>();
			SpriteRenderer sr3 = token3.GetComponent<SpriteRenderer>();
			
			return (sr1.sprite == sr2.sprite && sr2.sprite == sr3.sprite); //If all sprites are the same, there is a match. 
		} else {
			return false;
		}
	}

	
	public bool GridHasVerticalMatch(int x, int y){ //I guess this would be the vertical match method? 
		var token1 = _gameManager.gridArray[x, y]; 	//don't need to add an explicit type, or + 0. 
		var token2 = _gameManager.gridArray[x, y + 1];
		var token3 = _gameManager.gridArray[x, y + 2];
		
		if(token1 != null && token2 != null && token3 != null){
			var sr1 = token1.GetComponent<SpriteRenderer>();
			var sr2 = token2.GetComponent<SpriteRenderer>();
			var sr3 = token3.GetComponent<SpriteRenderer>();
			
			return (sr1.sprite == sr2.sprite && sr2.sprite == sr3.sprite);
		} 
			return false; //don't have to do the else if I haven't returned anything yet. 
		
	}
	
	private int _GetHorizontalMatchLength(int x, int y){
		//I understand looking at this, but I'm not sure I'd be able to write it on my own. 
		//I get the logic of it but I'm still not familiar enough with the syntax to know what to type to accomplish it. 

		int matchLength = 1;
		
		GameObject first = _gameManager.gridArray[x, y]; 

		if(first != null){
			SpriteRenderer sr1 = first.GetComponent<SpriteRenderer>();
			
			for(int i = x + 1; i < _gameManager.gridWidth; i++){
				GameObject other = _gameManager.gridArray[i, y];

				if(other != null){
					SpriteRenderer sr2 = other.GetComponent<SpriteRenderer>();

					if(sr1.sprite == sr2.sprite){
						matchLength++;
					} else {
						break;
					}
				} else {
					break;
				}
			}
		}
		
		return matchLength;
	}
	
	private int _GetVerticalMatchLength(int x, int y){ //I think??? I don't know where to put it so it's hard to test if this works. 
		var matchLength = 1;
		
		GameObject first = _gameManager.gridArray[x, y];

		if(first != null){
			SpriteRenderer sr1 = first.GetComponent<SpriteRenderer>();
			
			for(int i = y + 1; i < _gameManager.gridHeight; i++){
				GameObject other = _gameManager.gridArray[i, x];

				if(other != null){
					SpriteRenderer sr2 = other.GetComponent<SpriteRenderer>();

					if(sr1.sprite == sr2.sprite){
						matchLength++;
					} else {
						break;
					}
				} else {
					break;
				}
			}
		}
		
		return matchLength;
	}

	public virtual int RemoveMatches(){ 
		int numRemoved = 0;

		for(int x = 0; x < _gameManager.gridWidth; x++){
			for(int y = 0; y < _gameManager.gridHeight ; y++){
				if(x < _gameManager.gridWidth - 2){

					int horizonMatchLength = _GetHorizontalMatchLength(x, y);

					if(horizonMatchLength > 2){

						for(int i = x; i < x + horizonMatchLength; i++){
							GameObject token = _gameManager.gridArray[i, y]; 
							Destroy(token);

							_gameManager.gridArray[i, y] = null;
							numRemoved++;
						}
					}
				}
			}
		}
		
		return numRemoved; //more questions about return statments. 
	}
}
