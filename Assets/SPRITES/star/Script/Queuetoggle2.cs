using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class Queuetoggle2 : MonoBehaviour
{
    // Start is called before the first frame update
     // Start is called before the first frame update// Start is called before the first frame update
    ToggleGroup QueueGroup;
    public static int countScore1=0;

    void Start()
    {
        QueueGroup = GetComponent<ToggleGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Submit()
    {
        Toggle queuetoggle1 =QueueGroup.ActiveToggles().FirstOrDefault();
        Debug.Log(queuetoggle1.name);
        string queuename1=""+queuetoggle1.name;
        if(queuename1.Equals("1"))
        {
           // Debug.Log("Score :11111");
            countScore1=countScore1+1;
        }
        else if(queuename1.Equals("2"))
        {
            //Debug.Log("Score :2");
            countScore1=countScore1+2;

        }
        else if(queuename1.Equals("3"))
        {
           // Debug.Log("Score :3");
            countScore1=countScore1+3;
        }
        else if(queuename1.Equals("4"))
        {
            //Debug.Log("Score :4");
            countScore1=countScore1+4;
        }
        else if(queuename1.Equals("5"))
        {
            //Debug.Log("Score :5");
            countScore1=countScore1+5;
        }
        
    }
}
