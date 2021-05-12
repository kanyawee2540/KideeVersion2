using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using Object = UnityEngine.Object;

public class GetInfo : MonoBehaviour
{
    // Start is called before the first frame update
    private DatabaseReference reference;

    //Speaking
    public static ArrayList DateListSpeaking = new ArrayList();
    public static ArrayList TimeListSpeaking = new ArrayList();
    public static ArrayList CorrectListSpeaking = new ArrayList();
    public static ArrayList IncorrectListSpeaking = new ArrayList();
    
    
    //Queue
     public static ArrayList DateListQueue = new ArrayList();
    public static ArrayList TimeListQueue = new ArrayList();
    public static ArrayList CorrectListQueue = new ArrayList();
    public static ArrayList IncorrectListQueue = new ArrayList();


    //KeepInorder
    public static ArrayList DateListKeepInorder = new ArrayList();
    public static ArrayList TimeListKeepInorder = new ArrayList();
    public static ArrayList CorrectListKeepInorder = new ArrayList();
    public static ArrayList IncorrectListKeepInorder = new ArrayList();

    //HelpOther
    public static ArrayList DateListHelpOther = new ArrayList();
    public static ArrayList TimeListHelpOther = new ArrayList();
     public static ArrayList CorrectListHelpOther = new ArrayList();
    public static ArrayList IncorrectListHelpOther = new ArrayList();

    


