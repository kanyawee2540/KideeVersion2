using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beforeplay2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float delayBeforeplay3 = 9f;
    [SerializeField]
    private float delayBeforeplay4 = 18f;
    [SerializeField]
    private float delayplayUI = 25f;
  
   
    private float timeElapsed;
    private bool gamePaused = false;
    public GameObject Beforeplay3UI;
    public GameObject Beforeplay4UI;
    public GameObject playUI;
  
    // Start is called before the first frame update
    void Start()
    {
      Beforeplay3UI.SetActive(true);
        Beforeplay4UI.SetActive(false);
        playUI.SetActive(false);
      
      
    }

    // Update is called once per frame
    void Update()
    {
         if (!gamePaused)
        {
            timeElapsed += Time.deltaTime;
        }
        if (timeElapsed > delayBeforeplay3)
        {
            Beforeplay3UI.SetActive(false);
            Beforeplay4UI.SetActive(true);

        }
        if (timeElapsed > delayplayUI)
        {
            Beforeplay4UI.SetActive(false);
            playUI.SetActive(true);
            gamePaused = true;

        }
        // if (timeElapsed > delayBeforeLoadingmomtalk3UI)
        // {
        //     lost2UI.SetActive(false);
        //     catUI.SetActive(true);

        // }
    }
}
