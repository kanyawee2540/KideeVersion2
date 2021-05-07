using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfo : MonoBehaviour
{
    // Start is called before the first frame update
     [Header("Speaking")]
    public Text dateSpeakingText;
    private string dateSpeakingdisplay = "";
     public Text starSpeakingText;
    private string starSpeakingdisplay = "";

    [Header("KeepInorder")]
    public Text dateKeepInorderText;
    private string dateKeepInorderdisplay = "";
     public Text starKeepInorderText;
    private string starKeepInorderdisplay = "";

    [Header("Queue")]
    public Text dateQueueText;
    private string dateQueuedisplay = "";
     public Text starQueueText;
    private string starQueuedisplay = "";

    [Header("HelpOther")]
    public Text dateHelpOtherText;
    private string dateHelpOtherdisplay = "";
     public Text starHelpOtherText;
    private string starHelpOtherdisplay = "";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowInfoMember()
    
    {


            dateSpeakingdisplay ="";
            starSpeakingdisplay ="";
            
            for(int i=0;i<GetInfo.DateListSpeaking.Count;i++)
            {
                dateSpeakingdisplay = dateSpeakingdisplay.ToString () + GetInfo.DateListSpeaking[i].ToString() + "\n";
                print("DateList"+i+" "+GetInfo.DateListSpeaking[i]);
                dateSpeakingText.text =dateSpeakingdisplay;

                starSpeakingdisplay = starSpeakingdisplay.ToString () + GetInfo.StarListSpeaking[i].ToString() + "\n"; 
                starSpeakingText.text =starSpeakingdisplay;


            }


            dateKeepInorderdisplay ="";
            starKeepInorderdisplay ="";

            for(int i=0;i<GetInfo.DateListKeepInorder.Count;i++)
            {
                dateKeepInorderdisplay = dateKeepInorderdisplay.ToString () + GetInfo.DateListKeepInorder[i].ToString() + "\n";
                print("DateList"+i+" "+GetInfo.DateListKeepInorder[i]);
                dateKeepInorderText.text =dateKeepInorderdisplay;

                starKeepInorderdisplay = starKeepInorderdisplay.ToString () + GetInfo.StarListKeepInorder[i].ToString() + "\n"; 
                starKeepInorderText.text =starKeepInorderdisplay;


            }   
            print("GetInfo.Speakinghistory"+GetInfo.Speakinghistory);

            if(GetInfo.Speakinghistory==0)
        {
            dateSpeakingdisplay ="";
            starSpeakingdisplay ="";
            dateSpeakingText.text ="";
            starSpeakingText.text ="";

        }
        if(GetInfo.keepInorderHistory==0)
        {
            dateKeepInorderdisplay ="";
            starKeepInorderdisplay ="";
            dateKeepInorderText.text ="";
            starKeepInorderText.text ="";

        }
        // if(GetInfo.Speakinghistory==0)
        // {
        //     dateSpeakingdisplay ="";
        //     starSpeakingdisplay ="";
        //     dateSpeakingText.text ="";
        //     starSpeakingText.text ="";

        // }
        // if(GetInfo.Speakinghistory==0)
        // {
        //     dateSpeakingdisplay ="";
        //     starSpeakingdisplay ="";
        //     dateSpeakingText.text ="";
        //     starSpeakingText.text ="";

        // }
        
    }
}
