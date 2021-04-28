using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class thankyou1 : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoadingHen = 9f;
    [SerializeField]
    private float delayBeforeLoadingLost1 = 18f;
    [SerializeField]
    private float delayBeforeLoadingLost2 = 30f;
    [SerializeField]
    private float delayBeforeLoadingCat = 42f;
    [SerializeField]
    private float delayBeforeLoadingFind = 57f;
    [SerializeField]
    private float timeElapsed;
    public GameObject henUI;
    public GameObject lost1UI;
    public GameObject lost2UI;
    public GameObject catUI;
    public GameObject findUI;
    public GameObject questUI;
    private bool gamePaused = false;
    // Start is called before the first frame update
    void Start()
    {

        henUI.SetActive(true);
        lost1UI.SetActive(false);
        lost2UI.SetActive(false);
        catUI.SetActive(false);
        findUI.SetActive(false);
        questUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamePaused)
        {
            timeElapsed += Time.deltaTime;
        }
        if (timeElapsed > delayBeforeLoadingHen)
        {
            henUI.SetActive(false);
            lost1UI.SetActive(true);

        }
        if (timeElapsed > delayBeforeLoadingLost1)
        {
            lost1UI.SetActive(false);
            lost2UI.SetActive(true);

        }
        if (timeElapsed > delayBeforeLoadingLost2)
        {
            lost2UI.SetActive(false);
            catUI.SetActive(true);

        }
        if (timeElapsed > delayBeforeLoadingCat)
        {
            catUI.SetActive(false);
            findUI.SetActive(true);

        }
        if (timeElapsed > delayBeforeLoadingFind)
        {
            findUI.SetActive(false);
            questUI.SetActive(true);
            gamePaused = true;

        }



    }





}
