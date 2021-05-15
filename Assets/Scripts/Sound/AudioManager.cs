﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private int FirstPlayInt;
    public Slider backgroundSlider, soundEffectsSlider;
    private float backgroundFloat, soundEffectsFloat;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectAudio;
    // Start is called before the first frame update
    void Start()
    {
        FirstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if(FirstPlayInt == 0){
            backgroundFloat = .125f;
            soundEffectsFloat = .75f;
            backgroundSlider.value = backgroundFloat;
            soundEffectsSlider.value = soundEffectsFloat;
            PlayerPrefs.SetFloat(BackgroundPref,backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref,soundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay,-1);
        }else{
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;
            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
            soundEffectsSlider.value = soundEffectsFloat;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveSoundSettings(){
            PlayerPrefs.SetFloat(BackgroundPref,backgroundSlider.value);
            PlayerPrefs.SetFloat(SoundEffectsPref,soundEffectsSlider.value);
    }
    void onApplicationFocus(bool inFocus){
        if(!inFocus){
            SaveSoundSettings();
        }
    }
    public void UpdateSound(){
        backgroundAudio.volume = backgroundSlider.value;
        for(int i=0;i<soundEffectAudio.Length;i++){
            soundEffectAudio[i].volume = soundEffectsSlider.value;

        }
    }
}
