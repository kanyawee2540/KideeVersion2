using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Audiomaneger : MonoBehaviour
{
    // Start is called before the first frame update
    private static readonly string FirstPlay =  "FirstPlay";
    private static readonly string BackgroundPref =  "BackgroundPref";

    private static readonly string SoundEffectsPref =  "SoundEffectsPref";
    private static readonly string ClickPref =  "ClickPref";


    private int firstPlayInt;
    public Slider backgroundSlider,soundEffectsSlider,clickSlider;
    public float backgroundFloat,soundEffectsFloat,clickSliderFloat;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;
    public AudioSource[] clickAudio;
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if(firstPlayInt ==0)
        {
                backgroundFloat=.25f;
                soundEffectsFloat=.75f;
                clickSliderFloat=.75f;
                backgroundSlider.value = backgroundFloat;
                soundEffectsSlider.value = soundEffectsFloat;
                clickSlider.value = clickSliderFloat;
                PlayerPrefs.SetFloat(BackgroundPref,backgroundFloat);
                PlayerPrefs.SetFloat(SoundEffectsPref,soundEffectsFloat);
                PlayerPrefs.SetFloat(ClickPref,clickSliderFloat);
                PlayerPrefs.SetInt(FirstPlay,-1);
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;
            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
            soundEffectsSlider.value = soundEffectsFloat;
            clickSliderFloat = PlayerPrefs.GetFloat(ClickPref);
            clickSlider.value = clickSliderFloat;

        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref,backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref,soundEffectsSlider.value);
        PlayerPrefs.SetFloat(ClickPref,clickSlider.value);


    }
    void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;

        for(int i=0;i< soundEffectsAudio.Length;i++)
        {
            soundEffectsAudio[i].volume= soundEffectsSlider.value;
        }

        for(int i=0;i< clickAudio.Length;i++)
        {
            clickAudio[i].volume= clickSlider.value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
