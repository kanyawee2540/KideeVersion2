using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public Text dateText;
    private string datedisplay = "";
     public Text starText;
    private string stardisplay = "";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowInfoMember()
    
    {
            for(int i=0;i<GetInfo.DateList.Count;i++)
            {
                datedisplay = datedisplay.ToString () + GetInfo.DateList[i].ToString() + "\n"; //table star
                print("DateList"+i+" "+GetInfo.DateList[i]);
                dateText.text =datedisplay;

                stardisplay = stardisplay.ToString () + GetInfo.StarList[i].ToString() + "\n"; //table star
                print("DateList"+i+" "+GetInfo.StarList[i]);
                starText.text =stardisplay;



            }
    }
}
