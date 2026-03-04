using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBank : MonoBehaviour
{
    public static SoundBank instance { get; private set; }
    public AudioClip stepAudio;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;
    }
    void Start()
    {
        
    }

    public void PlaySound(AudioClip clip)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
