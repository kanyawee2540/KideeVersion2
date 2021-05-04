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
    public static int countHis;
     public int score,scoreIncorrect,fullScore;
     public double realScore;
     public static int history;
     public static string s,inToHis,correctInHis,fullScoreInHis;
     public int c;



    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject nostar1;
    public GameObject nostar2;
    public GameObject nostar3;
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
            
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        nostar1.SetActive(false);
        nostar2.SetActive(false);
        nostar3.SetActive(false);
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
         print("----------------Score is "+StarCollection.correctInHis);
        print("full score is "+StarCollection.fullScore);
        realScore = ((double)StarCollection.score/(double)StarCollection.fullScore)*100;
        print("real score is "+realScore);
        // m_score.text = "score is "+correctInHis;
        // m_fullScore.text = "full score is "+fullScore;
        // m_realScore.text = "realScore score is "+realScore;
        // m_history.text = "in history "+history;
        if(realScore>60){
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }else if(realScore<=60 && realScore>40){
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
            //nostar3.SetActive(true);
        }else if(realScore<=40 && realScore>=1){
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
            //nostar2.SetActive(true);
            //nostar3.SetActive(true);
        }else{
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
            //nostar1.SetActive(true);
            //nostar2.SetActive(true);
            //nostar3.SetActive(true);
        }
        c=Int32.Parse(""+AddmemberManager.picList[AddmemberManager.buttonNameMember]);
                print("c:"+c);

        nameText.text="น้อง"+AddmemberManager.nameIncheckList[AddmemberManager.buttonNameMember];
                print("nameText.text:"+AddmemberManager.nameIncheckList[AddmemberManager.buttonNameMember]);
        Invoke("CheckImage",1);
    }
    public void CheckImage() 
    {
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
