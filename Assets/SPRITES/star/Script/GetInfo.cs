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
    public static ArrayList DateList = new ArrayList();
    public static ArrayList StarList = new ArrayList();


    public static int keepInorderhistory,Speakinghistory,helpOtherhistory;
   



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
            DateList.Clear();
            StarList.Clear();
            string s= ""+RemoveMember.keyList[StarCollection.buttonStarCount];
;
           
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;


        string No = snapshot.Child(s).Child("speakingHistory").Value.ToString();
        //print("No:"+No1);
        Speakinghistory = Int32.Parse(No);
        //history +=1;
        // inToHis = "History"+history;
        // print("inToHis:"+inToHis);
        for(int i=0;i<Speakinghistory;i++)
        {
            int count = i+1;
            string date = snapshot.Child(s).Child("Speaking").Child("History"+count).Child("Date").Value.ToString();
            print(" history: "+count+" date: "+date);
            DateList.Add(date);

            string star = snapshot.Child(s).Child("Speaking").Child("History"+count).Child("Star").Value.ToString();
            print(" history: "+count+" Star: "+star);
            StarList.Add(star);
            

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
