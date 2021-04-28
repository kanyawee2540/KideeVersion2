using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class queue2 : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoadingPlayground1 = 11f;
    [SerializeField]
    private float delayBeforeLoadingPlayground2 = 21f;
    [SerializeField]
    private float delayBeforeLoadingHowto1 = 30f;
    [SerializeField]
    private float delayBeforeLoadingHowto2 = 45f;
    [SerializeField]
    private float timeElapsed;
    public GameObject playground1UI;
    public GameObject playground2UI;
    public GameObject howto1UI;
    public GameObject howto2UI;
    public GameObject howto3UI;
    private bool gamePaused = false;
    // Start is called before the first frame update
    void Start()
    {
        playground1UI.SetActive(true);
        playground2UI.SetActive(false);
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
        if (timeElapsed > delayBeforeLoadingPlayground1)
        {
            playground1UI.SetActive(false);
            playground2UI.SetActive(true);

        }
        if (timeElapsed > delayBeforeLoadingPlayground2)
        {
            playground2UI.SetActive(false);
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
