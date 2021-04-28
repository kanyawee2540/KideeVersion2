using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvas2 : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 100000f;
    [SerializeField]
    private float timeElapsed;
    public GameObject turtleWalkUI;
    public GameObject rabbitRunUI;
    public GameObject crashUI;
    // Start is called before the first frame update
    void Start()
    {
        turtleWalkUI.SetActive(true);
        rabbitRunUI.SetActive(false);
        crashUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > delayBeforeLoading)
        {
            turtleWalkUI.SetActive(false);
            rabbitRunUI.SetActive(true);
            crashUI.SetActive(false);
        }
           

    }
}