    public static int keepInorderHistory,Speakinghistory,HelpOtherhistory,Queuehistory;
   



    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetInfoMember()
        {
            DateListSpeaking.Clear();
            TimeListSpeaking.Clear();
            CorrectListSpeaking.Clear();
            IncorrectListSpeaking.Clear();
            
            DateListQueue.Clear();
            TimeListQueue.Clear();
            CorrectListQueue.Clear();
            IncorrectListQueue.Clear();


            DateListKeepInorder.Clear();
            TimeListKeepInorder.Clear();
            CorrectListKeepInorder.Clear();
            IncorrectListKeepInorder.Clear();

            DateListHelpOther.Clear();
            TimeListHelpOther.Clear();
            CorrectListHelpOther.Clear();
            IncorrectListHelpOther.Clear();

            


            string s= ""+RemoveMember.keyList[StarCollection.buttonStarCount];
;
           
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;


        string No = snapshot.Child(s).Child("speakingHistory").Value.ToString();
        Speakinghistory = Int32.Parse(No);
        string No2 = snapshot.Child(s).Child("keepInorderHistory").Value.ToString();
        keepInorderHistory = Int32.Parse(No2);
        string No3 = snapshot.Child(s).Child("helpOtherHistory").Value.ToString();
        HelpOtherhistory = Int32.Parse(No3);
        string No4 = snapshot.Child(s).Child("queueHistory").Value.ToString();
        Queuehistory = Int32.Parse(No4);
        
        
        //print("No:"+No1);
        //history +=1;
        // inToHis = "History"+history;
        // print("inToHis:"+inToHis);

        //Speaking
        for(int i=0;i<Speakinghistory;i++)
        {
            int count = i+1;
            string date = snapshot.Child(s).Child("Speaking").Child("History"+count).Child("Date").Value.ToString();
            //print("Speaking history: "+count+" date: "+date);
            DateListSpeaking.Add(date);

            string time = snapshot.Child(s).Child("Speaking").Child("History"+count).Child("Time").Value.ToString();
            //print("Speaking history: "+count+" Time: "+time);
            TimeListSpeaking.Add(time);

             
            string Correct = snapshot.Child(s).Child("Speaking").Child("History"+count).Child("Correct").Value.ToString();
            //print("Speaking history: "+count+" Correct: "+Correct);
            CorrectListSpeaking.Add(Correct);

            string Incorrect = snapshot.Child(s).Child("Speaking").Child("History"+count).Child("Incorrect").Value.ToString();
            //print("Speaking history: "+count+" Incorrect: "+Incorrect);
            IncorrectListSpeaking.Add(Incorrect);
            

           // keepInorderscore = Int32.Parse(keepInordercorrectInHis);
        }


        //KeepInorder
         for(int i=0;i<keepInorderHistory;i++)
        {
            int count = i+1;
            string date = snapshot.Child(s).Child("KeepInorder").Child("History"+count).Child("Date").Value.ToString();
            //print(" KeepInorder history: "+count+" date: "+date);
            DateListKeepInorder.Add(date);

            string time = snapshot.Child(s).Child("KeepInorder").Child("History"+count).Child("Time").Value.ToString();
            //print(" KeepInorder history: "+count+" Time: "+time);
            TimeListKeepInorder.Add(time);

            string Correct = snapshot.Child(s).Child("KeepInorder").Child("History"+count).Child("Correct").Value.ToString();
            //print("KeepInorder history: "+count+" Correct: "+Correct);
            CorrectListKeepInorder.Add(Correct);

            string Incorrect = snapshot.Child(s).Child("KeepInorder").Child("History"+count).Child("Incorrect").Value.ToString();
            //print("KeepInorder history: "+count+" Incorrect: "+Incorrect);
            IncorrectListKeepInorder.Add(Incorrect);
            

           // keepInorderscore = Int32.Parse(keepInordercorrectInHis);
        }

         //HelpOther
         for(int i=0;i<HelpOtherhistory;i++)
        {
            int count = i+1;
            string date = snapshot.Child(s).Child("HelpOther").Child("History"+count).Child("Date").Value.ToString();
            //print(" HelpOther history: "+count+" date: "+date);
            DateListHelpOther.Add(date);

            string time = snapshot.Child(s).Child("HelpOther").Child("History"+count).Child("Time").Value.ToString();
            //print(" HelpOther history: "+count+" time: "+time);
            TimeListHelpOther.Add(time);

            string Correct = snapshot.Child(s).Child("HelpOther").Child("History"+count).Child("Correct").Value.ToString();
            //print("HelpOther history: "+count+" Correct: "+Correct);
            CorrectListHelpOther.Add(Correct);

            string Incorrect = snapshot.Child(s).Child("HelpOther").Child("History"+count).Child("Incorrect").Value.ToString();
            //print("HelpOther history: "+count+" Incorrect: "+Incorrect);
            IncorrectListHelpOther.Add(Incorrect);
            

           // keepInorderscore = Int32.Parse(keepInordercorrectInHis);
        }


        for(int i=0;i<Queuehistory;i++)
        {
            int count = i+1;
            string date = snapshot.Child(s).Child("Queue").Child("History"+count).Child("Date").Value.ToString();
            //print("Queue: "+count+" date: "+date);
            DateListQueue.Add(date);

            string time = snapshot.Child(s).Child("Queue").Child("History"+count).Child("Time").Value.ToString();
            //print(" Queue history: "+count+" time: "+time);
            TimeListQueue.Add(time);

            string Correct = snapshot.Child(s).Child("Queue").Child("History"+count).Child("Correct").Value.ToString();
            //print("Queue history: "+count+" Correct: "+Correct);
            CorrectListQueue.Add(Correct);

            string Incorrect = snapshot.Child(s).Child("Queue").Child("History"+count).Child("Incorrect").Value.ToString();
            //print("Queue history: "+count+" Incorrect: "+Incorrect);
            IncorrectListQueue.Add(Incorrect);
            

           // keepInorderscore = Int32.Parse(keepInordercorrectInHis);
        }

              //----------------------Get max Star---------------------------------
        // starkeepInorder=snapshot.Child(s).Child("starKeepInorder").Value.ToString();
        // print("maxStar : "+starkeepInorder);
        // maxStarkeepInorder = Int32.Parse(starkeepInorder);

        // starSpeaking=snapshot.Child(s).Child("starSpeaking").Value.ToString();
        // print("maxStar : "+starSpeaking);
        // maxStarSpeaking = Int32.Parse(starSpeaking);

        // starQueue=snapshot.Child(s).Child("starQueue").Value.ToString();
        // print("maxStar : "+starQueue);
        // maxStarQueue = Int32.Parse(starQueue);

        // starHelpOther=snapshot.Child(s).Child("starHelpOther").Value.ToString();
        // print("maxStar : "+starHelpOther);
        // maxStarHelpOther = Int32.Parse(starHelpOther);

          });
        }
}
