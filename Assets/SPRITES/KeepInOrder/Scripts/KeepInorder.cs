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


public class KeepInorder : MonoBehaviour
{ 
    public string databaseURL = "https://project-75a5c-default-rtdb.firebaseio.com/"; 
    private DatabaseReference reference;
     public static int countHis;
     public int score,scoreIncorrect;
     public static int history;
     public static string s;
     public static string member;
     public static string day,time;
    
    [SerializeField]
    public GameObject winText1;
    public GameObject winText2;
    public GameObject BeforePlay;
    public GameObject BeforePlay1;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    
    public GameObject apple;
     public static int fullScore,scoreInHis,his;
     public static double realScore;
     public static string memberurl,fullScoreInHis,correctInHis,No;
     public static int controlHis;
     public static string inToHis,inToHis2;
    public Text m_score,showScore,m_fullScore,m_realScore,m_history,showStarr;

    public int SaveStar;
    public int star;

    // Start is called before the first frame update
    void Start()
    {
        
        memberurl = ""+RemoveMember.keyList[AddmemberManager.buttonNameMember];
        print("member url is "+memberurl);
        
        // winText1.SetActive(false);
        // winText2.SetActive(false);
        // star1.SetActive(true);
        // star2.SetActive(true);
        // star3.SetActive(true);
        // nostar1.SetActive(true);
        // nostar2.SetActive(true);
        // nostar3.SetActive(true);

        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
        
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        s = snapshot.Child(memberurl).Child("keepInorderHistory").Value.ToString();
        history = Int32.Parse(s);
        history +=1;


    });  
    }
    

    // Update is called once per frame
    void Update()
    {
        //scene1
        if(GreenDrag.locked&& GreenDrag2.locked&& RedDrag.locked&& RedDrag2.locked&& YellowDrag2.locked&& YellowDrag.locked){
            GreenDrag.locked = false;
            GreenDrag2.locked = false;
            RedDrag.locked = false; 
            RedDrag.locked = false;  
            YellowDrag2.locked = false;
            YellowDrag.locked = false;
            winText1.SetActive(true);
            BeforePlay.SetActive(false);
            correct();
            saveinTheEnd();
        }
        //scene2
        if(book1.locked&&book2.locked&&toy1.locked&&toy2.locked&&toy3.locked&&toy4.locked)
        {
            book1.locked = false;
            book2.locked = false;
            toy1.locked = false;
            toy2.locked = false;
            toy3.locked = false;
            toy4.locked = false;
            winText2.SetActive(true);
            BeforePlay1.SetActive(false);
            correct();
            saveinTheEnd();

        }
        
        
    }
    public void correct(){
        score += 1;
        print("score is "+score);

        //test mo
        //int fullscore = GetStarForMember.keepInorderfullScore;
       // print("fullscore is "+fullscore);
        double scoreStar= ((double)score/(double)3)*100;
        print("scoreStar is "+scoreStar);
        
        if(scoreStar>60){
            star=3;
            print("Star 3");
            
        }else if(scoreStar<=60 && scoreStar>40){
            star=2;
            print("Star 2");
            
        }else if(scoreStar<=40 && scoreStar>=1){
            star=1;
            print("Star 1");
            
        }else{
            star=0;
            print("Star 0");
           
        }

        //Check star in Max
          if(star>GetStarForMember.maxStarkeepInorder){
            SaveStar=star;
            print("SaveStar"+SaveStar+" GetStarForMember.maxStarkeepInorder "+GetStarForMember.maxStarkeepInorder);
            
        }else if(star<=GetStarForMember.maxStarkeepInorder){
            SaveStar=GetStarForMember.maxStarkeepInorder;
             print("SaveStar"+SaveStar+" GetStarForMember.maxStarkeepInorder "+GetStarForMember.maxStarkeepInorder);
            
        }


    }
    public void incorrect(){
        scoreIncorrect += 1;
        print("scoreIncorrect is "+scoreIncorrect);
    }
    public void save(){
        day = System.DateTime.Now.ToString("yyyy/MM/dd"); 
        DateTime now = DateTime.Now;
        string time = now.ToString("T");
        string His = "History"+history;
        reference.Child(LoginManager.localId).Child(memberurl).Child("keepInorderHistory").SetValueAsync(history);
        reference.Child(LoginManager.localId).Child(memberurl).Child("KeepInorder").Child(His).Child("Date").SetValueAsync(day);
        reference.Child(LoginManager.localId).Child(memberurl).Child("KeepInorder").Child(His).Child("Time").SetValueAsync(time);
        reference.Child(LoginManager.localId).Child(memberurl).Child("KeepInorder").Child(His).Child("Correct").SetValueAsync(score);
        reference.Child(LoginManager.localId).Child(memberurl).Child("KeepInorder").Child(His).Child("Incorrect").SetValueAsync(scoreIncorrect);
        reference.Child(LoginManager.localId).Child(memberurl).Child("KeepInorder").Child(His).Child("Star").SetValueAsync(star);

       
        goToMenu();
    }
    public void goToMenu(){
        SceneManager.LoadScene("ChooseManu");
    }
        public void saveinTheEnd(){
        day = System.DateTime.Now.ToString("yyyy/MM/dd"); 
        DateTime now = DateTime.Now;
        string time = now.ToString("T");
        string His = "History"+history;
        reference.Child(LoginManager.localId).Child(memberurl).Child("keepInorderHistory").SetValueAsync(history);
        reference.Child(LoginManager.localId).Child(memberurl).Child("KeepInorder").Child(His).Child("Date").SetValueAsync(day);
        reference.Child(LoginManager.localId).Child(memberurl).Child("KeepInorder").Child(His).Child("Time").SetValueAsync(time);
        reference.Child(LoginManager.localId).Child(memberurl).Child("KeepInorder").Child(His).Child("Correct").SetValueAsync(score);
        reference.Child(LoginManager.localId).Child(memberurl).Child("KeepInorder").Child(His).Child("Incorrect").SetValueAsync(scoreIncorrect);
        reference.Child(LoginManager.localId).Child(memberurl).Child("KeepInorder").Child(His).Child("Star").SetValueAsync(star);


        //push star in Max
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("starKeepInorder").SetValueAsync(SaveStar);
    Showscore();
    showStar();
    
    }

    public void Exit(){     //ออกโดยยังไม่ได้เล่น
    
        day = System.DateTime.Now.ToString("yyyy/MM/dd"); 
        DateTime now = DateTime.Now;
        string time = now.ToString("T");
        string His = "History"+history;
        reference.Child(LoginManager.localId).Child(memberurl).Child("keepInorderHistory").SetValueAsync(history);
        reference.Child(LoginManager.localId).Child(memberurl).Child("KeepInorder").Child(His).Child("Date").SetValueAsync(day);
        reference.Child(LoginManager.localId).Child(memberurl).Child("KeepInorder").Child(His).Child("Time").SetValueAsync(time);
        reference.Child(LoginManager.localId).Child(memberurl).Child("KeepInorder").Child(His).Child("Correct").SetValueAsync(score);
        reference.Child(LoginManager.localId).Child(memberurl).Child("KeepInorder").Child(His).Child("Incorrect").SetValueAsync(scoreIncorrect);
        reference.Child(LoginManager.localId).Child(memberurl).Child("KeepInorder").Child(His).Child("Star").SetValueAsync(star);

        Showscore();
        showStar();
    
    }
        public void showStar(){
       
        print("in His "+No);
        print("----------------Score in keep in order is "+scoreInHis);
        print("full score in keep in order is "+fullScore);
        realScore = Math.Round(((double)scoreInHis/(double)fullScore)*100, 2);
        print("real score is "+realScore);

        if(star==3){
            print("incase >60");
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            m_score.text = "3 ดาว";
        }else if(star==2){
            print("incase <=60");
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
            m_score.text = "2 ดาว";
        }else if(star==1){
            print("incase <=40");
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
            m_score.text = "1 ดาว";
        }else{
            print("incase other (mean 0)");
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
            m_score.text = "0 ดาว";
        }

}
      public void Showscore()
    {       memberurl = AddmemberManager.memberURL1;
           
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        No = snapshot.Child(memberurl).Child("keepInorderHistory").Value.ToString();
        print("No:"+No);
         history = Int32.Parse(No);

        fullScoreInHis = snapshot.Child(memberurl).Child("keepInorderFullScore").Value.ToString();
        fullScore = Int32.Parse(fullScoreInHis);
        print("fullScore:"+fullScore);

        //ก้อน score //
        correctInHis = snapshot.Child(memberurl).Child("KeepInorder").Child("History"+No).Child("Correct").Value.ToString();
        scoreInHis = Int32.Parse(correctInHis);
        print("score:"+scoreInHis);
        


        
    });
    }
}
