using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private PinSpawner pinSpawner; // Pin ������ ���� PinSpawner ������Ʈ
    [SerializeField]
    private Camera mainCamera;     // ��� ���� ������ ���� Camera ������Ʈ
    [SerializeField]
    private Rotator rotatorTarget; // ���� ��ġ�Ǵ� Ÿ�� ������Ʈ�� ȸ��ü
    [SerializeField]
    private int throwablePinCount; // ���� ���������� Ŭ�����ϱ� ���� ������ �ϴ� �� ����
    [SerializeField]
    private int stuckPinCount;     // ���� ������������ �̸� �����ִ� pin�� ����

    // ���� ȭ�� �ϴܿ� ��ġ�Ǵ� �������ϴ� �ɵ��� ù ��° �� ��ġ
    private Vector3 firstTPinPosition = Vector3.down * 2;
    // ������ �ϴ� �ɵ� ������ ��ġ �Ÿ�
    public float TPinDistance { private set; get; } = 1; //<<readOnly property, �ܺο��� �б⸸ �����ϰ�
    // ���ӿ��� / ���� Ŭ���� �Ǿ��� �� ��� ����
    private Color failBackgroundColor = new Color(0.4f, 0.1f, 0.1f);

    // ���� ��� ���� ����
    public bool isGameOver { set; get; } = false;


    private void Awake()
    {
        // PinSpawner�� Setup() �޼ҵ� ȣ�� _ List ����
        pinSpawner.Setup();

        // ���� �ϴܿ� ��ġ�Ǵ� ������ �ϴ� �� ������Ʈ ����
        for(int i = 0; i < throwablePinCount; i++)
        {
            pinSpawner.SpawnThrowablePin(firstTPinPosition + Vector3.down * TPinDistance * i, throwablePinCount-i);// List�� �� �߰�
        }

        for(int i =0;i<stuckPinCount; i++)
        {
            //���ῡ ��ġ�Ǵ� ���� ������ ���� ������ �������� ��ġ�� �� ��ġ ����
            float angle = (360 / stuckPinCount) * i;
            pinSpawner.SpawnStuckPin(angle,throwablePinCount+1+i);
        }
    }

    public void GameOver()
    {
        isGameOver = true;

        // ��� ���� ����
        mainCamera.backgroundColor = failBackgroundColor;

        // ���� ������Ʈ ȸ�� ����
        rotatorTarget.Stop();
    }
}
