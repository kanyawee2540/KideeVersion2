using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource AudioSource;
    private float musicVolume = 1f;
    public float effectSetting;
    void Start()
    {
        AudioSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = musicVolume;
        effectSetting = musicVolume;
        
    }
    public void updateVolume(float volume){
        musicVolume = volume;
        effectSetting = volume;
    }
}
