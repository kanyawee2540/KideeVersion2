﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetting : MonoBehaviour
{
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private float backgroundFloat, soundEffectsFloat;
        
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectAudio;
    // Start is called before the first frame update
    void Awake(){
        ContinuesSetting();
    }
    private void ContinuesSetting(){
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
        backgroundAudio.volume = backgroundFloat;
        for(int i=0;i<soundEffectAudio.Length;i++){
            soundEffectAudio[i].volume = soundEffectsFloat;

        }

    }
}
