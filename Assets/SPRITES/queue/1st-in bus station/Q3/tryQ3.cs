using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tryQ3 : MonoBehaviour
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
        if (Q3DragS3.locked)
        {
            questionUI.SetActive(false);
            correctUI.SetActive(true);
        }
        if (Q3DragS1.locked || Q3DragS2.locked || Q3DragS4.locked)
        {
            GotoinCorrectUI();
            Q3DragS1.locked = false;
            Q3DragS2.locked = false;
            Q3DragS4.locked = false;

        }

    }
    public void goToQ4()
    {
        SceneManager.LoadScene("Q4");
    }
    public void tryQ3Again()
    {
        SceneManager.LoadScene("Q3");
    }
    public void GotoinCorrectUI()
    {
        SceneManager.LoadScene("Q3Incorrect");
    }
}
