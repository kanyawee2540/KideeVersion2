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
using UnityEngine.EventSystems;
public class ShowScoreForMember : MonoBehaviour
{public string databaseURL = "https://project-75a5c-default-rtdb.firebaseio.com/"; 
    private DatabaseReference reference;
    // public static int countHis;
    //  public int score,scoreIncorrect,fullScore;
    public double keepInorderRealScore;
    public double SpeakingRealScore;
    //  public static int history;
    //  public static string s,inToHis,correctInHis,fullScoreInHis;
      public int c;



    public GameObject starSpeaking1;
    public GameObject starSpeaking2;
    public GameObject starSpeaking3;
    public GameObject starQueue1;
    public GameObject starQueue2;
    public GameObject starQueue3;
     public GameObject starHelpOther1;
    public GameObject starHelpOther2;
    public GameObject starHelpOther3;
     public GameObject starKeepInOrder1;
    public GameObject starKeepInOrder2;
    public GameObject starKeepInOrder3;
    
     [Header("UserData")]
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    public Sprite sprite9;
    public Text nameText;
    public GameObject image;


    //public Text m_score,m_fullScore,m_realScore,m_history;

    void Start()
    {
            
        starSpeaking1.SetActive(false);
        starSpeaking2.SetActive(false);
        starSpeaking3.SetActive(false);
        starQueue1.SetActive(false);
        starQueue2.SetActive(false);
        starQueue3.SetActive(false);
        starHelpOther1.SetActive(false);
        starHelpOther2.SetActive(false);
        starHelpOther3.SetActive(false);
        starKeepInOrder1.SetActive(false);
        starKeepInOrder2.SetActive(false);
        starKeepInOrder3.SetActive(false);

            //     reference = FirebaseDatabase.DefaultInstance.RootReference;
    //     FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
        
    //     FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    // {  
    //     DataSnapshot snapshot = task.Result;
    //     s = snapshot.Child(AddmemberManager.buttonKey).Child("keepInorderHistory").Value.ToString();
    //     history = Int32.Parse(s);
    //     history +=1;
    //     inToHis = "History"+history;
    //     //ก้อน full score//
    //     fullScoreInHis = snapshot.Child(AddmemberManager.buttonKey).Child("keepInorderFullScore").Value.ToString();
    //     fullScore = Int32.Parse(fullScoreInHis);

    //     //ก้อน score //
    //     correctInHis = snapshot.Child(AddmemberManager.buttonKey).Child("KeepInorder").Child("ScoreForShowStarInTheEnd").Child("Correct").Value.ToString();
    //     score = Int32.Parse(correctInHis);


        

    // });

    }
    

    public void CheckOlder() 
    {
       
        c=Int32.Parse(""+AddmemberManager.picList[AddmemberManager.buttonNameMember]);
                print("c:"+c);

        nameText.text="น้อง"+AddmemberManager.nameIncheckList[AddmemberManager.buttonNameMember];
                print("nameText.text:"+AddmemberManager.nameIncheckList[AddmemberManager.buttonNameMember]);
        Invoke("CheckImage",1);
    }
    public void CheckImage() 
    {
        
        // print("----------------Score is "+GetStarForMember.correctInHis);
        // print("full score is "+GetStarForMember.fullScore);
        int showkeepInorder = GetStarForMember.maxStarkeepInorder;
        //SpeakingRealScore = ((double)GetStarForMember.Speakingscore/(double)GetStarForMember.SpeakingfullScore)*100;
        // print("real score is "+realScore);
        
        if(showkeepInorder==3){
            starKeepInOrder1.SetActive(true);
            starKeepInOrder2.SetActive(true);
            starKeepInOrder3.SetActive(true);
            print("star3");
        }else if(showkeepInorder==2){
            starKeepInOrder1.SetActive(true);
            starKeepInOrder2.SetActive(true);
            starKeepInOrder3.SetActive(false);
             print("star2");
            //nostar3.SetActive(true);
        }else if(showkeepInorder==1){
            starKeepInOrder1.SetActive(true);
            starKeepInOrder2.SetActive(false);
            starKeepInOrder3.SetActive(false);
             print("star1");
            //nostar2.SetActive(true);
            //nostar3.SetActive(true);
        }else{
            starKeepInOrder1.SetActive(false);
            starKeepInOrder2.SetActive(false);
            starKeepInOrder3.SetActive(false);
             print("star0");
            //nostar1.SetActive(true);
            //nostar2.SetActive(true);
            //nostar3.SetActive(true);
        }
        if(c==1)
        {
            image.GetComponent<Image>().sprite=sprite1;
        }
        else  if(c==2)
        {
            image.GetComponent<Image>().sprite=sprite2;
        }
        else  if(c==3)
        {
            image.GetComponent<Image>().sprite=sprite3;
        }
         else  if(c==4)
        {
            image.GetComponent<Image>().sprite=sprite4;
        }
        else  if(c==5)
        {
            image.GetComponent<Image>().sprite=sprite5;
        }
        else  if(c==6)
        {
            image.GetComponent<Image>().sprite=sprite6;
        }
        else  if(c==7)
        {
            image.GetComponent<Image>().sprite=sprite7;
        }
        else  if(c==8)
        {
            image.GetComponent<Image>().sprite=sprite8;
        }
        else  if(c==9)
        {
            image.GetComponent<Image>().sprite=sprite9;
        }
        
     
    }
    
}
