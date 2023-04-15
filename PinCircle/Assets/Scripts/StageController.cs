using System.Collections;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private PinSpawner pinSpawner;      // Pin 생성을 위한 PinSpawner 컴포넌트
    [SerializeField]
    private Camera mainCamera;          // 배경 색상 변경을 위한 Camera 컴포넌트
    [SerializeField]
    private Rotator rotatorTarget;      // 핀이 배치되는 타겟 오브젝트의 회전체
    [SerializeField]
    private Rotator rotatorIndexPanel;  // 핀 인덱스 Text가 배치된 Panel 오브젝트 회전체
    [SerializeField]
    private MainMenuUI mainMenuUI;      // 메인 메뉴 이동을 위한 MainMenuUI 컴포넌트
    [SerializeField]
    private int throwablePinCount;      // 현재 스테이지를 클리어하기 위해 던져야 하는 핀 개수
    [SerializeField]
    private int stuckPinCount;          // 현재 스테이지에서 미리 꼽혀있는 pin의 개수

    // 게임 화면 하단에 배치되는 던져야하는 핀들의 첫 번째 핀 위치
    private Vector3 firstTPinPosition = Vector3.down * 2;
    // 던져야 하는 핀들 사이의 배치 거리
    public float TPinDistance { private set; get; } = 1; //<<readOnly property, 외부에서 읽기만 가능하게
    // 게임오버 / 게임 클리어 되었을 때 배경 색상
    private Color failBackgroundColor = new Color(0.4f, 0.1f, 0.1f);
    private Color clearBackgroundColor = new Color(0, 0.5f, 0.25f);

    // 게임 제어를 위한 변수
    public bool isGameOver  { set; get; } = false;
    public bool isGameStart { set; get; } = false;
    private void Awake()
    {
        // PinSpawner의 Setup() 메소드 호출 _ List 생성
        pinSpawner.Setup();

        // 게임 하단에 배치되는 던져야 하는 핀 오브젝트 생성
        for (int i = 0; i < throwablePinCount; i++)
        {
            pinSpawner.SpawnThrowablePin(firstTPinPosition + Vector3.down * TPinDistance * i, throwablePinCount - i);// List에 값 추가
        }

        for (int i = 0; i < stuckPinCount; i++)
        {
            //과녁에 배치되는 핀의 개수에 따라 일정한 간격으로 배치될 때 배치 각도
            float angle = (360 / stuckPinCount) * i;
            pinSpawner.SpawnStuckPin(angle, throwablePinCount + 1 + i);
        }
    }

    public void GameOver()
    {
        isGameOver = true;

        // 배경 색상 변경
        mainCamera.backgroundColor = failBackgroundColor;

        // 과녁 오브젝트 회전 중지
        rotatorTarget.Stop();

        // 0.5초 대기 후 스테이지 종료 이벤트 처리
        StartCoroutine("StageExit", 0.5f);
    }

    public void DecreaseThrowablePin()
    {
        throwablePinCount--;
        // 모든 핀을 과녁에 명중시켰을 때 Clear 처리
        if (throwablePinCount == 0)
        {
            // 일반 메소드로 실행할 경우 마지막 핀을 던졌을 때
            // 핀의 충돌 여부와 상관없이 무조건 클리어됨.
            StartCoroutine("GameClear");
        }
    }

    private IEnumerator GameClear()
    {
        // Pin의 충돌 검사 이후에 GameClear가 실행될 수 있도록
        // 짧은 시간 대기한 이후 IsGameOver가 false이면 GameClear() 로직을 실행
        yield return new WaitForSeconds(0.1f);

        // GameOver()가 실행되어 IsGameOver가 true이면 코루틴 중지
        if (isGameOver == true)
        {
            yield break;
        }

        // 배경 색상 변경
        mainCamera.backgroundColor = clearBackgroundColor;

        // 과녁 오브젝트 빠르게 회전
        rotatorTarget.RotateFast();
        // Text가 배치되어 있는 패널을 빠르게 회전
        rotatorIndexPanel.RotateFast();

        // 현재 스테이지 레벨 정보를 얻어와 레벨을 +1 한다.
        // Get할 때 저장된 정보가 없으면 0이 반환되기 때문에 index가 0부터 시작하게 된다.
        int index = PlayerPrefs.GetInt("StageLevel");
        PlayerPrefs.SetInt("StageLevel", index + 1);

        // 1초 대기 후 스테이지 종료 후 이벤트 처리
        StartCoroutine("StageExit", 1);
    }

    private IEnumerator StageExit(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        mainMenuUI.StageExit();
    }
}
