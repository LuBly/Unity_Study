using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private PinSpawner pinSpawner; // Pin 생성을 위한 PinSpawner 컴포넌트
    [SerializeField]
    private int throwablePinCount; // 현재 스테이지를 클리어하기 위해 던져야 하는 핀 개수

    // 게임 화면 하단에 배치되는 던져야하는 핀들의 첫 번째 핀 위치
    private Vector3 firstTPinPosition = Vector3.down * 2;
    // 던져야 하는 핀들 사이의 배치 거리
    public float TPinDistance { private set; get; } = 1; //<<readOnly property, 외부에서 읽기만 가능하게

    private void Awake()
    {
        // 게임 하단에 배치되는 던져야 하는 핀 오브젝트 생성
        for(int i = 0; i < throwablePinCount; i++)
        {
            pinSpawner.SpawnThrowablePin(firstTPinPosition + Vector3.down * TPinDistance * i);
        }
    }
}
