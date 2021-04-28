using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameControl : MonoBehaviour
{
    [SerializeField]
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void playSoundEffect()
    {
        sound.Play();
    }

}
