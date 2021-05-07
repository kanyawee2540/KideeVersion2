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

public class GetStarForMember : MonoBehaviour
{
    // Start is called before the first frame update
    private DatabaseReference reference;

    public static int keepInorderscore,keepInorderscoreIncorrect,keepInorderfullScore;
    public static int Speakingscore,SpeakingscoreIncorrect,SpeakingfullScore;
    public static int helpOtherscore,helpOtherscoreIncorrect,helpOtherfullScore;

     public double  keepInorderrealScore,SpeakinghelpOther,helpOtherhelpOther;
     public static int keepInorderhistory,Speakinghistory,helpOtherhistory;
     public static string keepInorderinHis,keepInorderinToHis,keepInordercorrectInHis,keepInorderfullScoreInHis;
     public static string SpeakinginHis,SpeakinginToHis,SpeakingcorrectInHis,SpeakingfullScoreInHis;
     public static string helpOtherinHis,helpOtherToHis,helpOthercorrectInHis,helpOtherfullScoreInHis;


     //star
     public static string starkeepInorder;
     public static string starSpeaking;
     public static string starQueue;
     public static string starHelpOther;
     public static int maxStarkeepInorder;
     public static int maxStarSpeaking;
     public static int maxStarQueue;
     public static int maxStarHelpOther;

    void Start()
    {
        
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Getscore()
    {       
            
           string s= ""+RemoveMember.keyList[AddmemberManager.buttonNameMember];
           
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;

        //----------------------keepInorderHistory---------------------------------
        string No1 = snapshot.Child(s).Child("keepInorderHistory").Value.ToString();
        //print("No:"+No1);
        keepInorderhistory = Int32.Parse(No1);
        //history +=1;
        // inToHis = "History"+history;
        // print("inToHis:"+inToHis);


        
        keepInorderfullScoreInHis = snapshot.Child(s).Child("keepInorderFullScore").Value.ToString();
        keepInorderfullScore = Int32.Parse(keepInorderfullScoreInHis);
        //print("history: "+keepInorderhistory+" fullScore: "+keepInorderfullScore);

        //ก้อน score //
        keepInordercorrectInHis = snapshot.Child(s).Child("KeepInorder").Child("History"+keepInorderhistory).Child("Correct").Value.ToString();
        keepInorderscore = Int32.Parse(keepInordercorrectInHis);
        //print("keepInorder history: "+keepInorderhistory+" score:"+keepInorderscore);





        //----------------------keepInorderHistory---------------------------------
        string No2 = snapshot.Child(s).Child("speakingHistory").Value.ToString();
        //print("No:"+No1);
        Speakinghistory = Int32.Parse(No2);
        //history +=1;
        // inToHis = "History"+history;
        // print("inToHis:"+inToHis);

        SpeakingfullScoreInHis = snapshot.Child(s).Child("speakingFullScore").Value.ToString();
        SpeakingfullScore = Int32.Parse(SpeakingfullScoreInHis);
       // print("Speaking history: "+Speakinghistory+" fullScore: "+SpeakingfullScore);

        //ก้อน score //
        // SpeakingcorrectInHis = snapshot.Child(s).Child("Speaking").Child("History"+Speakinghistory).Child("Correct").Value.ToString();
        // Speakingscore = Int32.Parse(SpeakingcorrectInHis);
        // print("history: "+Speakinghistory+" score:"+Speakingscore);
        




        //----------------------helpOtherHistory---------------------------------
        string No3 = snapshot.Child(s).Child("helpOtherHistory").Value.ToString();
        //print("No:"+No1);
        helpOtherhistory = Int32.Parse(No3);
        //history +=1;
        // inToHis = "History"+history;
        // print("inToHis:"+inToHis);
    
        helpOtherfullScoreInHis = snapshot.Child(s).Child("helpOtherFullScore").Value.ToString();
        helpOtherfullScore = Int32.Parse(helpOtherfullScoreInHis);
        //print("helpOther history: "+helpOtherhistory+" fullScore: "+helpOtherfullScore);

        //ก้อน score //
        // helpOthercorrectInHis = snapshot.Child(s).Child("HelpOther").Child("History"+helpOtherhistory).Child("Correct").Value.ToString();
        // helpOtherscore = Int32.Parse(helpOthercorrectInHis);
        // print("helpOther history: "+helpOtherhistory+" score:"+helpOtherscore);
        



        //----------------------Get max Star---------------------------------
        // starkeepInorder=snapshot.Child(s).Child("starKeepInorder").Value.ToString();
        // print("maxStar : "+starkeepInorder);
        // maxStarkeepInorder = Int32.Parse(starkeepInorder);

        // starSpeaking=snapshot.Child(s).Child("").Value.ToString();
        // print("maxStar : "+starSpeaking);
        // maxStarSpeaking = Int32.Parse(starSpeaking);

        // starQueue=snapshot.Child(s).Child("").Value.ToString();
        // print("maxStar : "+starQueue);
        // maxStarQueue = Int32.Parse(starQueue);

        // starHelpOther=snapshot.Child(s).Child("").Value.ToString();
        // print("maxStar : "+starHelpOther);
        // maxStarHelpOther = Int32.Parse(starHelpOther);




        
    });

    }
}
