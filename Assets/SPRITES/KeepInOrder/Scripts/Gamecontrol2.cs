using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamecontrol2 : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField]
    public GameObject winText1;
    public GameObject room;
    public GameObject questionUI;
    public GameObject correctUI;
   

    // Start is called before the first frame update
    void Start()
    {
        questionUI.SetActive(true);
        correctUI.SetActive(false);
         winText1.SetActive(false);
        
    }
    

    // Update is called once per frame
    void Update()
    {
       
        if(book1.locked && book2.locked && GreenDrag.locked && GreenDrag2.locked&& RedDrag.locked
        && RedDrag2.locked&& YellowDrag2.locked&& YellowDrag.locked){
            questionUI.SetActive(false);
            correctUI.SetActive(true);
        }
      
        
    }
}
