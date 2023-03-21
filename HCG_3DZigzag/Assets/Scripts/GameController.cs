using System.Collections;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("GameStart UI")]
    [SerializeField]
    private FadeEffect[] fadeGameStart; // 게임시작 시 FadeIn 되어야 하는 UI들
    [SerializeField]
    private GameObject panelGameStart; // 게임시작 Panel 오브젝트
    [SerializeField]
    private TextMeshProUGUI textGameStartBestScore; // 게임시작 시 최고 점수 출력용 Text UI

    [Header("InGame UI")]
    [SerializeField]
    private TextMeshProUGUI textInGameScore; // 게임에서 획득한 점수 출력용 Text UI

    [Header("GameOver UI")]
    [SerializeField]
    private GameObject panelGameOver; // 게임오버 Panel 오브젝트
    [SerializeField]
    private TextMeshProUGUI textGameOverScore; // 게임오버 되었을 때 게임에서 획득한 점수 출력용 Text UI
    [SerializeField]
    private TextMeshProUGUI textGameOverBestScore; // 게임오버 되었을 때 최고 점수 출력용 Text UI

    [SerializeField]
    private float timeStopTime; // 시간배율(Time.timeScals)이 0이 될 때까지 소요 시간

    private int currentScore = 0; // 게임에서 획득한 점수 데이터
    // 게임시작 여부를 나타내는 프로피티
    public bool IsGameStart { private set; get; } = false;
    
    // 게임오버 여부를 나타내는 프로피티
    public bool IsGameOver { private set; get; } = false;
    private IEnumerator Start()
    {
        Time.timeScale = 1;

        //저장되어 있는 최고점수를 불러와서 출력
        int bestScore = PlayerPrefs.GetInt("BestScore");
        textGameStartBestScore.text = bestScore.ToString();

        //게임타이틀, "TAP TO PLAY" 텍스트의 FadeIn 효과 재생
        for(int i=0;i<fadeGameStart.Length;i++)
        {
            fadeGameStart[i].FadeIn();
        }

        while (true)
        {
            // 마우스  왼쪽 버튼을 누르면
            if (Input.GetMouseButtonDown(0))
            {
                // GameStart()메소드를 호출해 게임시작
                GameStart();

                // 외부 클래스에서 게임시작을 알 수 있도록 IsGameStart = true
                IsGameStart = true;
                yield break;
            }
            yield return null;
        }
    }

    public void GameStart()
    {
        // GameStart UI들이 배치되어 있는 Panel들을 비활성화
        panelGameStart.SetActive(false);

        // InGame 점수 출력용 Text UI 활성화
        textInGameScore.gameObject.SetActive(true);
    }

    public void IncreaseScore(int score = 1)
    {
        // score 만큼 현재 점수(currentScore) 증가
        currentScore += score;

        // 변경된 점수(currentScore) 정보를 Text UI에 갱신
        textInGameScore.text = currentScore.ToString();
    }

    public void GameOver()
    {
        // 외부 클래스에서 게임오버를 알 수 있도록 IsGameOver = true
        IsGameOver = true;

        // 게임오버 되었을 때 출력되는 현재 스테이지 획득 점수
        textGameOverScore.text = currentScore.ToString();

        // InGame 점수 출력용 Text UI 비활성화
        textInGameScore.gameObject.SetActive(false);

        // GameOver UI들이 배치되어 있는 Panel 활성화
        panelGameOver.SetActive(true);

        // 저장되어 있는 최고점수 불러오기
        int bestScore = PlayerPrefs.GetInt("BestScore");
        // 현재 스테이지에서 획득한 점수가 최고점수보다 높으면 최고점수 갱신
        if(currentScore> bestScore)
        {
            // currentScore 점수를 최고점수로 등록
            PlayerPrefs.SetInt("BestScore", currentScore);
            // currentScore 점수를 최고점수 Text UI에 출력
            textGameOverBestScore.text = currentScore.ToString();
        }
        else
        {
            // 기존의 bestScore 점수를 최고점수 Text UI에 출력
            textGameOverBestScore.text = bestScore.ToString();
        }


        // 시간 배율을 0으로 설정해 오브젝트를 멈추는 코루틴 메소드 실행
        StartCoroutine("SlowAndStopTime");
    }

    private IEnumerator SlowAndStopTime()
    {
        float current = 0;
        float percent = 0;

        // 시간 배율을 0.5배로 설정
        Time.timeScale = 0.5f;

        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / timeStopTime;

            yield return null;
        }

        //시간 배율을 0배로 설정해 오브젝트들을 멈춘다 (Player. Tile)
        Time.timeScale = 0;
    }
}
