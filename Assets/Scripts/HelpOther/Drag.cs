using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Drag : MonoBehaviour
{
    public static event Action PuzzleDone = delegate{};
    
    [SerializeField]
    private Transform standPositition;
    private Vector2 initalPosition;
    private Renderer rend;
    private float deltaX,deltaY;
    private bool moveAlowed;
    private bool locked;
    // Start is called before the first frame update
    private void Start()
    {
        initalPosition = transform.position;
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
   private void Update()
    {
        if(Input.touchCount >0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                if(GetComponent<Collider2D>()== Physics2D.OverlapPoint(touchPos))
                {
                    moveAlowed = true;
                    rend.sortingOrder =3;
                    deltaX = touchPos.x - transform.position.x;
                    deltaY = touchPos.y - transform.position.y;

                }
                break;

                 case TouchPhase.Moved:
                 if(moveAlowed)
                 transform.position = new Vector2(touchPos.x-deltaX,touchPos.y-deltaY);

                 break;

                 case TouchPhase.Ended:
                 moveAlowed = false;
                 rend.sortingOrder =2;
                 if(Mathf.Abs(transform.position.x-standPositition.position.x)<= 1f &&
                 Mathf.Abs(transform.position.y-standPositition.position.y)<= 5f)
                 {
                     switch (PyramidControl.slotsOccupied)
                     {
                         case 0:
                         transform.position = new Vector2(standPositition.position.x,-3.15f);
                         PyramidControl.slotsOccupied=1;
                         break;
                         
                          case 1 :
                         transform.position = new Vector2(standPositition.position.x,-1.5f);
                         PyramidControl.slotsOccupied=2;
                         break;

                         case 2 :
                         transform.position = new Vector2(standPositition.position.x,0.15f);
                         PyramidControl.slotsOccupied=3;
                         break;

                         case 3 :
                         transform.position = new Vector2(standPositition.position.x,1.7f);
                         PuzzleDone();
                         break;
                     }

                     locked = true;
                     }
                     else
                     {

                          transform.position = new Vector2(initalPosition.x,initalPosition.y);
                     }
                        
                        break;                     
                

                     }
                 }


            }
        

    
}
