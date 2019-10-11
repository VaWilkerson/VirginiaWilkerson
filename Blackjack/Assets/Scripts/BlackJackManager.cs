using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

public class BlackJackManager : MonoBehaviour {

	public Text statusText;
	public GameObject tryAgain;
	public string loadScene;

	//public AudioBehaviour fartSound; //ok, if i put this here then it doesnt like the .Play part of fartSound.Play();
	//public AudioClip fartSound;
	//public AudioSource fartSound;
	//Resources.Load("fartSound"); //doesnt like this outside a fn 
	
	public void Start()
	{
		//Resources.Load("fartSound"); //doesnt like this outside a fn
		//Unity doesn't seem to care if it tell it where the sound is or not. Maybe audio is just different? 
	}
	public AudioSource fartSoundEffect; 
	public AudioClip fartSound;
	
	public void PlayerBusted(){
		HidePlayerButtons();
		GameOverText("YOU BUST", Color.red); 
		//gonna throw shit at the wall and see what sticks. 
		
		//AudioClipPlayable
		
		//if (PlayerBusted();) //also no
		//{fartSound.Play();}
		//Play.fartSound(); //nope
		/*Resources.Load("fartSound"); //closer??? This isn't all in red. 
		{
			play(); //definitely not. 
		}*/
		//fartSound.play();
		
		//fartSound.Play();	//ok, it plays! but it plays every time the round restarts and not when the player busts. 
		//So it needs to play only when the player goes over. 
	}

	public void DealerBusted(){
		GameOverText("DEALER BUSTS!", Color.green);
		//fartSound.Play(); //nope
	}
		
	public void PlayerWin(){
		GameOverText("YOU WIN!", Color.green);
	}
		
	public void PlayerLose(){
		GameOverText("YOU LOSE.", Color.red);
		//fartSound.Play();	//nope
	}


	public void BlackJack(){
		GameOverText("Black Jack!", Color.green);
		HidePlayerButtons();
		//fartSound.Play(); //Doesn't like the Play part if I include the AudioBehavior up top. 
			//but if I comment it out, it doesn't like the fartSound part of the fn. 
	}

	public void GameOverText(string str, Color color){
		statusText.text = str;
		statusText.color = color;

		tryAgain.SetActive(true);
	}

	public void HidePlayerButtons(){
		GameObject.Find("HitButton").SetActive(false);
		GameObject.Find("StayButton").SetActive(false);
	}

	public void TryAgain(){
		SceneManager.LoadScene(loadScene);
	}

	public virtual int GetHandValue(List<DeckOfCards.Card> hand){
		int handValue = 0;

		foreach(DeckOfCards.Card handCard in hand){
			handValue += handCard.GetCardHighValue();
		}
		return handValue;
	}
}
