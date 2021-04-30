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
    public GameObject winText3;
    public GameObject room;
    public GameObject BeforePlay;
    public GameObject BeforePlay1;

    // Start is called before the first frame update
    void Start()
    {

        winText1.SetActive(false);
        winText2.SetActive(false);
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
        
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        s = snapshot.Child(AddmemberManager.buttonKey).Child("keepInorderHistory").Value.ToString();
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
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("keepInorderHistory").SetValueAsync(history);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("KeepInorder").Child(His).Child("Date").SetValueAsync(day);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("KeepInorder").Child(His).Child("Time").SetValueAsync(time);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("KeepInorder").Child(His).Child("Correct").SetValueAsync(score);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("KeepInorder").Child(His).Child("Incorrect").SetValueAsync(scoreIncorrect);
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
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("keepInorderHistory").SetValueAsync(history);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("KeepInorder").Child(His).Child("Date").SetValueAsync(day);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("KeepInorder").Child(His).Child("Time").SetValueAsync(time);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("KeepInorder").Child(His).Child("Correct").SetValueAsync(score);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("KeepInorder").Child(His).Child("Incorrect").SetValueAsync(scoreIncorrect);
    }
}
