using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe_Controls : MonoBehaviour
{
    public bool _tap, _swipeUp, _swipeRight, _swipeDown, _swipeLeft;
    public bool _isDraging = false;
    public Vector2 _startTouch, _deltaTouch;
    [SerializeField] float _sensetivity = 100f;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        _tap = _swipeDown = _swipeLeft = _swipeRight = _swipeUp = false;
        MouseInputs();
        TouchInputs();
        InputCalculation();
        SwipeDirection();
    }

    void Reset()
    {
        _startTouch = _deltaTouch = Vector2.zero;
        _isDraging = false;
    }

    void MouseInputs()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _tap = true;
            _isDraging = true;
            _startTouch = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Reset();
        }
    }
    void TouchInputs()
    {
        if(Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                _tap = true;
                _isDraging = true;
                _startTouch = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Reset();
            }
        }
    }

    void InputCalculation()
    {
        _deltaTouch = Vector2.zero;
        if(_isDraging)
        {
            if(Input.GetMouseButton(0))
                _deltaTouch = (Vector2)Input.mousePosition - _startTouch;
            else if(Input.touches.Length > 0)
            {
                _deltaTouch = Input.touches[0].position - _startTouch;
            }
        }
    }
    void SwipeDirection()
    {
        if(_deltaTouch.magnitude >= _sensetivity)
        {
            float x = _deltaTouch.x;
            float y = _deltaTouch.y;

            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                if(x > 0)
                {
                    _swipeRight = true;
                }
                else{
                    _swipeLeft = true;
                }
            }
            else{
                if(y > 0)
                {
                    _swipeUp = true;
                }
                else{
                    _swipeDown = true;
                }
            }
            Reset();
        }
    }

}
