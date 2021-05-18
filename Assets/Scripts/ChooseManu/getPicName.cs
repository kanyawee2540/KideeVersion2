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

public class getPicName : MonoBehaviour
{
    // Start is called before the first frame update
    private DatabaseReference reference;
    public static string name;
    public static int pic;

    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  public void PicAndName()
        {
            string s= ""+RemoveMember.keyList[AddmemberManager.buttonNameMember];
           
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;

              //----------------------Get max Star---------------------------------
        string pics=snapshot.Child(s).Child("pic").Value.ToString();
        print("pic : "+pics);
        pic = Int32.Parse(pics);

        name=snapshot.Child(s).Child("m_name").Value.ToString();
        print("m_name : "+name);
        //pic = Int32.Parse(pics);

        

       
          });
        }
}
