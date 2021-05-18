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

public class GetMaxInchooseManu : MonoBehaviour
{
    private DatabaseReference reference;

     //star
     public static string starkeepInorder;
     public static string starSpeaking;
     public static string starQueue;
     public static string starHelpOther;
     public static int maxStarkeepInorder;
     public static int maxStarSpeaking;
     public static int maxStarQueue;
     public static int maxStarHelpOther;

    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
        GetMaxscore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void GetMaxscore()
        {
            string s= ""+RemoveMember.keyList[AddmemberManager.buttonNameMember];
           
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;

              //----------------------Get max Star---------------------------------
        starkeepInorder=snapshot.Child(s).Child("starKeepInorder").Value.ToString();
        print("maxStarkeepInorder : "+starkeepInorder);
        maxStarkeepInorder = Int32.Parse(starkeepInorder);

        starSpeaking=snapshot.Child(s).Child("starSpeaking").Value.ToString();
        print("maxStarSpeaking : "+starSpeaking);
        maxStarSpeaking = Int32.Parse(starSpeaking);

        starQueue=snapshot.Child(s).Child("starQueue").Value.ToString();
        print("maxStarQueue : "+starQueue);
        maxStarQueue = Int32.Parse(starQueue);

        starHelpOther=snapshot.Child(s).Child("starHelpOther").Value.ToString();
        print("maxStarHelpOther : "+starHelpOther);
        maxStarHelpOther = Int32.Parse(starHelpOther);

       
          });
        }
}
