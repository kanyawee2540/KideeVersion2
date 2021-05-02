using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;



public class Speakingtoggle3 : MonoBehaviour
{
    // Start is called before the first frame update
    ToggleGroup SpeakingGroup;
    public static int countScore3;

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
        countScore3=0;
        Toggle speakingtoggle1 = SpeakingGroup.ActiveToggles().FirstOrDefault();
        Debug.Log(speakingtoggle1.name);
        string Speakingname1=""+speakingtoggle1.name;
        if(Speakingname1.Equals("1"))
        {
            Debug.Log("Score :11111");
            countScore3=countScore3+1;
        }
        else if(Speakingname1.Equals("2"))
        {
            Debug.Log("Score :2");
            countScore3=countScore3+2;

        }
        else if(Speakingname1.Equals("3"))
        {
            Debug.Log("Score :3");
            countScore3=countScore3+3;
        }
        else if(Speakingname1.Equals("4"))
        {
            Debug.Log("Score :4");
            countScore3=countScore3+4;
        }
        else if(Speakingname1.Equals("5"))
        {
            Debug.Log("Score :5");
            countScore3=countScore3+5;
        }
        
       // print("countScore2 :"+countScore1);

    }
}
