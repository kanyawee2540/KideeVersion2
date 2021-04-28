using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tryQ4_2nd : MonoBehaviour
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
        if (Q4_2ndDragS4.locked)
        {
            questionUI.SetActive(false);
            correctUI.SetActive(true);
        }
        if (Q4_2ndDragS1.locked || Q4_2ndDragS2.locked || Q4_2ndDragS3.locked)
        {
            GotoinCorrectUI();
            Q4_2ndDragS1.locked = false;
            Q4_2ndDragS2.locked = false;
            Q4_2ndDragS3.locked = false;

        }

    }
    public void goToMain()
    {
        SceneManager.LoadScene("ChooseManu");
    }
    public void tryQ4_2ndAgain()
    {
        SceneManager.LoadScene("Q4_2nd");
    }
    public void GotoinCorrectUI()
    {
        SceneManager.LoadScene("Q4_2ndIncorrect");
    }
}
