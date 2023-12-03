using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public static MobileInput instance { set; get; }
    public bool tap, LEFT, RIGHT, UP, DOWN;
    public Vector2 swipeDelta, startTouch;
    private const float deadZone = 100;
    private void Awake()
    {
        instance = this;   
    }
    private void Update()
    {
        tap = LEFT = RIGHT = UP = DOWN = false;
        if(Input.GetMouseButtonDown(0))
        {
            startTouch = swipeDelta = Vector2.zero;
        }
        swipeDelta = Vector2.zero;

        if(startTouch != Vector2.zero)
        {
            if(Input.touches.Length != 0 )
            {
                swipeDelta = (Vector2)Input.touches[0].position - startTouch;
            }
            else if(Input.GetMouseButton(0)) 
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }
        if(swipeDelta.magnitude > deadZone)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                if(x< 0)
                {
                    LEFT = true;
                }
                else
                {
                    RIGHT = true;
                }
            }
            else
            {
                if (y < 0)
                {
                    DOWN = true;
                }
                else
                {
                    UP = true;
                }
            }
            startTouch = swipeDelta = Vector2.zero;
        }
    }
}
