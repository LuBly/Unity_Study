using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Reflection;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private StageController stageController;
    [SerializeField]
    private RectTransformMovers menuPanel;
    [SerializeField]
    private TextMeshProUGUI textLevelInMenu;
    [SerializeField]
    private TextMeshProUGUI textLevelInGame;


    private Vector3 inactivePosition = Vector3.left * 1080;
    private Vector3 activePosition = Vector3.zero;

    private void Awake()
    {
        // 현재 스테이지 레벨 정보 얻어오기
        int index = PlayerPrefs.GetInt("StageLevel");
        // "StageLevel"에 저장된 값은 0부터 시작하기 때문에 +1을 해서 표시
        // "Go" 버튼에 표시되는 스테이지 레벨 갱신
        textLevelInMenu.text = $"Level {(index + 1)}";
    }
    public void ButtonClickEventStart()
    {
        // 현재 스테이지 레벨 정보 얻어오기
        int index = PlayerPrefs.GetInt("StageLevel");
        // "StageLevel"에 저장된 값은 0부터 시작하기 때문에 +1을 해서 표시
        // 과녁 오브젝트에 표시되는 스테이지 레벨 갱신
        textLevelInGame.text = $"{(index + 1)}";
        menuPanel.MoveTo(AfterStartEvent, inactivePosition);
    }

    private void AfterStartEvent()
    {
        // IsGameStart를 true로 설정해 게임이 시작되도록 한다.
        stageController.isGameStart = true;
    }

    public void ButtonClickEventReset()
    {
        PlayerPrefs.SetInt("StageLevel", 0);
        // "Go" 버튼에 표시되는 스테이지 레벨 갱신
        textLevelInMenu.text = $"Level {(1)}";
        SceneManager.LoadScene(0);
    }

    public void ButtonClickEventExit()
    {
        // 현재 실행 환경이 에디터이면 에디터 플레이모드 종료
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //or UnityEditor.EditorApplication.ExitPlaymode();
        // 현재 실행 환경이 에디터가 아니면 프로그램 종료
        #else
        Application.Quit();
        #endif
    }

    public void StageExit()
    {
        // 게임을 클리어해서 StageLevel이 +1되기 때문에
        // 메뉴가 닫힐 때 다음 레벨이 표시되도록 텍스트 정보 갱신

        // 현재 스테이지 레벨 정보 얻어오기
        int index = PlayerPrefs.GetInt("StageLevel");
        // "StageLevel"에 저장된 값은 0부터 시작하기 때문에 +1을 해서 표시
        // "Go" 버튼에 표시되는 스테이지 레벨 갱신
        textLevelInMenu.text = $"Level {(index + 1)}";
        menuPanel.MoveTo(AfterStageExitEvent, activePosition);
    }

    private void AfterStageExitEvent()
    {
        // 현재 스테이지 레벨 정보 얻어오기
        int index = PlayerPrefs.GetInt("StageLevel");
        // 마지막 스테이지를 클리어했을 때 처리
        if (index == SceneManager.sceneCountInBuildSettings)
        {
            //마지막 스테이지 클리어 시 첫 번째 스테이지로 리셋
            PlayerPrefs.SetInt("StageLevel", 0);
            SceneManager.LoadScene(0);
            return;
        }
        // 현재 스테이지 레벨 인덱스에 해당하는 씬 로드
        SceneManager.LoadScene(index);
    }
}
