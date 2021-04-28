using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Momtalk4 : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoadingmomtalk3UI = 10f;
    [SerializeField]
     private float delayBeforeLoadingStory1UI = 20f;
    [SerializeField]
    private float delayBeforeLoadingStory2UI = 30f;
      [SerializeField]
    private float delayBeforeLoadingStory3UI = 40f;
      [SerializeField]
    private float delayBeforeLoadingStory4UI = 50f;
      [SerializeField]
    private float delayBeforeLoadingStory5UI = 60f;
      [SerializeField]
    private float delayBeforeLoadingStory6UI = 70f;
     [SerializeField]
    private float delayBeforeLoadingStory7UI = 80f;
    // Start is called before the first frame update
    private float timeElapsed;
    private bool gamePaused = false;
     public GameObject momtalk4UI;
    public GameObject momtalk5UI;
    public GameObject story1UI;
    public GameObject story2UI;
    public GameObject story3UI;
    public GameObject story4UI;
    public GameObject story5UI;
    public GameObject story6UI;
    public GameObject story7UI;
    void Start()
    {
          momtalk4UI.SetActive(true);
        momtalk5UI.SetActive(false);
        story1UI.SetActive(false);
        story2UI.SetActive(false);
        story3UI.SetActive(false);
        story4UI.SetActive(false);
        story5UI.SetActive(false);
        story6UI.SetActive(false);
         story7UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         if (!gamePaused)
        {
            timeElapsed += Time.deltaTime;
        }
        if (timeElapsed > delayBeforeLoadingmomtalk3UI)
        {
            momtalk4UI.SetActive(false);
            momtalk5UI.SetActive(true);

        }

        if (timeElapsed > delayBeforeLoadingStory1UI)
        {
            momtalk5UI.SetActive(false);
            story1UI.SetActive(true);

        }
          if (timeElapsed > delayBeforeLoadingStory2UI)
        {
            story1UI.SetActive(false);
            story2UI.SetActive(true);

        }
         if (timeElapsed > delayBeforeLoadingStory3UI)
        {
            story2UI.SetActive(false);
            story3UI.SetActive(true);

        }
        if (timeElapsed > delayBeforeLoadingStory4UI)
        {
            story3UI.SetActive(false);
            story4UI.SetActive(true);

        }
        if (timeElapsed > delayBeforeLoadingStory5UI)
        {
            story4UI.SetActive(false);
            story5UI.SetActive(true);

        }
        if (timeElapsed > delayBeforeLoadingStory6UI)
        {
            story5UI.SetActive(false);
            story6UI.SetActive(true);

        }
        if (timeElapsed > delayBeforeLoadingStory7UI)
        {
            story6UI.SetActive(false);
            story7UI.SetActive(true);

        }
    }
}
