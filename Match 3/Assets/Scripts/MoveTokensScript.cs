using System;
using UnityEngine;
using System.Collections;

public class MoveTokensScript : MonoBehaviour {
	private GameManagerScript gameManager;
	private MatchManagerScript matchManager;

	public bool move = false;

	//We need lerp b/c we're interpolating between 2 points.
	public float lerpPercent;//Not sure what percent is referring to?
                          //Tried changing it in inspector but it always goes back to 1. 
                          //Without seeing how it fucks up with different numbers I have a hard time deducing what it does. 
	public float lerpSpeed;//sets the movement speed of the swap. Tested. 

	bool userSwap;

<<<<<<< HEAD
	protected GameObject exchangeToken1; //I'm unclear how the script knows which token is exchangeToken1.
=======
	private GameObject exchangeToken1;
>>>>>>> origin/master
	GameObject exchangeToken2;

	Vector2 exchangeGridPos1; //Vector2 because it's an x/y coord? 
	Vector2 exchangeGridPos2;

	//this runs at the start
	private void Start () {
		gameManager = GetComponent<GameManagerScript>();
		matchManager = GetComponent<MatchManagerScript>();
		lerpPercent = 0; //Why do we declare this in start? 
	}

	//this runs every frame
	private void Update () {
		if (!move) return;
		
<<<<<<< HEAD
		if(move){ //not 100% sure what move is doing here. 
			//I'm guessing it makes the tokens change places but the move looks weird in the parentheses as a parameter. 
			//that's all I got.
			lerpPercent += lerpSpeed; 

			if(lerpPercent >= 1){ //I'm missing something about lerp in the context that it's being used for this code. 
				lerpPercent = 1;
			}

			if(exchangeToken1 != null){ //still not understanding something about exchangeToken1.
				ExchangeTokens();
			}
=======
		lerpPercent += lerpSpeed;

		if(lerpPercent >= 1){
			lerpPercent = 1;
		}

		if(exchangeToken1 != null){
			ExchangeTokens();
>>>>>>> origin/master
		}
	}

	public void SetupTokenMove(){ //what does this accomplish as it's own method? 
		move = true;
		lerpPercent = 0;
	}

	public void SetupTokenExchange(GameObject token1, Vector2 pos1,
	                               GameObject token2, Vector2 pos2, bool reversable){ 
		//reversible lets it go back if it wasn't a correct match
		SetupTokenMove();

		exchangeToken1 = token1;
		exchangeToken2 = token2;

		exchangeGridPos1 = pos1;
		exchangeGridPos2 = pos2;

		this.userSwap = reversable;
	}

	private void ExchangeTokens(){

		//this is going over my head. 
		Vector3 startPos = gameManager.GetWorldPositionFromGridPosition((int)exchangeGridPos1.x, (int)exchangeGridPos1.y);
		//gets the start pos of the token but then I get lost at (int)exchangeGridPos1.x, (int)exchangeGridPos1.y).
		//Why are those the inputs for GetWorldPositionFromGridPosition. 
		//And why is it a Vector3 when GetWorldPositionFromGridPosition is a Vector2? 
		Vector3 endPos = gameManager.GetWorldPositionFromGridPosition((int)exchangeGridPos2.x, (int)exchangeGridPos2.y);

		Vector3 movePos1 = Vector3.Lerp(startPos, endPos, lerpPercent);
		Vector3 movePos2 = Vector3.Lerp(endPos, startPos, lerpPercent);

		exchangeToken1.transform.position = movePos1;//sets token1 to the pos of token2
		exchangeToken2.transform.position = movePos2;//vice versa

<<<<<<< HEAD
		if(lerpPercent == 1){//WTF DOES LERPPERCENT DO??????
=======
		
		if(Math.Abs(lerpPercent - 1) < 0.01f){
>>>>>>> origin/master
			gameManager.gridArray[(int)exchangeGridPos2.x, (int)exchangeGridPos2.y] = exchangeToken1;
			gameManager.gridArray[(int)exchangeGridPos1.x, (int)exchangeGridPos1.y] = exchangeToken2;

			if(!matchManager.GridHasMatch() && userSwap){
				SetupTokenExchange(exchangeToken1, exchangeGridPos2, exchangeToken2, exchangeGridPos1, false);
			} else {
				exchangeToken1 = null;
				exchangeToken2 = null;
				move = false;
			}
		}
	}

	private void MoveTokenToEmptyPos(int startGridX, int startGridY,
	                                int endGridX, int endGridY,
	                                GameObject token){//still a little unclear about parameters in general.  
	
		Vector3 startPos = gameManager.GetWorldPositionFromGridPosition(startGridX, startGridY);
		Vector3 endPos = gameManager.GetWorldPositionFromGridPosition(endGridX, endGridY);

		Vector3 pos = Vector3.Lerp(startPos, endPos, lerpPercent);

		token.transform.position =	pos;

		if(Math.Abs(lerpPercent - 1) < 0.01f){
			gameManager.gridArray[endGridX, endGridY] = token;
			gameManager.gridArray[startGridX, startGridY] = null;
		}
	}

<<<<<<< HEAD
	public virtual bool MoveTokensToFillEmptySpaces(){ //help. 
		bool movedToken = false;

		for(int x = 0; x < gameManager.gridWidth; x++){
			for(int y = 1; y < gameManager.gridHeight ; y++){
				if(gameManager.gridArray[x, y - 1] == null){
					for(int pos = y; pos < gameManager.gridHeight; pos++){
						GameObject token = gameManager.gridArray[x, pos];
						if(token != null){
							MoveTokenToEmptyPos(x, pos, x, pos - 1, token);
							movedToken = true;
						}
					}
=======
	public bool MoveTokensToFillEmptySpaces(){
		var movedToken = false;

		for(var x = 0; x < gameManager.gridWidth; x++){
			for(var y = 1; y < gameManager.gridHeight ; y++)
			{
				if (!ReferenceEquals(gameManager.gridArray[x, y - 1], null)) continue;
				
				for(var pos = y; pos < gameManager.gridHeight; pos++){
					var token = gameManager.gridArray[x, pos];
					if (ReferenceEquals(token, null)) continue;
					MoveTokenToEmptyPos(x, pos, x, pos - 1, token);
					movedToken = true;
>>>>>>> origin/master
				}
			}
		}

		if(Math.Abs(lerpPercent - 1) < 0.01f){
			move = false;
		}

		return movedToken;
	}
}
