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

public class CilckProfile : MonoBehaviour
{
     [Header("Profile")]
    public GameObject image1;
    public Text nameText;
    public InputField Field;
   [Header("Sprite")]
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
     public Sprite sprite4;
     public Sprite sprite5;
     public Sprite sprite6;
     public Sprite sprite7;
    public Sprite sprite8;
    public Sprite sprite9;
     [Header("Button")]
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button button7;
    public Button button8;
    public Button button9;
    
    [Header("Count")]
    public int Count;
    public string KeyClick;
    public string nameField;
    private DatabaseReference reference;

    public int c;

    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
        
        button1.onClick.AddListener(delegate{Profile1();});
        button2.onClick.AddListener(delegate{Profile2();});
        button3.onClick.AddListener(delegate{Profile3();});
        button4.onClick.AddListener(delegate{Profile4();});
        button5.onClick.AddListener(delegate{Profile5();});
        button6.onClick.AddListener(delegate{Profile6();});
        button7.onClick.AddListener(delegate{Profile7();});
        button8.onClick.AddListener(delegate{Profile8();});
        button9.onClick.AddListener(delegate{Profile9();});
        CheckOlder();



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
        if(c==1)
        {
            image1.GetComponent<Image>().sprite=sprite1;
        }
        else  if(c==2)
        {
            image1.GetComponent<Image>().sprite=sprite2;
        }
        else  if(c==3)
        {
            image1.GetComponent<Image>().sprite=sprite3;
        }
         else  if(c==4)
        {
            image1.GetComponent<Image>().sprite=sprite4;
        }
        else  if(c==5)
        {
            image1.GetComponent<Image>().sprite=sprite5;
        }
        else  if(c==6)
        {
            image1.GetComponent<Image>().sprite=sprite6;
        }
        else  if(c==7)
        {
            image1.GetComponent<Image>().sprite=sprite7;
        }
        else  if(c==8)
        {
            image1.GetComponent<Image>().sprite=sprite8;
        }
        else  if(c==9)
        {
            image1.GetComponent<Image>().sprite=sprite9;
        }
        
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Profile1()
    {
        image1.GetComponent<Image>().sprite=sprite1;
        for(int i = 0 ; i < RemoveMember.keyList.Count; i++){
         print("keyList "+RemoveMember.keyList[i]);

    }
    
    print("buttonNameMember "+RemoveMember.keyList[AddmemberManager.buttonNameMember]);
    KeyClick=""+RemoveMember.keyList[AddmemberManager.buttonNameMember];
         Count=1;

    }

    private void Profile2()
    {
        image1.GetComponent<Image>().sprite=sprite2;
        KeyClick=""+RemoveMember.keyList[AddmemberManager.buttonNameMember];
        Count=2;
    }
    private void Profile3()
    {
        image1.GetComponent<Image>().sprite=sprite3;
        KeyClick=""+RemoveMember.keyList[AddmemberManager.buttonNameMember];
        Count=3;
    }
    private void Profile4()
    {
        image1.GetComponent<Image>().sprite=sprite4;
        KeyClick=""+RemoveMember.keyList[AddmemberManager.buttonNameMember];
        Count=4;
    }
    private void Profile5()
    {
        image1.GetComponent<Image>().sprite=sprite5;
        KeyClick=""+RemoveMember.keyList[AddmemberManager.buttonNameMember];
        Count=5;
    }
    private void Profile6()
    {
        image1.GetComponent<Image>().sprite=sprite6;
        KeyClick=""+RemoveMember.keyList[AddmemberManager.buttonNameMember];
        Count=6;
    }
    private void Profile7()
    {
        image1.GetComponent<Image>().sprite=sprite7;
        KeyClick=""+RemoveMember.keyList[AddmemberManager.buttonNameMember];
        Count=7;
    }
    private void Profile8()
    {
        image1.GetComponent<Image>().sprite=sprite8;
        KeyClick=""+RemoveMember.keyList[AddmemberManager.buttonNameMember];
        Count=8;
    }
    private void Profile9()
    {
        image1.GetComponent<Image>().sprite=sprite9;
        KeyClick=""+RemoveMember.keyList[AddmemberManager.buttonNameMember];
        Count=9;
    }

     public void InputField()
    {
       

    }

    public void ConfirmButton()
    {
        nameField=Field.text;
        if(!nameField.Equals(""))
        {
        reference.Child(LoginManager.localId).Child(KeyClick).Child("m_name").SetValueAsync(nameField);
        nameText.text = nameField;
        Field.text="";
        }
        reference.Child(LoginManager.localId).Child(KeyClick).Child("pic").SetValueAsync(Count);

    }
}
