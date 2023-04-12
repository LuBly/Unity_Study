using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private PinSpawner pinSpawner; // Pin 생성을 위한 PinSpawner 컴포넌트
    [SerializeField]
    private int throwablePinCount; // 현재 스테이지를 클리어하기 위해 던져야 하는 핀 개수
    [SerializeField]
    private int stuckPinCount;     // 현재 스테이지에서 미리 꼽혀있는 pin의 개수

    // 게임 화면 하단에 배치되는 던져야하는 핀들의 첫 번째 핀 위치
    private Vector3 firstTPinPosition = Vector3.down * 2;
    // 던져야 하는 핀들 사이의 배치 거리
    public float TPinDistance { private set; get; } = 1; //<<readOnly property, 외부에서 읽기만 가능하게

    private void Awake()
    {
        // PinSpawner의 Setup() 메소드 호출 _ List 생성
        pinSpawner.Setup();

        // 게임 하단에 배치되는 던져야 하는 핀 오브젝트 생성
        for(int i = 0; i < throwablePinCount; i++)
        {
            pinSpawner.SpawnThrowablePin(firstTPinPosition + Vector3.down * TPinDistance * i, throwablePinCount-i);// List에 값 추가
        }

        for(int i =0;i<stuckPinCount; i++)
        {
            //과녁에 배치되는 핀의 개수에 따라 일정한 간격으로 배치될 때 배치 각도
            float angle = (360 / stuckPinCount) * i;
            pinSpawner.SpawnStuckPin(angle,throwablePinCount+1+i);
        }
    }
}
