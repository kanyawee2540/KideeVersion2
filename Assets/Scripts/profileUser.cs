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
public class profileUser : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite sprite0;
    public Sprite sprite1;

    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;


    public Button button;
    public int gender;
    public string name1;
    public Text nametext;
    public Text nametext2;
    public Text nametext3;
    public Text nametext4;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Profilemanu",1);
       
    } 
    public void ChangeImg1()
    {
        gender=AddmemberManager.gender;
        name1=AddmemberManager.name;
        if(gender==0){
            print("gender 0");
        image1.GetComponent<Image>().sprite=sprite0;
        }else if(gender==1){
           image1.GetComponent<Image>().sprite=sprite1;
            print("gender 1");
        }
        nametext.text ="ครู"+ name1;
       // image.GetComponent<Image>().sprite=sprite1;
    }
      public void ChangeImg2()
    {
        gender=AddmemberManager.gender;
        name1=AddmemberManager.name;
        if(gender==0){
            //print("gender 0");
        image2.GetComponent<Image>().sprite=sprite0;
        }else if(gender==1){
           image2.GetComponent<Image>().sprite=sprite1;
            //print("gender 1");
        }
        nametext2.text ="ครู"+ name1;

       // image.GetComponent<Image>().sprite=sprite1;
    }
      public void ChangeImg3()
    {
        name1=AddmemberManager.name;
        gender=AddmemberManager.gender;
        if(gender==0){
            //print("gender 0");
        image3.GetComponent<Image>().sprite=sprite0;
        }else if(gender==1){
           image3.GetComponent<Image>().sprite=sprite1;
            //print("gender 1");
        }
        nametext3.text ="ครู"+ name1;
       // image.GetComponent<Image>().sprite=sprite1;
    }
     public void Profilemanu()
    {
        name1=AddmemberManager.name;
        gender=AddmemberManager.gender;
        if(gender==0){
            //print("gender 0");
        image4.GetComponent<Image>().sprite=sprite0;
        }else if(gender==1){
           image4.GetComponent<Image>().sprite=sprite1;
           // print("gender 1");
        }
        nametext4.text ="ครู"+ name1;
       // image.GetComponent<Image>().sprite=sprite1;
    }
}
