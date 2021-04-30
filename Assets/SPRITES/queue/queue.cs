using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using Object = UnityEngine.Object;
using UnityEngine.EventSystems;

public class queue : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoadingBus1 = 11f;
    [SerializeField]
    private float delayBeforeLoadingBus2 = 20f;
    [SerializeField]
    private float delayBeforeLoadingHowto1 = 28f;
    [SerializeField]
    private float delayBeforeLoadingHowto2 = 45f;
    [SerializeField]
    private float timeElapsed;
    public GameObject bus1UI;
    public GameObject bus2UI;
    public GameObject howto1UI;
    public GameObject howto2UI;
    public GameObject howto3UI;
    private bool gamePaused = false;
    // Start is called before the first frame update
    void Start()
    {
        bus1UI.SetActive(true);
        bus2UI.SetActive(false);
        howto1UI.SetActive(false);
        howto2UI.SetActive(false);
        howto3UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamePaused)
        {
            timeElapsed += Time.deltaTime;
        }
        if (timeElapsed > delayBeforeLoadingBus1)
        {
            bus1UI.SetActive(false);
            bus2UI.SetActive(true);

        }
        if (timeElapsed > delayBeforeLoadingBus2)
        {
            bus2UI.SetActive(false);
            howto1UI.SetActive(true);
        }
        if (timeElapsed > delayBeforeLoadingHowto1)
        {
            howto1UI.SetActive(false);
            howto2UI.SetActive(true);

        }
        if (timeElapsed > delayBeforeLoadingHowto2)
        {
            howto2UI.SetActive(false);
            howto3UI.SetActive(true);
            gamePaused = true;

        }
    }

}
