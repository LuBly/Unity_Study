using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private PinSpawner pinSpawner; // Pin ������ ���� PinSpawner ������Ʈ
    [SerializeField]
    private int throwablePinCount; // ���� ���������� Ŭ�����ϱ� ���� ������ �ϴ� �� ����

    // ���� ȭ�� �ϴܿ� ��ġ�Ǵ� �������ϴ� �ɵ��� ù ��° �� ��ġ
    private Vector3 firstTPinPosition = Vector3.down * 2;
    // ������ �ϴ� �ɵ� ������ ��ġ �Ÿ�
    public float TPinDistance { private set; get; } = 1; //<<readOnly property, �ܺο��� �б⸸ �����ϰ�

    private void Awake()
    {
        // ���� �ϴܿ� ��ġ�Ǵ� ������ �ϴ� �� ������Ʈ ����
        for(int i = 0; i < throwablePinCount; i++)
        {
            pinSpawner.SpawnThrowablePin(firstTPinPosition + Vector3.down * TPinDistance * i);
        }
    }
}
