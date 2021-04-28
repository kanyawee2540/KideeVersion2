using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tryQ1 : MonoBehaviour
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
        if (Q1DragS1.locked)
        {
            questionUI.SetActive(false);
            correctUI.SetActive(true);
        }
        if (Q1DragS2.locked || Q1DragS3.locked || Q1DragS4.locked)
        {
            GotoinCorrectUI();
            Q1DragS2.locked = false;
            Q1DragS3.locked = false;
            Q1DragS4.locked = false;

        }

    }
    public void goToQ2()
    {
        SceneManager.LoadScene("Q2");
    }
    public void tryQ1Again()
    {
        SceneManager.LoadScene("Q1");
    }
    public void GotoinCorrectUI()
    {
        SceneManager.LoadScene("Q1Incorrect");
    }
}
