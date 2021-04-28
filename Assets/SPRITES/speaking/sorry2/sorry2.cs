using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class sorry2 : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoadingMonkey = 7f;
    [SerializeField]
    private float delayBeforeLoadingBear = 13f;
    [SerializeField]
    private float delayBeforeLoadingHurt = 18f;
    [SerializeField]
    private float delayBeforeLoadingMonkeyBear = 24f;
    [SerializeField]
    private float delayBeforeLoadingMonkey2 = 32f;
    [SerializeField]
    private float timeElapsed;
    public GameObject monkeyUI;
    public GameObject bearUI;
    public GameObject hurtUI;
    public GameObject monkeyBearUI;
    public GameObject monkey2UI;
    public GameObject questUI;
    private bool gamePaused = false;
    // Start is called before the first frame update
    void Start()
    {

        monkeyUI.SetActive(true);
        bearUI.SetActive(false);
        hurtUI.SetActive(false);
        monkeyBearUI.SetActive(false);
        monkey2UI.SetActive(false);
        questUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamePaused)
        {
            timeElapsed += Time.deltaTime;
        }
        if (timeElapsed > delayBeforeLoadingMonkey)
        {
            monkeyUI.SetActive(false);
            bearUI.SetActive(true);

        }
        if (timeElapsed > delayBeforeLoadingBear)
        {
            bearUI.SetActive(false);
            hurtUI.SetActive(true);
        }
        if (timeElapsed > delayBeforeLoadingHurt)
        {
            hurtUI.SetActive(false);
            monkeyBearUI.SetActive(true);

        }
        if (timeElapsed > delayBeforeLoadingMonkeyBear)
        {
            monkeyBearUI.SetActive(false);
            monkey2UI.SetActive(true);

        }
        if (timeElapsed > delayBeforeLoadingMonkey2)
        {
            monkey2UI.SetActive(false);
            questUI.SetActive(true);
            gamePaused = true;

        }



    }





}
