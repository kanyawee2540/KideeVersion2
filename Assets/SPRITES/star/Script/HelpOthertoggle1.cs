using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HelpOthertoggle1 : MonoBehaviour
{
    // Start is called before the first frame update
    ToggleGroup HelpOtherGroup;
    public static int countScore1=0;

    void Start()
    {
        HelpOtherGroup = GetComponent<ToggleGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Submit()
    {
        countScore1=0;
        Toggle helpOthertoggle1 = HelpOtherGroup.ActiveToggles().FirstOrDefault();
        Debug.Log(helpOthertoggle1.name);
        string helpOthername1=""+helpOthertoggle1.name;
        if(helpOthername1.Equals("1"))
        {
           // Debug.Log("Score :11111");
            countScore1=countScore1+1;
        }
        else if(helpOthername1.Equals("2"))
        {
            //Debug.Log("Score :2");
            countScore1=countScore1+2;

        }
        else if(helpOthername1.Equals("3"))
        {
           // Debug.Log("Score :3");
            countScore1=countScore1+3;
        }
        else if(helpOthername1.Equals("4"))
        {
            //Debug.Log("Score :4");
            countScore1=countScore1+4;
        }
        else if(helpOthername1.Equals("5"))
        {
            //Debug.Log("Score :5");
            countScore1=countScore1+5;
        }
        
    }
}
