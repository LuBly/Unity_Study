using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private StageController stageController;
    [SerializeField]
    private RectTransformMovers menuPanel; // 버튼을 눌렀을 때 명령을 수행해줄 RectTransformMovers 인스턴스

    private Vector3 inactivePosition = Vector3.left * 1080;
    public void ButtonClickEventStart()
    {
        menuPanel.MoveTo(AfterStartEvent, inactivePosition);
    }

    private void AfterStartEvent()
    {
        // IsGameStart를 true로 설정해 게임이 시작되도록 한다.
        stageController.isGameStart = true;
    }

    public void ButtonClickEventReset()
    {
        Debug.Log("Reset Stage");
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
}
