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

public class tryQ11 : MonoBehaviour
{
    public string databaseURL = "https://project-75a5c-default-rtdb.firebaseio.com/"; 
    private DatabaseReference reference;
     public static int countHis;
     public int score,scoreIncorrect;
     public static int history;
     public static string s,inToHis,correctInHis,incorrectInHis;
     public static string member;
     public static string day,time;
    public GameObject questionUIQ1;
    public GameObject correctUIQ1;

        public Text m_MyText3;
        public static string memberurl;
    //public GameObject inCorrectUI;
    // Start is called before the first frame update
    void Start()
    {
        memberurl = ""+RemoveMember.keyList[AddmemberManager.buttonNameMember];
        print("member url is "+memberurl);
        questionUIQ1.SetActive(true);
        correctUIQ1.SetActive(false);
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
        
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        s = snapshot.Child(memberurl).Child("queueHistory").Value.ToString();
        inToHis = "History"+s;
        correctInHis = snapshot.Child(memberurl).Child("Queue").Child(inToHis).Child("Correct").Value.ToString();
        incorrectInHis = snapshot.Child(memberurl).Child("Queue").Child(inToHis).Child("Incorrect").Value.ToString();
        score = Int32.Parse(correctInHis);
        scoreIncorrect = Int32.Parse(incorrectInHis);
        history = Int32.Parse(s);

    });  
    }

    // Update is called once per frame
    void Update()
    {
        if (Q1DragS1.locked)
        {
            questionUIQ1.SetActive(false);
            correctUIQ1.SetActive(true);
            Q1DragS1.locked = false;
            score += 1;
            saveinTheEnd();
        }
        if (Q1DragS2.locked || Q1DragS3.locked || Q1DragS4.locked)
        {
            Q1DragS2.locked = false;
            Q1DragS3.locked = false;
            Q1DragS4.locked = false;
            scoreIncorrect += 1;
            saveinTheEnd();
            GotoinCorrectUI();
            /*GotoinCorrectUI();*/
            

        }

    }
    public void goToQ2()
    {
        SceneManager.LoadScene("Q2");
    }
    public void tryQ1Again()
    {
        SceneManager.LoadScene("Q1");
    }
    public void GotoinCorrectUI()
    {
        SceneManager.LoadScene("Q1Incorrect"); 
    }
    public void correct(){
        score += 1;
        print("score is "+score);
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
        reference.Child(LoginManager.localId).Child(memberurl).Child("queueHistory").SetValueAsync(history);
        reference.Child(LoginManager.localId).Child(memberurl).Child("Queue").Child(His).Child("Date").SetValueAsync(day);
        reference.Child(LoginManager.localId).Child(memberurl).Child("Queue").Child(His).Child("Time").SetValueAsync(time);
        reference.Child(LoginManager.localId).Child(memberurl).Child("Queue").Child(His).Child("Correct").SetValueAsync(score);
        reference.Child(LoginManager.localId).Child(memberurl).Child("Queue").Child(His).Child("Incorrect").SetValueAsync(scoreIncorrect);
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
        reference.Child(LoginManager.localId).Child(memberurl).Child("queueHistory").SetValueAsync(history);
        reference.Child(LoginManager.localId).Child(memberurl).Child("Queue").Child(His).Child("Date").SetValueAsync(day);
        reference.Child(LoginManager.localId).Child(memberurl).Child("Queue").Child(His).Child("Time").SetValueAsync(time);
        reference.Child(LoginManager.localId).Child(memberurl).Child("Queue").Child(His).Child("Correct").SetValueAsync(score);
        reference.Child(LoginManager.localId).Child(memberurl).Child("Queue").Child(His).Child("Incorrect").SetValueAsync(scoreIncorrect);
    }
}
