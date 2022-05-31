using UnityEngine;
using UnityEngine.EventSystems;

public class UserInput : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerMoveHandler
{
    private const float DEADZONE = 100.0f;

    public static UserInput instance { get; set; }

    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown, swipetoplefttorghtdown, swipeTopRightToLeftDown, swipeDownLeftToRightTop, swipeDownRightToLeftTop;
    private Vector2 swipeDelta, startTouch;

    public bool Tap { get { return tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool SwipeTopLeftToRightDown { get { return swipetoplefttorghtdown; } }
    public bool SwipeTopRightToLeftDown { get { return swipeTopRightToLeftDown; } }
    public bool SwipeDownLeftToRightTop { get { return swipeDownLeftToRightTop; } }
    public bool SwipeDownRightToLeftTop { get { return swipeDownRightToLeftTop; } }

    #region Events
    public delegate void Swiped(int indexOfDiretion);
    public static event Swiped Swiper;
    #endregion


    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        // Rest all bool
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = swipeDownLeftToRightTop = swipeTopRightToLeftDown = swipetoplefttorghtdown = swipeDownRightToLeftTop =false;

        // DeadZone
        if (swipeDelta.magnitude > DEADZONE)
        {
            // Cool swipe
           
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            Debug.Log("X : " + x + " \n " + "Y : " + y);

            if (x < -10 && y < -10)
            {
                //Top Right to Left Down
                if (Swiper != null)
                {
                    Swiper(5);
                }
            }
            else if (x > 10 && y > 10) 
            {
                //Down Left to Right TOp
                if (Swiper != null)
                {
                    Swiper(8);
                }
            }
            else if (x > 10 && y < -10)
            {
                //Top LEft to Right Down
                if (Swiper != null)
                {
                    Swiper(3);
                }
            }
            else if(x < -10 && y > 10)
            {
                //Down Right to Left Top
                if (Swiper != null)
                {
                    Swiper(6);
                }
            }

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                // Left or Right
                if (x < 0)
                {
                    // Left
                    if (Swiper != null)
                    {
                        Swiper(2);
                    }
                }
                else
                {
                    // Right
                    if (Swiper != null)
                    {
                        Swiper(1);
                    }
                }
            }
            else
            {
                // Up or Down
                if (y < 0)
                {
                    // Down
                    if (Swiper != null)
                    {
                        Swiper(4);
                    }
                }
                else
                {
                    // Up
                    if (Swiper != null)
                    {
                        Swiper(7);
                    }
                }
            }

            startTouch = swipeDelta = Vector2.zero;
        }
        
    }

  

    public void OnPointerUp(PointerEventData eventData)
    {
        startTouch = swipeDelta = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        tap = true;
        startTouch = Input.mousePosition;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        swipeDelta = Vector2.zero;
        if (startTouch != Vector2.zero)
        {
            swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }
    }
}