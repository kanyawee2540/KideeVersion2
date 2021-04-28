using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tryQ2_2nd : MonoBehaviour
{
    public GameObject questionUI;
    public GameObject correctUI;
    //public GameObject inCorrectUI;
    // Start is called before the first frame update
    void Start()
    {
        questionUI.SetActive(true);
        correctUI.SetActive(false);
        //inCorrectUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Q2_2ndDragS2.locked)
        {
            questionUI.SetActive(false);
            correctUI.SetActive(true);
        }
        if (Q2_2ndDragS1.locked || Q2_2ndDragS3.locked || Q2_2ndDragS4.locked)
        {
            GotoinCorrectUI();
            Q2_2ndDragS1.locked = false;
            Q2_2ndDragS3.locked = false;
            Q2_2ndDragS4.locked = false;

        }

    }
    public void goToQ3_2nd()
    {
        SceneManager.LoadScene("Q3_2nd");
    }
    public void tryQ2_2ndAgain()
    {
        SceneManager.LoadScene("Q2_2nd");
    }
    public void GotoinCorrectUI()
    {
        SceneManager.LoadScene("Q2_2ndIncorrect");
    }
}
