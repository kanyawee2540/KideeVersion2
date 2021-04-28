using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tryQ1_2nd : MonoBehaviour
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
        if (Q1_2ndDragS1.locked)
        {
            questionUI.SetActive(false);
            correctUI.SetActive(true);
        }
        if (Q1_2ndDragS2.locked || Q1_2ndDragS3.locked || Q1_2ndDragS4.locked)
        {
            GotoinCorrectUI();
            Q1_2ndDragS2.locked = false;
            Q1_2ndDragS3.locked = false;
            Q1_2ndDragS4.locked = false;

        }

    }
    public void goToQ2_2nd()
    {
        SceneManager.LoadScene("Q2_2nd");
    }
    public void tryQ1_2ndAgain()
    {
        SceneManager.LoadScene("Q1_2nd");
    }
    public void GotoinCorrectUI()
    {
        SceneManager.LoadScene("Q1_2ndIncorrect");
    }
}
