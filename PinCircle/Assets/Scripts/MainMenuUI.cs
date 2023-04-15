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
        // ���� �������� ���� ���� ������
        int index = PlayerPrefs.GetInt("StageLevel");
        // "StageLevel"�� ����� ���� 0���� �����ϱ� ������ +1�� �ؼ� ǥ��
        // "Go" ��ư�� ǥ�õǴ� �������� ���� ����
        textLevelInMenu.text = $"Level {(index + 1)}";
    }
    public void ButtonClickEventStart()
    {
        // ���� �������� ���� ���� ������
        int index = PlayerPrefs.GetInt("StageLevel");
        // "StageLevel"�� ����� ���� 0���� �����ϱ� ������ +1�� �ؼ� ǥ��
        // ���� ������Ʈ�� ǥ�õǴ� �������� ���� ����
        textLevelInGame.text = $"{(index + 1)}";
        menuPanel.MoveTo(AfterStartEvent, inactivePosition);
    }

    private void AfterStartEvent()
    {
        // IsGameStart�� true�� ������ ������ ���۵ǵ��� �Ѵ�.
        stageController.isGameStart = true;
    }

    public void ButtonClickEventReset()
    {
        PlayerPrefs.SetInt("StageLevel", 0);
        // "Go" ��ư�� ǥ�õǴ� �������� ���� ����
        textLevelInMenu.text = $"Level {(1)}";
        SceneManager.LoadScene(0);
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
        // ������ Ŭ�����ؼ� StageLevel�� +1�Ǳ� ������
        // �޴��� ���� �� ���� ������ ǥ�õǵ��� �ؽ�Ʈ ���� ����

        // ���� �������� ���� ���� ������
        int index = PlayerPrefs.GetInt("StageLevel");
        // "StageLevel"�� ����� ���� 0���� �����ϱ� ������ +1�� �ؼ� ǥ��
        // "Go" ��ư�� ǥ�õǴ� �������� ���� ����
        textLevelInMenu.text = $"Level {(index + 1)}";
        menuPanel.MoveTo(AfterStageExitEvent, activePosition);
    }

    private void AfterStageExitEvent()
    {
        // ���� �������� ���� ���� ������
        int index = PlayerPrefs.GetInt("StageLevel");
        // ������ ���������� Ŭ�������� �� ó��
        if (index == SceneManager.sceneCountInBuildSettings)
        {
            //������ �������� Ŭ���� �� ù ��° ���������� ����
            PlayerPrefs.SetInt("StageLevel", 0);
            SceneManager.LoadScene(0);
            return;
        }
        // ���� �������� ���� �ε����� �ش��ϴ� �� �ε�
        SceneManager.LoadScene(index);
    }
}
