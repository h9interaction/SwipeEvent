using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class SwipeEvent : UnityEvent<float> { }

public class SwipeEventHandler : MonoBehaviour
{
    Vector3 leftHandOldPosition, rightHandOldPosition;
    float leftHandSpeed, rightHandSpeed;

    public SwipeEvent
    onRightHandLeftSwipe = new SwipeEvent(),
    onRightHandRightSwipe = new SwipeEvent(),
    onLeftHandRightSwipe = new SwipeEvent(),
    onLeftHandLeftSwipe = new SwipeEvent();

    bool isRightHandLeftSwipe, isRightHandRightSwipe, isLeftHandRightSwipe, isLeftHandLeftSwipe;



    void Start()
    {
        // onRightHandLeftSwipe.AddListener((speed) => // only Right Hand
        // {
        //     Debug.Log("Right Hand Left swipe <<<< : " + speed);
        // });

        // onRightHandRightSwipe.AddListener((speed) =>
        // {
        //     Debug.Log("Right Hand Right swipe >>>> : " + speed);
        // });

        // onLeftHandRightSwipe.AddListener((speed) => // only Left Hand
        // {
        //     Debug.Log("Left Hand Right swipe >>>> : " + speed);
        // });

        // onLeftHandLeftSwipe.AddListener((speed) => // only Left Hand
        // {
        //     Debug.Log("Left Hand Left swipe <<<< : " + speed);
        // });
    }

    void OnDisable()
    {
        onRightHandLeftSwipe.RemoveAllListeners();
        onLeftHandRightSwipe.RemoveAllListeners();
        onRightHandRightSwipe.RemoveAllListeners();
        onLeftHandLeftSwipe.RemoveAllListeners();
    }

    void Update()
    {
        // get mouse speed -> 왼쪽 손 속도와 오른쪽 손 속도를 따로 만들어 함.
        var leftHandPos = Input.mousePosition;
        var rightHandPos = Input.mousePosition;
        leftHandSpeed = leftHandPos.x - leftHandOldPosition.x;
        rightHandSpeed = rightHandPos.x - rightHandOldPosition.x;
        leftHandOldPosition = leftHandPos;
        rightHandOldPosition = rightHandPos;

        // 왼손으로 오른쪽 스와이프
        if (!isLeftHandRightSwipe && leftHandSpeed > 50 && Input.GetKey(KeyCode.LeftShift))
        {
            isLeftHandRightSwipe = true;
            onLeftHandRightSwipe.Invoke(leftHandSpeed);
        }
        else if (leftHandSpeed < 0 || !Input.GetKey(KeyCode.LeftShift)) // 왼쪽 손이 왼쪽으로 움직이거나, 왼쪽 손 인식이 없어지는경우 리셋시킨다.
        {
            isLeftHandRightSwipe = false;
        }

        // 왼손으로 왼쪽 스와이프
        if (!isLeftHandLeftSwipe && leftHandSpeed < -50 && Input.GetKey(KeyCode.LeftShift))
        {
            isLeftHandLeftSwipe = true;
            onLeftHandLeftSwipe.Invoke(leftHandSpeed);
        }
        else if (leftHandSpeed > 0 || !Input.GetKey(KeyCode.LeftShift)) // 왼쪽 손이 왼쪽으로 움직이거나, 왼쪽 손 인식이 없어지는경우 리셋시킨다.
        {
            isLeftHandLeftSwipe = false;
        }

        // 오른손으로 왼쪽 스와이프
        if (!isRightHandLeftSwipe && rightHandSpeed < -50 && Input.GetKey(KeyCode.RightShift))
        {
            isRightHandLeftSwipe = true;
            onRightHandLeftSwipe.Invoke(rightHandSpeed);
        }
        else if (rightHandSpeed > 0 || !Input.GetKey(KeyCode.RightShift)) // 오른쪽 손이 오른쪽으로 움직이거나, 오른쪽 손 인식이 없어지는 경우 리셋시킨다.
        {
            isRightHandLeftSwipe = false;
        }

        // 오른손으로 오른쪽 스와이프
        if (!isRightHandRightSwipe && rightHandSpeed > 50 && Input.GetKey(KeyCode.RightShift))
        {
            isRightHandRightSwipe = true;
            onRightHandRightSwipe.Invoke(rightHandSpeed);
        }
        else if (rightHandSpeed < 0 || !Input.GetKey(KeyCode.RightShift)) // 오른쪽 손이 오른쪽으로 움직이거나, 오른쪽 손 인식이 없어지는 경우 리셋시킨다.
        {
            isRightHandRightSwipe = false;
        }
    }
}
