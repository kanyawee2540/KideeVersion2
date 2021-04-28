using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tryQ2 : MonoBehaviour
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
        if (Q2DragS2.locked)
        {
            questionUI.SetActive(false);
            correctUI.SetActive(true);
        }
        if (Q2DragS1.locked || Q2DragS3.locked || Q2DragS4.locked)
        {
            GotoinCorrectUI();
            Q2DragS1.locked = false;
            Q2DragS3.locked = false;
            Q2DragS4.locked = false;

        }

    }
    public void goToQ3()
    {
        SceneManager.LoadScene("Q3");
    }
    public void tryQ2Again()
    {
        SceneManager.LoadScene("Q2");
    }
    public void GotoinCorrectUI()
    {
        SceneManager.LoadScene("Q2Incorrect");
    }
}
