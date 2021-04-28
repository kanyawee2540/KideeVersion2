using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyKeepinOrder : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float delayBeforestory1;
    [SerializeField]
    private float delayBeforestory2 ;
    [SerializeField]
    private float delayBeforestory3;
    [SerializeField]
    private float delayBeforestory4 ;
    [SerializeField]
    private float delayBeforestory5;
    [SerializeField]
    private float delayBeforestory6;
    [SerializeField]
    private float delayBeforestory7;
    [SerializeField]
    private float delayBeforestory8;
   [SerializeField]
    private float delayBeforestory9;
     [SerializeField]
    private float delayBeforestory10;
    [SerializeField]
    private float delayBeforestory11;
     [SerializeField]
    private float delayBeforestory12;
    [SerializeField]
    private float delayBeforestory13;
    private float timeElapsed;
    private bool gamePaused = false;
    public GameObject story1;
    public GameObject story2;
    public GameObject story3;
    public GameObject story4;
    public GameObject story5;
    public GameObject story6;
    public GameObject story7;
    public GameObject story8;
    public GameObject story9;
    public GameObject story10;
    public GameObject story11;
    public GameObject story12;
    public GameObject story13;
    public GameObject story14;
    public GameObject story15;
  
    // Start is called before the first frame update
    void Start()
    {
        story1.SetActive(true);
        story2.SetActive(false);
        story3.SetActive(false);
        story4.SetActive(false);
        story5.SetActive(false);
        story6.SetActive(false);
        story7.SetActive(false);
        story8.SetActive(false);
        story9.SetActive(false);
        story10.SetActive(false);
       story11.SetActive(false);
        story12.SetActive(false);
        story13.SetActive(false);
       story14.SetActive(false);
       story15.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         if (!gamePaused)
        {
            timeElapsed += Time.deltaTime;
        }
        if (timeElapsed > delayBeforestory1)
        {
            story1.SetActive(false);
            story2.SetActive(true);

        }
        if (timeElapsed > delayBeforestory2)
        {
            story2.SetActive(false);
            story3.SetActive(true);

        }
          if (timeElapsed > delayBeforestory3)
        {
            story3.SetActive(false);
            story4.SetActive(true);

        }
          if (timeElapsed > delayBeforestory4)
        {
            story4.SetActive(false);
            story5.SetActive(true);

        }
          if (timeElapsed > delayBeforestory5)
        {
            story5.SetActive(false);
            story6.SetActive(true);

        }
          if (timeElapsed > delayBeforestory6)
        {
            story6.SetActive(false);
            story7.SetActive(true);

        }
           if (timeElapsed > delayBeforestory7)
        {
            story7.SetActive(false);
            story8.SetActive(true);

        }
           if (timeElapsed > delayBeforestory8)
        {
            story8.SetActive(false);
            story9.SetActive(true);

        }
           if (timeElapsed > delayBeforestory9)
        {
            story9.SetActive(false);
            story10.SetActive(true);

        }
           if (timeElapsed > delayBeforestory10)
        {
            story10.SetActive(false);
            story11.SetActive(true);

        }
          if (timeElapsed > delayBeforestory11)
        {
            story11.SetActive(false);
            story12.SetActive(true);

        }
        if (timeElapsed > delayBeforestory12)
        {
            story12.SetActive(false);
            story13.SetActive(true);

        }
        if (timeElapsed > delayBeforestory13)
        {
            story13.SetActive(false);
            story14.SetActive(true);
            gamePaused = true;

        }
    }
}
