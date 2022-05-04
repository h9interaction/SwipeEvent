using UnityEngine;

public class CubeRotateHandler : MonoBehaviour
{
    SwipeEventHandler swipeEvent;
    public AnimationCurve animCurve; // 애니메이션 커브(Ease)값 > Inspector에서 곡선 그리기.
    public float animationTime = 1f;
    bool isTween;
    Vector3 originRotate, targetRotate;

    void Start()
    {
        swipeEvent = FindObjectOfType<SwipeEventHandler>();

        swipeEvent.onLeftHandRightSwipe.AddListener(rotateRight);
        swipeEvent.onRightHandLeftSwipe.AddListener(rotateLeft);
    }

    void OnDisable()
    {
        swipeEvent.onLeftHandRightSwipe.RemoveAllListeners();
        swipeEvent.onRightHandLeftSwipe.RemoveAllListeners();
    }

    void Update()
    {
        if (isTween)
        {
            transform.eulerAngles = Vector3.Lerp(originRotate, targetRotate, animCurve.Evaluate(animationTime));
            animationTime += Time.deltaTime;
        }
        if (animationTime >= 1f)
        {
            isTween = false;
        }
    }

    void rotateRight(float speed)
    {
        if (!isTween)
        {
            isTween = true;
            animationTime = 0.0f;
            originRotate = transform.eulerAngles;
            targetRotate = originRotate + new Vector3(0, -90, 0);
        }
    }

    void rotateLeft(float speed)
    {
        if (!isTween)
        {
            isTween = true;
            animationTime = 0.0f;
            originRotate = transform.eulerAngles;
            targetRotate = originRotate + new Vector3(0, 90, 0);
        }
    }
}
