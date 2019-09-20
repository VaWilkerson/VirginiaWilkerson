using UnityEngine;
using System.Collections;

public class InputManagerScript : MonoBehaviour {
	private GameManagerScript _gameManager;
	private MoveTokensScript _moveManager;
	private GameObject _selected = null;

	public virtual void Start () {
		_moveManager = GetComponent<MoveTokensScript>();
		_gameManager = GetComponent<GameManagerScript>();
	}

	public virtual void SelectToken(){
		if (Input.GetMouseButtonDown(0)){
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
			Collider2D collider = Physics2D.OverlapPoint(mousePos);

			if(collider != null){
				if(_selected == null){	
					_selected = collider.gameObject;//I'm not 100% sure what this line means.
                                     //I think it's saying that if the collider doesn't overlap with something (the sprite?) then the gameObj is null.
				} else {
					Vector2 pos1 = _gameManager.GetPositionOfTokenInGrid(_selected);
					Vector2 pos2 = _gameManager.GetPositionOfTokenInGrid(collider.gameObject);

					//I think this is saying that if the position of the token and the position of the collider match up, then use the MoveTokenScript to swap the tokens. 
					if(Mathf.Abs((pos1.x - pos2.x) + (pos1.y - pos2.y)) == 1){
						_moveManager.SetupTokenExchange(_selected, pos1, collider.gameObject, pos2, true);
					}

					_selected = null;
				}
			}
		}

	}

	public int CommentFunc(int x, int y){
		return x - y;//I have a better understanding of return statements but I'm still sort of iffy on it.
               //I mean this is InputManager and the return is the input but where is that input going? 
               //what is x and y referring to? The x/y axis? The pos1.x/y? Those are the same maybe?  
               //Is there a debug tool that can help with that?
               Debug.Log("Input Manager return statement");
               //I guess this doesn't work. 

	}
}
