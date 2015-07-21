﻿using UnityEngine;
using System.Collections;

public class SwipeController : MonoBehaviour {

    public float minSwipeDistY;
    public float minSwipeDistX;

    public static bool jump, slip, left, right;

    Vector2 startPos;

    void Update()
    {
        if (PlayerController.isMoving)
        {

        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    startPos = touch.position;
                    break;

                
                case TouchPhase.Ended:

                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

                    if (swipeDistVertical > minSwipeDistY)
                    {
                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                        if (swipeValue > 0)
                        {
                            jump = true;
                        }
                        else if (swipeValue < 0)
                        {
                            slip = true;
                        }
                        
                    }

                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

                    if (swipeDistHorizontal > minSwipeDistX)
                    {
                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                        if (swipeValue > 0)
                        {
                            right = true;
                        }
                        else if (swipeValue < 0)
                        {
                            left = true;
                        }
                        
                    }

                    break;
            }
        }
    }
    
}
