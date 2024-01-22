using System;
using UnityEngine;

public class SwipeControl : MonoBehaviour
{
    private Vector3 _fp;
    private Vector3 _lp;
    private float _dragDistance;

    public static Action LSwipe;
    public static Action RSwipe;

    private void Start()
    {
        _dragDistance = Screen.height * 15 / 100;
    }

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                _fp = touch.position;
                _lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                _lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _lp = touch.position;

                if (Mathf.Abs(_lp.x - _fp.x) > _dragDistance || Mathf.Abs(_lp.y - _fp.y) > _dragDistance)
                {
                    if (Mathf.Abs(_lp.x - _fp.x) > Mathf.Abs(_lp.y - _fp.y))
                    {
                        if ((_lp.x > _fp.x))
                        {
                            Debug.Log("RightSwipe");
                            RSwipe?.Invoke();
                        }
                        else
                        {
                            Debug.Log("LeftSwipe");
                            LSwipe?.Invoke();
                        }
                    }
                }
            }
        }
    }
}