# SwipeEventHandler
 
## Features
- 홀로렌즈에서 손을 인식하여 좌/우 스와이핑을 위한 테스트 

## Example

```csharp
void Start()
{
    swipeEvent = FindObjectOfType<SwipeEventHandler>();

    swipeEvent.onLeftHandRightSwipe.AddListener(rotateRight);
    swipeEvent.onRightHandLeftSwipe.AddListener(rotateLeft);
}

...

void rotateRight(float speed)
{
    ...
}

void rotateLeft(float speed)
{
    ...
}

```
