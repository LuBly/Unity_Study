using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private StageController stageController;
    [SerializeField]
    private RectTransformMovers menuPanel; 

    private Vector3 inactivePosition = Vector3.left * 1080;
    private Vector3 activePosition = Vector3.zero;
    public void ButtonClickEventStart()
    {
        menuPanel.MoveTo(AfterStartEvent, inactivePosition);
    }

    private void AfterStartEvent()
    {
        // IsGameStart�� true�� ������ ������ ���۵ǵ��� �Ѵ�.
        stageController.isGameStart = true;
    }

    public void ButtonClickEventReset()
    {
        Debug.Log("Reset Stage");
    }

    public void ButtonClickEventExit()
    {
        // ���� ���� ȯ���� �������̸� ������ �÷��̸�� ����
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //or UnityEditor.EditorApplication.ExitPlaymode();
        // ���� ���� ȯ���� �����Ͱ� �ƴϸ� ���α׷� ����
        #else
        Application.Quit();
        #endif
    }

    public void StageExit()
    {
        menuPanel.MoveTo(AfterStageExitEvent, activePosition);
    }

    private void AfterStageExitEvent()
    {
        SceneManager.LoadScene(0);
    }
}
