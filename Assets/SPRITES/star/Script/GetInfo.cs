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
    public static ArrayList DateListSpeaking = new ArrayList();
    public static ArrayList StarListSpeaking = new ArrayList();
    
    public static ArrayList DateListKeepInorder = new ArrayList();
    public static ArrayList StarListKeepInorder = new ArrayList();

    public static ArrayList DateListHelpOther = new ArrayList();
    public static ArrayList StarListHelpOther = new ArrayList();

     public static ArrayList DateListQueue = new ArrayList();
    public static ArrayList StarListQueue = new ArrayList();



    public static int keepInorderHistory,Speakinghistory,HelpOtherhistory;
   



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
            StarListSpeaking.Clear();
            DateListKeepInorder.Clear();
            StarListKeepInorder.Clear();
            DateListHelpOther.Clear();
            StarListHelpOther.Clear();
            DateListQueue.Clear();
            StarListQueue.Clear();


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
        // string No4 = snapshot.Child(s).Child("keepInorderHistory").Value.ToString();
        // keepInorderHistory = Int32.Parse(No2);
        
        
        //print("No:"+No1);
        //history +=1;
        // inToHis = "History"+history;
        // print("inToHis:"+inToHis);
        for(int i=0;i<Speakinghistory;i++)
        {
            int count = i+1;
            string date = snapshot.Child(s).Child("KeepInorder").Child("History"+count).Child("Date").Value.ToString();
            print("KeepInorder history: "+count+" date: "+date);
            DateListSpeaking.Add(date);

            string star = snapshot.Child(s).Child("Speaking").Child("History"+count).Child("Star").Value.ToString();
            print("KeepInorder history: "+count+" Star: "+star);
            StarListSpeaking.Add(star);
            

           // keepInorderscore = Int32.Parse(keepInordercorrectInHis);
        }


         for(int i=0;i<keepInorderHistory;i++)
        {
            int count = i+1;
            string date = snapshot.Child(s).Child("KeepInorder").Child("History"+count).Child("Date").Value.ToString();
            print(" KeepInorder history: "+count+" date: "+date);
            DateListKeepInorder.Add(date);

            string star = snapshot.Child(s).Child("KeepInorder").Child("History"+count).Child("Star").Value.ToString();
            print(" KeepInorder history: "+count+" Star: "+star);
            StarListKeepInorder.Add(star);
            

           // keepInorderscore = Int32.Parse(keepInordercorrectInHis);
        }

         for(int i=0;i<HelpOtherhistory;i++)
        {
            int count = i+1;
            string date = snapshot.Child(s).Child("HelpOther").Child("History"+count).Child("Date").Value.ToString();
            print(" HelpOther history: "+count+" date: "+date);
            DateListHelpOther.Add(date);

            string star = snapshot.Child(s).Child("HelpOther").Child("History"+count).Child("Star").Value.ToString();
            print(" HelpOther history: "+count+" Star: "+star);
            StarListHelpOther.Add(star);
            

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
