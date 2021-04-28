using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class sorry1 : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoadingRabbitRun = 8.5f;
    [SerializeField]
    private float delayBeforeLoadingCrash = 19.5f;
    [SerializeField]
    private float delayBeforeLoadingHurt = 24f;
    [SerializeField]
    private float delayBeforeLoadingQuest = 32f;
    [SerializeField]
    private float timeElapsed;
    public GameObject turtleWalkUI;
    public GameObject rabbitRunUI;
    public GameObject crashUI;
    public GameObject hurtUI;
    public GameObject questUI;
    private bool gamePaused = false;
    // Start is called before the first frame update
    void Start()
    {

        turtleWalkUI.SetActive(true);
        rabbitRunUI.SetActive(false);
        crashUI.SetActive(false);
        hurtUI.SetActive(false);
        questUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamePaused)
        {
            timeElapsed += Time.deltaTime;
        }
        if (timeElapsed > delayBeforeLoadingRabbitRun)
        {
            turtleWalkUI.SetActive(false);
            rabbitRunUI.SetActive(true);

        }
        if(timeElapsed > delayBeforeLoadingCrash) 
            {
                rabbitRunUI.SetActive(false);
                crashUI.SetActive(true);
        }
        if (timeElapsed > delayBeforeLoadingHurt)
        {
            crashUI.SetActive(false);
            hurtUI.SetActive(true);
        }
        if (timeElapsed > delayBeforeLoadingQuest)
        {
            hurtUI.SetActive(false);
            questUI.SetActive(true);
            gamePaused = true;

        }



    }



        
    
}
