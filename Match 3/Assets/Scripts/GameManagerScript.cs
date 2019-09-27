using UnityEngine;

public class GameManagerScript : MonoBehaviour {

	//Ok. So I know the assignment was to fix the problems in the code, but right now that's still almost completely
	//above my head so I've gone through and commented what I THINK the code is doing to the best of my ability
	//because just trying to accurately read the code is where I'm at right now.
	//
	
	
	public int gridWidth = 8;
	public int gridHeight = 8;
	//8x8 grid. Got it. 
	public float tokenSize = 1;

	private MatchManagerScript matchManager;
	private InputManagerScript inputManager;
	private RepopulateScript repopulateManager;
	private MoveTokensScript moveTokenManager;

	public GameObject grid;
	public  GameObject[,] gridArray;
<<<<<<< HEAD
	protected Object[] tokenTypes; //Fuck. I think we talked about this in class, but why is this an Object and not a GameObject? 
	//Is it because Objects can do less than GameObjects and the tokens don't need to do much? 
	GameObject selected; //When I right click and go to Find Usages, it says "Usages of "selected" were not found. 
	//There's a gameObj in InputManager called _selected but that should be two different variables, yes?  

	public virtual void Start () { //Do all this at Start. / Here are all the things we need up front in order for this to work. 
		tokenTypes = (Object[])Resources.LoadAll("Tokens/");//Load all the tokens in the resources folder called "Tokens". 
		gridArray = new GameObject[gridWidth, gridHeight];//Is the purpose of defining gridArray in Start instead of where it's declared so that
		//it could be redefined somewhere else or would that fuck shit up? 
		//Edit: Tested below. It fucks shit up. 
=======
	private Object[] tokenTypes;
	private GameObject _selected;

	public virtual void Start () {
		tokenTypes = Resources.LoadAll("Tokens/");
		gridArray = new GameObject[gridWidth, gridHeight];
>>>>>>> origin/master
		MakeGrid();
		
		matchManager = GetComponent<MatchManagerScript>();
		Debug.Assert(matchManager != null, "Attach a match manager to this object.");
		
		inputManager = GetComponent<InputManagerScript>();
		repopulateManager = GetComponent<RepopulateScript>();
		moveTokenManager = GetComponent<MoveTokensScript>();
	}

	public virtual void Update(){
		if(!GridHasEmpty()){ //This seems pretty straight forward. If the grid has a match, remove it and select a token to replace it with
			//then move the tokens to the empty spaces.
			if(matchManager.GridHasMatch()){
				matchManager.RemoveMatches();
			} else {
				inputManager.SelectToken();
			}
		} 
		else {
			if(!moveTokenManager.move){
			//if(moveTokenManager.move){ //Didn't know what the ! in front did so I took it out and tested it.
			//To clarify I know that != means not equal to, and that ! probably did something similar in this case but not what exactly the effect was.  
			//The second to bottom row disappears except for the rightmost token and nothing moves.
			//Still didn't make sense so I did it again, and part of different lines disappeared. 
			//Which confirms what I thought it did in the first place but I need to look at the moveManagerScript to figure this out. 
			
				moveTokenManager.SetupTokenMove();
			}
			if(!moveTokenManager.MoveTokensToFillEmptySpaces()){
				repopulateManager.AddNewTokensToRepopulateGrid();
			}
		}
	}

	void MakeGrid() {
<<<<<<< HEAD
		grid = new GameObject("TokenGrid");	//Create a new GameObj called "TokenGrid"
		//tested for the hell of it. Does what I thought it would. So ya know, small victories. 
		for(var x = 0; x < gridWidth; x++){	//add to x until you hit gridWidth threshold. 
			for(int y = 0; y < gridHeight; y++){ 
				AddTokenToPosInGrid(x, y, grid); //tells the for loop what action to take until the condition is met. 
				//Is the ++ effectively adding the method AddTokenToPosInGrid each time?
				//I always thought of it as "add 1" like the number. I want to test this but don't know what I'd put there instead. 
=======
		grid = new GameObject("TokenGrid");
		
		for(int x = 0; x < gridWidth; x++)
		{
			for(int y = 0; y < gridHeight; y++)
			{
				AddTokenToPosInGrid(x, y, grid);
>>>>>>> origin/master
			}
		}
	}

	protected virtual bool GridHasEmpty(){
<<<<<<< HEAD
		for(int x = 0; x < gridWidth; x++){
			for(int y = 0; y < gridHeight ; y++){
				//gridArray = new GameObject[gridWidth, gridHeight+1]; //Makes each spot in the top line all of the dog tokens stacked on top of each other. 
				//Mostly I just wanted to insert this to see what it did. The answer is that it breaks the game. #TheMoreYouKnow
				if(gridArray[x, y] == null){
=======
		for (int x = 0; x < gridWidth; x++)
		{
			for (int y = 0; y < gridHeight ; y++)
			{
				if (gridArray[x, y] == null)
				{
>>>>>>> origin/master
					return true;
				}
			}
		}

		return false;
	}

	public Vector2 GetPositionOfTokenInGrid(GameObject token){ //this is being declared here to be used in the InputManager 
		for(int x = 0; x < gridWidth; x++){	
			//It's the same sort of for loop from when the grid was made, but we want it to identify the position of each token in the grid.  
			for(int y = 0; y < gridHeight ; y++){
				if(gridArray[x, y] == token){
					return(new Vector2(x, y));
				}
			}
		}
		return new Vector2();
	}
	
	//Sometimes I'm confused about when we need to separate one method into individual methods. 
	public Vector2 GetWorldPositionFromGridPosition(int x, int y){ //I think I'm better understanding what I don't know. 
		//We want to get the world position to be the same as the grid position? 
		//I think I'm thinking of this backwards. 
		return new Vector2( //We're returning a Vector2 because we're going to use that as the x and y position. 
			(x - gridWidth/2) * tokenSize,
			(y - gridHeight/2) * tokenSize); 
		//I'm lost on this one. I know what the effects of this method are but I don't know how everything inside it is making that happen. 
	}

	public void AddTokenToPosInGrid(int x, int y, GameObject parent){ //something clicked just now but I can't tell exactly what.  
		Vector3 position = GetWorldPositionFromGridPosition(x, y);
		//Order of operations is fucking with me a little. Does it matter that we declare this method after GetWorldPositionFromGridPosition?
		GameObject token = 
			Instantiate(tokenTypes[Random.Range(0, tokenTypes.Length)],  
			            position, 
			            Quaternion.identity) as GameObject; //Quaternion.identity is like it's natural orientation I think?  
		//get a random token from the... array of tokens? I guess they have to be in some kind of order.
		//Are they automatically sorted into an array? Does that question even make sense? 
		token.transform.parent = parent.transform; //Wait, what the fuck is the token's parent? Like the Token Grid in the hierarchy?  
		gridArray[x, y] = token; //tells the token where to go on the gridArray. Still don't know what x, y are referring to exactly. 
		//I mean the x and y axis probably but what are the numbers in those variables and where did they come from? 
		//Is it the gridWidth, gridHeight? 
	}
}
