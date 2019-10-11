using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript
    : MonoBehaviour
{
    public AudioClip fartSound;
    private AudioSource audioSource; 
        
        
    // Start is called before the first frame update
    void Start()
    {
        //looking at AudioSource component on this object. Telling it to assign the AudioSource to the variable audioSource. 
        //Now anytime I want to reference the AudioSource I can sue the variable audioSource to reference it.  
        audioSource = GetComponent<AudioSource>();
        // == is checking, = is setting. 
    }


    public void PlayFartSound()
    {
        audioSource.PlayOneShot(fartSound);//PlayOneShot nice to play something... once. 
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
