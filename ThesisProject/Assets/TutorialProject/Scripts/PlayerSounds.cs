using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSounds : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = SoundBank.instance.stepAudio;
    }
    void PlayFootstepSound(InputValue input)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
