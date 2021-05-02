using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;



public class Speakingtoggle2 : MonoBehaviour
{
    // Start is called before the first frame update
    ToggleGroup SpeakingGroup;
    public static int countScore2;

    void Start()
    {
        SpeakingGroup = GetComponent<ToggleGroup>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
 public void Submit()
    {
        countScore2=0;
        Toggle speakingtoggle1 = SpeakingGroup.ActiveToggles().FirstOrDefault();
        Debug.Log(speakingtoggle1.name);
        string Speakingname1=""+speakingtoggle1.name;
        if(Speakingname1.Equals("1"))
        {
            Debug.Log("Score :11111");
            countScore2=countScore2+1;
        }
        else if(Speakingname1.Equals("2"))
        {
            Debug.Log("Score :2");
            countScore2=countScore2+2;

        }
        else if(Speakingname1.Equals("3"))
        {
            Debug.Log("Score :3");
            countScore2=countScore2+3;
        }
        else if(Speakingname1.Equals("4"))
        {
            Debug.Log("Score :4");
            countScore2=countScore2+4;
        }
        else if(Speakingname1.Equals("5"))
        {
            Debug.Log("Score :5");
            countScore2=countScore2+5;
        }
        
       // print("countScore2 :"+countScore1);
        
    }
}
