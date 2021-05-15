using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sub : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource AudioSource;
    public Slider volumeSlider;
    private float musicVolume = 1f;
    void Start()
    {
        AudioSource.Play();
        musicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = musicVolume;
        volumeSlider.value = musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("volume",musicVolume);
        
    }
    public void updateVolume(float volume){
        musicVolume = volume;
    }
}
