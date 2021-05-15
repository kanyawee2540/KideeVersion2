using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChageScene : MonoBehaviour
{
    // Start is called before the first frame update
     private static readonly string BackgroundPref =  "BackgroundPref";

    private static readonly string SoundEffectsPref =  "SoundEffectsPref";
    public float backgroundFloat,soundEffectsFloat;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;
    void Awake()
    {
        CotinueSettings();
    }
    private void CotinueSettings()
    {
        
        backgroundFloat= PlayerPrefs.GetFloat(BackgroundPref);
        soundEffectsFloat= PlayerPrefs.GetFloat(SoundEffectsPref);
        backgroundAudio.volume = backgroundFloat;

        for(int i=0;i< soundEffectsAudio.Length;i++)
        {
            soundEffectsAudio[i].volume= soundEffectsFloat;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
