using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beforeplay : MonoBehaviour
{
   [SerializeField]
    private float delayBeforeplay1 = 10f;
    [SerializeField]
    private float delayBeforeplay2 = 18f;
    [SerializeField]
    private float delayBeforeplay3 = 20f;
   
    private float timeElapsed;
    private bool gamePaused = false;
    public GameObject Beforeplay1UI;
    public GameObject Beforeplay2UI;
   // public GameObject Beforeplay3UI;
  
    // Start is called before the first frame update
    void Start()
    {
      Beforeplay1UI.SetActive(true);
        Beforeplay2UI.SetActive(false);
        //Beforeplay3UI.SetActive(false);
      
      
    }

    // Update is called once per frame
    void Update()
    {
         if (!gamePaused)
        {
            timeElapsed += Time.deltaTime;
        }
        if (timeElapsed > delayBeforeplay1)
        {
            Beforeplay1UI.SetActive(false);
            Beforeplay2UI.SetActive(true);
            gamePaused = true;

        }
        // if (timeElapsed > delayBeforeplay2)
        // {
        //     Beforeplay2UI.SetActive(true);
        //     momtalk3UI.SetActive(true);

        // }
        // if (timeElapsed > delayBeforeLoadingmomtalk3UI)
        // {
        //     lost2UI.SetActive(false);
        //     catUI.SetActive(true);

        // }
    }
}
