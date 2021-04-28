using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelpMom : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoadingmomtalkUI = 8f;
    [SerializeField]
    private float delayBeforeLoadingmomtalk2UI = 12f;
    [SerializeField]
    private float delayBeforeLoadingmomtalk3UI = 20f;
   
    private float timeElapsed;
    private bool gamePaused = false;
    public GameObject momtalkUI;
    public GameObject momtalk2UI;
    public GameObject momtalk3UI;
  
    // Start is called before the first frame update
    void Start()
    {
        momtalkUI.SetActive(true);
        momtalk2UI.SetActive(false);
        momtalk3UI.SetActive(false);
      
      
    }

    // Update is called once per frame
    void Update()
    {
         if (!gamePaused)
        {
            timeElapsed += Time.deltaTime;
        }
        if (timeElapsed > delayBeforeLoadingmomtalkUI)
        {
            momtalkUI.SetActive(false);
            momtalk2UI.SetActive(true);

        }
        if (timeElapsed > delayBeforeLoadingmomtalk2UI)
        {
            momtalk2UI.SetActive(true);
            momtalk3UI.SetActive(true);

        }
        // if (timeElapsed > delayBeforeLoadingmomtalk3UI)
        // {
        //     lost2UI.SetActive(false);
        //     catUI.SetActive(true);

        // }
    }
}

