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

public class test : MonoBehaviour
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
        print("Getscore: "+keepInorderhistory+" fullScore: "+keepInorderfullScore);

        //ก้อน score //
        keepInordercorrectInHis = snapshot.Child(s).Child("KeepInorder").Child("History"+keepInorderhistory).Child("Correct").Value.ToString();
        keepInorderscore = Int32.Parse(keepInordercorrectInHis);
        print("Getscore : "+keepInorderhistory+" score:"+keepInorderscore);


        


        
    });

    }
}
