using Lean.Touch;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    LeanFinger mainFinger;

    void OnEnable()
    {
        LeanTouch.OnFingerDown += OnFingerDown;
        LeanTouch.OnFingerUp += OnFingerUp;
        LeanTouch.OnFingerSet += OnFingerSet;
    }

    void OnDisable()
    {
        LeanTouch.OnFingerDown -= OnFingerDown;
        LeanTouch.OnFingerUp -= OnFingerUp;
        LeanTouch.OnFingerSet -= OnFingerSet;
    }


    

    private void OnFingerDown(LeanFinger finger)
    {
        if(mainFinger == null)
        {
            mainFinger = finger;
            SetDirectionAndRotation(finger);
        }
    }

    private void OnFingerUp(LeanFinger finger)
    {
        if (finger == mainFinger)
        {
            mainFinger = null;
            SetDirection(Vector3.zero);
        }
    }


    private void OnFingerSet(LeanFinger finger)
    {
        if (finger == mainFinger)
        {
            SetDirectionAndRotation(finger);
        }
    }

    private void SetDirectionAndRotation(LeanFinger finger)
    {
        Vector3 worldFingerPosition = GetFingerWorldPosition(finger);
        SetDirection(FingerPositionToDirection(worldFingerPosition));
        SetRotation(worldFingerPosition);
    }

    private void SetDirection(Vector3 direction)
    {
        GetComponent<PlayerMove>().SetDirection(direction);
    }

    private void SetRotation(Vector3 point)
    {
        GetComponent<PlayerMove>().SetRotation(point);
    }

    private Vector3 GetFingerWorldPosition(LeanFinger finger)
    {
        return finger.GetWorldPosition(0, Camera.main);
    }

    private Vector3 FingerPositionToDirection(Vector3 position)
    {
        Vector3 direction =  position - transform.position;
        direction.z = 0;
        return direction;

    }

    
}

