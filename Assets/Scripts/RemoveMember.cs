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

public class RemoveMember : MonoBehaviour
{

     [SerializeField]
    private Button[] remove;
    private Button[] buttons;
    public InputField passwordRemoveField;

    private DatabaseReference reference;
    // Start is called before the first frame update

    public static int count;
    public string passwordUser;

   public static ArrayList keyList = new ArrayList();
    public static ArrayList nameList = new ArrayList();
    

    public string buttonKey;
    public int buttonName;

    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
        //GetCount();
        RaadAllData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public int GetCount() 
    {
    
         FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        string ss = snapshot.Child("m_count").Value.ToString();
       // print(ss);
        //print(ss+" GetCount");
        count=Int32.Parse(ss);
    passwordUser = snapshot.Child("User").Child("password").Value.ToString();
    });  
    return count;
}

 public void RemoveButtons(){
       
        print("remove :"+count);
       for(int i=0;i<GetCount();i++){
        remove[i].gameObject.SetActive(true); 
       }
        
    
       
        
    }
     public void ManuRemove()
     {        //RaadAllData();
              GetCount();
              
              Invoke("RemoveButtons", 2); 
             
     }

   public void ChangeRemoveButtons(){
       
        for(int i=0;i<GetCount();i++){
        remove[i].gameObject.SetActive(false); 
        }
       
       
       // dddddd();
       
       // AddmemberManager.AddButtons();
    }
     public void Remove()
     {
              GetCount();
              Invoke("ChangeRemoveButtons", 2); 
     }

      
    public void RaadAllData()
    {
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId)
        // หากข้อมูลมีการเปลี่ยนแหลงให้ทำการอ่านและแสดง
        .ValueChanged += HandleValueChanged;
    }

    private void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        // อ่าน Key เพื่อใช้แสดงผล
        List<string> keys = args.Snapshot.Children.Select(s => s.Key).ToList();
        foreach (var key in keys)
        {
            DisplayData(args.Snapshot, key);
        }
    }
    // ใช้สำหรับ แสดงข้อมูลที่โหลดครับ
    void DisplayData(DataSnapshot snapshot, string key)
    {
        string j = snapshot.Child(key).GetRawJsonValue();
        Member u = JsonUtility.FromJson<Member>(j);
       // Debug.Log(u.no+" "+u.m_name+" "+u.m_password);
        //Debug.Log("key "+key);
       getNameMember(u.m_name);
       if(!keyList.Contains(key)&&!key.Contains("User")){
        getKeyMember(key);
        
       }
       
    }
    // Update is called once per frame
   
    public void dddddd(){
    for(int i = 0 ; i < nameList.Count; i++){
        // print("nameList "+nameList[i] + ", ");

    }
     }
     void getNameMember(string name)
    {

        nameList.Add(name);
        //nameMem=name;
         
      
    }
    void getKeyMember(string key)
    {

        keyList.Add(key);
        
         
    }
   
    public void KeyButton(Button button)
    {
  
         RaadAllData();
        if(button.name=="0"){
             buttonName=0;   
             buttonKey =""+keyList[0];
           
        }else if(button.name=="1"){
             buttonName=1;  
            buttonKey =""+keyList[1];
           
        }else if(button.name=="2"){
             buttonName=2;  
            buttonKey =""+keyList[2];
           
        }else if(button.name=="3"){
             buttonName=3;  
             buttonKey =""+keyList[3];
           
        }else if(button.name=="4"){
             buttonName=4;  
             buttonKey =""+keyList[4];
    
        }else if(button.name=="5"){
             buttonName=5;  
             buttonKey =""+keyList[5];
    
        }else if(button.name=="6"){
             buttonName=6;  
             buttonKey =""+keyList[6];
    
        }else if(button.name=="7"){
             buttonName=7;  
             buttonKey =""+keyList[7];
    
        }else if(button.name=="8"){
             buttonName=8;  
             buttonKey =""+keyList[8];
    
        }else if(button.name=="9"){
             buttonName=9;  
             buttonKey =""+keyList[9];
    
        }else if(button.name=="10"){
             buttonName=10;  
             buttonKey =""+keyList[10];
    
        }

    }

    public void CheckPasswordRemovemember()
    {
         //string p =""+passwordList[buttonName];
         string pf =passwordRemoveField.text;
           // print("passwordUser " +passwordUser);
         if(String.Equals(passwordUser,pf)){
            print("pass");
           OnSubmitRemove();
            
         }else{
              print("not pass");
         } 
    }
  
     public void OnSubmitRemove()
    {       
        
            

               // print("buttonKey  "+buttonKey);
             // print("buttonName  "+buttonName);
            Remove();
            reference.Child(LoginManager.localId).Child(buttonKey).RemoveValueAsync();
            keyList.RemoveAt(buttonName);
            for(int i = 0 ; i < keyList.Count; i++){
             //print("keyList "+keyList[i]);

    }
            count--;
            reference.Child(LoginManager.localId).Child("m_count").SetValueAsync(count);
           
           


    }

         
}
