using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Playables;

public class AudioScript : MonoBehaviour
{
    public AudioSource fartSoundEffect; //Audiosource says its for 3D which I dont really care about but maybe its ok for puttinf on a game obj? 
    public AudioClip fartSound;    //figured out I needed to put the actual clip somewhere. 
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        //need to get the clip, yes?
        //gameObject.GetComponent("fartSound");//or maybe not with the pub audio clip? 
    }

    //public bool hasBusted = false;
    
    
/*    static SoundEffect() //error "method must have a return type"
    {
        //Resources.Load("fartSound");
        // should I do resources.load or make a game object and do getComponent? Unity seems to know where it is by just typing fartSound.Play(); 
        
        /*if (hasBusted = true) //nope
        {
            BlackJackManager.PlayerBusted();
        }
        return true; #1#
        
        /*if (hasBusted)    //nope
        {
            BlackJackManager.PlayerBusted() = true; //getting error 'cannot access non-static method PlayerBusted in static context'

        }#1#

        return; //I'm understanding return better but not yet enough for it to be useful. 
    }*/
    
    
    
    
    // Update is called once per frame
    void Update()
    {
        //if (BlackJackManager.DealerBusted();)    //this never works, I don't know why I keep trying it. 
        //if the blackjack manager script function "dealer busted" runs, play the clip attached to this object. 
        if (BlackJackManager.DealerBusted() ) //UGH. I cant figure out how to reference the function in the other script.
            //That may not even be the way to do it, but it's annoying me that I can't even it it to work so I can text it.  
        {
            fartSound.Play(); //wanted me to add UnityEngine.Playables? 
        }
        
    }
}

/*mmk. So I need to put an audio file in the project folder.
 Need to tell the game where the audio file I want to play is.
 Gotta tell the game when to play it (on player bust)  



*/