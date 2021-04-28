using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tryQ4 : MonoBehaviour
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
        if (Q4DragS4.locked)
        {
            questionUI.SetActive(false);
            correctUI.SetActive(true);
        }
        if (Q4DragS1.locked || Q4DragS2.locked || Q4DragS3.locked)
        {
            GotoinCorrectUI();
            Q4DragS1.locked = false;
            Q4DragS2.locked = false;
            Q4DragS3.locked = false;

        }

    }
    public void goTo2nd()
    {
        SceneManager.LoadScene("queue2");
    }
    public void tryQ4Again()
    {
        SceneManager.LoadScene("Q4");
    }
    public void GotoinCorrectUI()
    {
        SceneManager.LoadScene("Q4Incorrect");
    }
}
