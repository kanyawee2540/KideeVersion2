using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q2DragS4 : MonoBehaviour
{
    [SerializeField]
    private Transform theBus;
    public static Vector2 initalPosition;
    private float deltaX, deltaY;
    public static bool locked;
    private bool Dragging = false;
    // Start is called before the first frame update
    void Start()
    {
        initalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && !locked)
        {

            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                        Dragging = true;

                    }
                    break;

                // case TouchPhase.Moved:
                // if(GetComponent<Collider2D>()==Physics2D.OverlapPoint(touchPos))
                // {
                //     transform.position = new Vector2(touchPos.x-deltaX,touchPos.y-deltaY);

                // }
                // break;

                case TouchPhase.Ended:
                    Dragging = false;

                    if (Mathf.Abs(transform.position.x - theBus.position.x) <= 0.5f &&
                       Mathf.Abs(transform.position.y - theBus.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(theBus.position.x, theBus.position.y);
                        locked = true;


                    }
                    else
                    {
                        transform.position = new Vector2(initalPosition.x, initalPosition.y);
                    }
                    break;
            }
            if (Dragging)
            {
                transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
            }
        }
    }
}
