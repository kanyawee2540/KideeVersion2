using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class thankyou2 : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoadingTwoBird = 7f;
    [SerializeField]
    private float delayBeforeLoadingBlueBird = 18f;
    [SerializeField]
    private float delayBeforeLoadingRedBird = 30f;
    [SerializeField]
    private float delayBeforeLoadingInNight = 37f;
    [SerializeField]
    private float delayBeforeLoadingHelp = 48f;
    [SerializeField]
    private float delayBeforeLoadingHappy = 58f;
    [SerializeField]
    private float timeElapsed;
    public GameObject twoBirdUI;
    public GameObject blueBirdUI;
    public GameObject redBirdUI;
    public GameObject inNightUI; 
    public GameObject helpUI;
    public GameObject happyUI;
    public GameObject questUI;
    private bool gamePaused = false;
    // Start is called before the first frame update
    void Start()
    {

        twoBirdUI.SetActive(true);
        blueBirdUI.SetActive(false);
        redBirdUI.SetActive(false);
        inNightUI.SetActive(false);
        helpUI.SetActive(false);
        happyUI.SetActive(false);
        questUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamePaused)
        {
            timeElapsed += Time.deltaTime;
        }
        if (timeElapsed > delayBeforeLoadingTwoBird)
        {
            twoBirdUI.SetActive(false);
            blueBirdUI.SetActive(true);

        }
        if (timeElapsed > delayBeforeLoadingBlueBird)
        {
            blueBirdUI.SetActive(false);
            redBirdUI.SetActive(true);

        }
        if (timeElapsed > delayBeforeLoadingRedBird)
        {
            redBirdUI.SetActive(false);
            inNightUI.SetActive(true);

        }
        if (timeElapsed > delayBeforeLoadingInNight)
        {
            inNightUI.SetActive(false);
            helpUI.SetActive(true);

        }
        if (timeElapsed > delayBeforeLoadingHelp)
        {
            helpUI.SetActive(false);
            happyUI.SetActive(true);
        }
        if (timeElapsed > delayBeforeLoadingHappy)
        {
            happyUI.SetActive(false);
            questUI.SetActive(true);
            gamePaused = true;

        }



    }





}
