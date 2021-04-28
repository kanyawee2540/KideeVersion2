using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PyramidControl : MonoBehaviour
{
    public static int slotsOccupied;
    public Text winSign;
     
    [SerializeField]
    private Transform[] rings;
    
   
    // Start is called before the first frame update
    private void Start()
    {
        Drag.PuzzleDone += CheckResults;
        slotsOccupied = 0;
        // winSign.SetActive(false);
        // wrongSign.SetActive(false);
    }
    public void CheckResults()
    {
        if(rings[0].position.y == 1.7f &&
           rings[1].position.y == 0.15f &&
           rings[2].position.y == -1.5f &&
           rings[3].position.y == -3.15f )
           {
               winSign.text="Win";
              // winSign.SetActive(true);
               //Invoke("RelodeGame",2f);
           }
           else
           {
                winSign.text="not Win";
              // wrongSign.SetActive(true);
              // Invoke("RelodeGame",1f);
           }
    }
    public void RelodeGame()
    {
          Drag.PuzzleDone -= CheckResults;
          SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    
}
