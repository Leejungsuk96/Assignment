# Assignment
## 주요기능

1. W,A,S,D를 이용해서 캐릭터 원하는 방향으록 이동
2. 마우스 방향으로 캐릭터 반전
3. 캐릭터에 따른 카메라 이동
4. 타일맵 구성 및 맵 밖으로 못나가게 Collision 적용
   
## Souloution
1. CharacterController.cs를 통해 Move와 Look을 호출하는 함수 사용 ( Action 이용)
   Input System 사용하여 Keyboard(W,A,S,D) Mouse(position)을 이용하여 각각 Move와 Look에 함수를 PlayerInputController.cs에 사용
   Movement.cs에서 입력된 값 처리해서 Move와 Look 함수에 사용

2. AimRotation.cs에서 가상의 LookPivot과 LookPoint를 만들어 캐릭터와의 Atan2 계산 후 90도가 넘어갈 실 Flip 사용
 ```
 float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
 LookingPoint.flipY = Mathf.Abs(rotZ) > 90f;
 characterRenderer.flipX = LookingPoint.flipY;
 LookingPivot.rotation = Quaternion.Euler(0, 0, rotZ);
```

3. 메인 카메라에 Camera.cs를 걸어주고 캐릭터 따라다니게 설정
```
public GameObject target; // 카메라가 따라갈 대상 = Player
[SerializeField] private float CameraSpeed = 5f; // 카메라가 따라갈 속도
private Vector3 targetPosition; // 대상의 현재 위치

// Update is called once per frame
void Update()
{
    if (target.gameObject != null)
    {
        // this는 카메라를 의미 (z값은 카메라값을 그대로 유지)
        targetPosition.Set(target.transform.position.x, target.transform.position.y, -10);

        // vectorA -> B까지 T의 속도로 이동
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, CameraSpeed);
```

4. 타일맵 팔레트를 이용하여 Floor, Wall, Collision(투명화 시킴) 나눠서 맵구성 
   ![image](https://github.com/Leejungsuk96/Assignment/assets/114940193/6ead441a-709d-4708-bd12-0d8fd49b3d9f)

