using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tryQ3_2nd : MonoBehaviour
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
        if (Q3_2ndDragS3.locked)
        {
            questionUI.SetActive(false);
            correctUI.SetActive(true);
        }
        if (Q3_2ndDragS1.locked || Q3_2ndDragS2.locked || Q3_2ndDragS4.locked)
        {
            GotoinCorrectUI();
            Q3_2ndDragS1.locked = false;
            Q3_2ndDragS2.locked = false;
            Q3_2ndDragS4.locked = false;

        }

    }
    public void goToQ4_2nd()
    {
        SceneManager.LoadScene("Q4_2nd");
    }
    public void tryQ3_2ndAgain()
    {
        SceneManager.LoadScene("Q3_2nd");
    }
    public void GotoinCorrectUI()
    {
        SceneManager.LoadScene("Q3_2ndIncorrect");
    }
}
