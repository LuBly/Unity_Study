using System.Collections;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private PinSpawner pinSpawner;      // Pin ������ ���� PinSpawner ������Ʈ
    [SerializeField]
    private Camera mainCamera;          // ��� ���� ������ ���� Camera ������Ʈ
    [SerializeField]
    private Rotator rotatorTarget;      // ���� ��ġ�Ǵ� Ÿ�� ������Ʈ�� ȸ��ü
    [SerializeField]
    private Rotator rotatorIndexPanel;  // �� �ε��� Text�� ��ġ�� Panel ������Ʈ ȸ��ü
    [SerializeField]
    private MainMenuUI mainMenuUI;      // ���� �޴� �̵��� ���� MainMenuUI ������Ʈ
    [SerializeField]
    private int throwablePinCount;      // ���� ���������� Ŭ�����ϱ� ���� ������ �ϴ� �� ����
    [SerializeField]
    private int stuckPinCount;          // ���� ������������ �̸� �����ִ� pin�� ����

    // ���� ȭ�� �ϴܿ� ��ġ�Ǵ� �������ϴ� �ɵ��� ù ��° �� ��ġ
    private Vector3 firstTPinPosition = Vector3.down * 2;
    // ������ �ϴ� �ɵ� ������ ��ġ �Ÿ�
    public float TPinDistance { private set; get; } = 1; //<<readOnly property, �ܺο��� �б⸸ �����ϰ�
    // ���ӿ��� / ���� Ŭ���� �Ǿ��� �� ��� ����
    private Color failBackgroundColor = new Color(0.4f, 0.1f, 0.1f);
    private Color clearBackgroundColor = new Color(0, 0.5f, 0.25f);

    // ���� ��� ���� ����
    public bool isGameOver  { set; get; } = false;
    public bool isGameStart { set; get; } = false;
    private void Awake()
    {
        // PinSpawner�� Setup() �޼ҵ� ȣ�� _ List ����
        pinSpawner.Setup();

        // ���� �ϴܿ� ��ġ�Ǵ� ������ �ϴ� �� ������Ʈ ����
        for (int i = 0; i < throwablePinCount; i++)
        {
            pinSpawner.SpawnThrowablePin(firstTPinPosition + Vector3.down * TPinDistance * i, throwablePinCount - i);// List�� �� �߰�
        }

        for (int i = 0; i < stuckPinCount; i++)
        {
            //���ῡ ��ġ�Ǵ� ���� ������ ���� ������ �������� ��ġ�� �� ��ġ ����
            float angle = (360 / stuckPinCount) * i;
            pinSpawner.SpawnStuckPin(angle, throwablePinCount + 1 + i);
        }
    }

    public void GameOver()
    {
        isGameOver = true;

        // ��� ���� ����
        mainCamera.backgroundColor = failBackgroundColor;

        // ���� ������Ʈ ȸ�� ����
        rotatorTarget.Stop();

        // 0.5�� ��� �� �������� ���� �̺�Ʈ ó��
        StartCoroutine("StageExit", 0.5f);
    }

    public void DecreaseThrowablePin()
    {
        throwablePinCount--;
        // ��� ���� ���ῡ ���߽����� �� Clear ó��
        if (throwablePinCount == 0)
        {
            // �Ϲ� �޼ҵ�� ������ ��� ������ ���� ������ ��
            // ���� �浹 ���ο� ������� ������ Ŭ�����.
            StartCoroutine("GameClear");
        }
    }

    private IEnumerator GameClear()
    {
        // Pin�� �浹 �˻� ���Ŀ� GameClear�� ����� �� �ֵ���
        // ª�� �ð� ����� ���� IsGameOver�� false�̸� GameClear() ������ ����
        yield return new WaitForSeconds(0.1f);

        // GameOver()�� ����Ǿ� IsGameOver�� true�̸� �ڷ�ƾ ����
        if (isGameOver == true)
        {
            yield break;
        }

        // ��� ���� ����
        mainCamera.backgroundColor = clearBackgroundColor;

        // ���� ������Ʈ ������ ȸ��
        rotatorTarget.RotateFast();
        // Text�� ��ġ�Ǿ� �ִ� �г��� ������ ȸ��
        rotatorIndexPanel.RotateFast();

        // ���� �������� ���� ������ ���� ������ +1 �Ѵ�.
        // Get�� �� ����� ������ ������ 0�� ��ȯ�Ǳ� ������ index�� 0���� �����ϰ� �ȴ�.
        int index = PlayerPrefs.GetInt("StageLevel");
        PlayerPrefs.SetInt("StageLevel", index + 1);

        // 1�� ��� �� �������� ���� �� �̺�Ʈ ó��
        StartCoroutine("StageExit", 1);
    }

    private IEnumerator StageExit(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        mainMenuUI.StageExit();
    }
}
