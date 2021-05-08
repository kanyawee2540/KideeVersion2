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
    public Text timeSpeakingText;
    private string timeSpeakingdisplay = "";
    public Text correctSpeakingText;
    private string correctSpeakingdisplay = "";
    public Text incorrectSpeakingText;
    private string incorrectSpeakingdisplay = "";

    [Header("KeepInorder")]
    public Text dateKeepInorderText;
    private string dateKeepInorderdisplay = "";
     public Text timeKeepInorderText;
    private string timeKeepInorderdisplay = "";
    public Text correctKeepInorderText;
    private string correctKeepInorderdisplay = "";
    public Text incorrectKeepInorderText;
    private string incorrectKeepInorderdisplay = "";

    [Header("Queue")]
    public Text dateQueueText;
    private string dateQueuedisplay = "";
    public Text timeQueueText;
    private string timeQueuedisplay = "";
    public Text correctQueueText;
    private string correctQueuedisplay = "";
    public Text incorrectQueueText;
    private string incorrectQueuedisplay = "";

    [Header("HelpOther")]
    public Text dateHelpOtherText;
    private string dateHelpOtherdisplay = "";
    public Text timeHelpOtherText;
    private string timeHelpOtherdisplay = "";
    public Text correctHelpOtherText;
    private string correctHelpOtherdisplay = "";
    public Text incorrectHelpOtherText;
    private string incorrectHelpOtherdisplay = "";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowInfoMember()
    
    {
            //Speaking
            dateSpeakingdisplay ="";
            timeSpeakingdisplay ="";
            correctSpeakingdisplay ="";
            incorrectSpeakingdisplay ="";
            
            for(int i=0;i<GetInfo.DateListSpeaking.Count;i++)
            {
                dateSpeakingdisplay = dateSpeakingdisplay.ToString () + GetInfo.DateListSpeaking[i].ToString() + "\n";
               // print("DateList"+i+" "+GetInfo.DateListSpeaking[i]);
                dateSpeakingText.text =dateSpeakingdisplay;

                timeSpeakingdisplay = timeSpeakingdisplay.ToString () + GetInfo.TimeListSpeaking[i].ToString() + "\n"; 
                timeSpeakingText.text =timeSpeakingdisplay;

                correctSpeakingdisplay = correctSpeakingdisplay.ToString () + GetInfo.CorrectListSpeaking[i].ToString() + "\n"; 
                correctSpeakingText.text =correctSpeakingdisplay;

                incorrectSpeakingdisplay = incorrectSpeakingdisplay.ToString () + GetInfo.IncorrectListSpeaking[i].ToString() + "\n"; 
                incorrectSpeakingText.text =incorrectSpeakingdisplay;


            }

            //KeepInorder
            dateKeepInorderdisplay ="";
            timeKeepInorderdisplay ="";
            correctKeepInorderdisplay ="";
            incorrectKeepInorderdisplay ="";

            for(int i=0;i<GetInfo.DateListKeepInorder.Count;i++)
            {
                dateKeepInorderdisplay = dateKeepInorderdisplay.ToString () + GetInfo.DateListKeepInorder[i].ToString() + "\n";
               // print("DateList"+i+" "+GetInfo.DateListKeepInorder[i]);
                dateKeepInorderText.text =dateKeepInorderdisplay;

                timeKeepInorderdisplay = timeKeepInorderdisplay.ToString () + GetInfo.TimeListKeepInorder[i].ToString() + "\n"; 
                timeKeepInorderText.text =timeKeepInorderdisplay;

                correctKeepInorderdisplay = correctKeepInorderdisplay.ToString () + GetInfo.CorrectListKeepInorder[i].ToString() + "\n"; 
                correctKeepInorderText.text =correctKeepInorderdisplay;

                incorrectKeepInorderdisplay = incorrectKeepInorderdisplay.ToString () + GetInfo.IncorrectListKeepInorder[i].ToString() + "\n"; 
                incorrectKeepInorderText.text =incorrectKeepInorderdisplay;


            }  

            //HelpOther
            dateHelpOtherdisplay ="";
            timeHelpOtherdisplay ="";
            correctHelpOtherdisplay ="";
            incorrectHelpOtherdisplay ="";


            for(int i=0;i<GetInfo.DateListHelpOther.Count;i++)
            {
                dateHelpOtherdisplay = dateHelpOtherdisplay.ToString () + GetInfo.DateListHelpOther[i].ToString() + "\n";
               // print("DateList"+i+" "+GetInfo.DateListKeepInorder[i]);
                dateHelpOtherText.text =dateHelpOtherdisplay;

                timeHelpOtherdisplay = timeHelpOtherdisplay.ToString () + GetInfo.TimeListHelpOther[i].ToString() + "\n"; 
                timeHelpOtherText.text =timeHelpOtherdisplay;


                correctHelpOtherdisplay = correctHelpOtherdisplay.ToString () + GetInfo.CorrectListHelpOther[i].ToString() + "\n"; 
                correctHelpOtherText.text =correctHelpOtherdisplay;

                incorrectHelpOtherdisplay = incorrectHelpOtherdisplay.ToString () + GetInfo.IncorrectListHelpOther[i].ToString() + "\n"; 
                incorrectHelpOtherText.text =incorrectHelpOtherdisplay;


            } 

            dateQueuedisplay ="";
            timeQueuedisplay ="";
            correctQueuedisplay ="";
            incorrectQueuedisplay ="";

            for(int i=0;i<GetInfo.DateListQueue.Count;i++)
            {
                dateQueuedisplay = dateQueuedisplay.ToString () + GetInfo.DateListQueue[i].ToString() + "\n";
                //print("DateList"+i+" "+GetInfo.DateListKeepInorder[i]);
                dateQueueText.text =dateQueuedisplay;

                timeQueuedisplay = timeQueuedisplay.ToString () + GetInfo.TimeListQueue[i].ToString() + "\n"; 
                timeQueueText.text =timeQueuedisplay;

                correctQueuedisplay = correctQueuedisplay.ToString () + GetInfo.CorrectListQueue[i].ToString() + "\n"; 
                correctQueueText.text =correctQueuedisplay;

                incorrectQueuedisplay = incorrectQueuedisplay.ToString () + GetInfo.IncorrectListQueue[i].ToString() + "\n"; 
                incorrectQueueText.text =incorrectQueuedisplay;


            }  

            //print("GetInfo.Speakinghistory"+GetInfo.Speakinghistory);

            if(GetInfo.Speakinghistory==0)
        {
            dateSpeakingdisplay ="";
            timeSpeakingdisplay ="";
            correctSpeakingdisplay ="";
            incorrectSpeakingdisplay ="";
            dateSpeakingText.text ="";
            timeSpeakingText.text ="";
            correctSpeakingText.text ="";
            incorrectSpeakingText.text ="";

        }
        if(GetInfo.keepInorderHistory==0)
        {
            dateKeepInorderdisplay ="";
            timeKeepInorderdisplay ="";
            correctKeepInorderdisplay ="";
            incorrectKeepInorderdisplay ="";
            dateKeepInorderText.text ="";
            timeKeepInorderText.text ="";
            correctKeepInorderText.text ="";
            incorrectKeepInorderText.text ="";

        }
        if(GetInfo.HelpOtherhistory==0)
        {
            dateHelpOtherdisplay ="";
            timeHelpOtherdisplay ="";
            correctHelpOtherdisplay ="";
            incorrectHelpOtherdisplay ="";
            correctHelpOtherText.text ="";
            incorrectHelpOtherText.text ="";
            dateHelpOtherText.text ="";
            timeHelpOtherText.text ="";

        }

        if(GetInfo.Queuehistory==0)
        {
            dateQueuedisplay ="";
            timeQueuedisplay ="";
            correctQueuedisplay ="";
            incorrectQueuedisplay ="";
            correctQueueText.text ="";
            incorrectQueueText.text ="";
            dateQueueText.text ="";
            timeQueueText.text ="";

        }
        // if(GetInfo.Speakinghistory==0)
        // {
        //     dateSpeakingdisplay ="";
        //     starSpeakingdisplay ="";
        //     dateSpeakingText.text ="";
        //     starSpeakingText.text ="";

        // }
        
    }
}
