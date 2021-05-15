using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource AudioSource;
    private float musicVolume = 1f;
    public float subSetting;
    void Start()
    {
        AudioSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = musicVolume;
        subSetting = musicVolume;
        
    }
    public void updateVolume(float volume){
        musicVolume = volume;
        subSetting = volume;
    }
}
