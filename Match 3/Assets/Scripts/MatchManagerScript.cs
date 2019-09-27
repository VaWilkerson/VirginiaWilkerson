using UnityEngine;

public class MatchManagerScript : MonoBehaviour {
	
	private GameManagerScript _gameManager;

	void Start () {
		_gameManager = GetComponent<GameManagerScript>();
	}

<<<<<<< HEAD
	public virtual bool GridHasMatch(){ //needs 2 for loops to solve. 
		//I'm not sure where to put the GridHasVerticalMatch in here. I tried a bunch of places and it just broke. 
		bool match = false;
		
		for(int x = 0; x < _gameManager.gridWidth; x++){
			for(int y = 0; y < _gameManager.gridHeight ; y++){
				if(x < _gameManager.gridWidth - 2){
					match = match || GridHasHorizontalMatch(x, y); 
				}
=======
	public bool GridHasMatch(){
		for(var x = 0; x < _gameManager.gridWidth; x++){
			for(var y = 0; y < _gameManager.gridHeight; y++){
				if (x < _gameManager.gridWidth - 2 && GridHasHorizontalMatch(x, y)) return true;
				if (y < _gameManager.gridHeight - 2 && GridHasVerticalMatch(x, y)) return true;
>>>>>>> origin/master
			}
		}
	
		for(int y = 0; y < _gameManager.gridHeight; y++){
			for(int x = 0; y < _gameManager.gridWidth ; x++){
				if(y < _gameManager.gridHeight - 2){
					match = match || GridHasVerticalMatch(x, y); 
				}
			}
		} 
		
		return false;
	}

<<<<<<< HEAD
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
=======
	private bool GridHasHorizontalMatch(int x, int y){
		var token1 = _gameManager.gridArray[x + 0, y];
		var token2 = _gameManager.gridArray[x + 1, y];
		var token3 = _gameManager.gridArray[x + 2, y];

		if (ReferenceEquals(token1, null) || ReferenceEquals(token2, null) || ReferenceEquals(token3, null)) return false;
		
		return (token1.name == token2.name && token2.name == token3.name);
	}

	private bool GridHasVerticalMatch(int x, int y)
	{
		var token1 = _gameManager.gridArray[x, y];
		var token2 = _gameManager.gridArray[x, y + 1];
		var token3 = _gameManager.gridArray[x, y + 2];

		if (ReferenceEquals(token1, null) || ReferenceEquals(token2, null) || ReferenceEquals(token3, null)) return false;
		
		return (token1.name == token2.name && token2.name == token3.name);
	}

	private int _GetHorizontalMatchLength(int x, int y){
		GameObject first = _gameManager.gridArray[x, y];
		if (ReferenceEquals(first, null)) return 0;
>>>>>>> origin/master

		var matchLength = 1;

			
		for(var i = x + 1; i < _gameManager.gridWidth; i++){
			var other = _gameManager.gridArray[i, y];

			if (ReferenceEquals(other, null)) break;
			if(first.name == other.name){
				matchLength++;
			} 
			else {
				break;
			}
		}

		return matchLength;
	}
	
	private int _GetVerticalMatchLength(int x, int y){
		var first = _gameManager.gridArray[x, y];
		
		if (ReferenceEquals(first, null)) return 0;
		
		var matchLength = 1;

		for(var currentY = y + 1; currentY < _gameManager.gridHeight; currentY++){
			var other = _gameManager.gridArray[x, currentY];

			if (ReferenceEquals(other, null)) break;

			if(first.name == other.name) {
				matchLength++;
			} 
			else {
				break;
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

<<<<<<< HEAD
	public virtual int RemoveMatches(){ 
		int numRemoved = 0;
=======
	public virtual int RemoveMatches(){
		var numRemoved = 0;

		for(var x = 0; x < _gameManager.gridWidth; x++)
		{
			for(var y = 0; y < _gameManager.gridHeight ; y++)
			{
				var horizonMatchLength = 0;
				var vertMatchLength = 0;

				if (x < _gameManager.gridWidth - 2) horizonMatchLength = _GetHorizontalMatchLength(x, y);
				if (y < _gameManager.gridHeight - 2) vertMatchLength = _GetVerticalMatchLength(x, y);
>>>>>>> origin/master


				if(horizonMatchLength > 2){

					for(var currentX = x; currentX < x + horizonMatchLength; currentX++)
					{
						var token = _gameManager.gridArray[currentX, y]; 
						if (!ReferenceEquals(token, null)) Destroy(token);

						_gameManager.gridArray[currentX, y] = null;
						numRemoved++;
					}
				}
				

				if (vertMatchLength > 2)
				{
					for(var currentY = y; currentY < y + vertMatchLength; currentY++){
						var token = _gameManager.gridArray[x, currentY]; 
						if (!ReferenceEquals(token, null)) Destroy(token);

						_gameManager.gridArray[x, currentY] = null;
						numRemoved++;
					}
				}
			}
		}
		
		return numRemoved; //more questions about return statments. 
	}
}
