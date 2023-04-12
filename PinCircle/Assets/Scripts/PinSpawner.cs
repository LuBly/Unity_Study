using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    [Header("Commons")]
    [SerializeField]
    private StageController stageController;            // StageController ������Ʈ ����
    [SerializeField]
    private GameObject pinPrefab;                       // ����� �� ������
    [SerializeField]
    private GameObject textPinIndexPrefab;              // �ɿ� ���ڸ� ǥ���ϴ� Text UI
    [SerializeField]
    private Transform textParent;                       // �� Text�� ��ġ�Ǵ� Panel Transform

    [Header("Stuck Pin")]
    [SerializeField]
    private Transform targetTransform;                  // ���� ������Ʈ�� Transfrom
    [SerializeField]
    private Vector3 targetPosition = Vector3.up * 2;    // ������ ��ġ
    [SerializeField]
    private float targetRadius = 0.8f;                  // ������ ������
    [SerializeField]
    private float pinLength = 1.5f;                     // �� ���� ����

    [Header("Throwable Pin")]
    [SerializeField]
    private float bottomAngle = 270;                    // ���� ���� ���콺 Ŭ������ ��ġ�Ǵ� ���� ����
    private List<Pin> throwablePins;                    // �ϴܿ� �����Ǵ� ������ �� �� ������Ʈ ����Ʈ

    // Awake�� �ƴ� Setup�� ����ϴ� ����
    // Awake�� ��� ���� ������ ������ �Ϳ� ���� Setup�� ��� �ʿ��� �� ȣ���Ͽ� ����� �� �ֱ� ����
    // ThrowablePins ����Ʈ�� �޸� �Ҵ��� ���� ȣ�� �ǰ�, throwablePins ����Ʈ�� ����ϵ��� �ϱ� ���ؼ�
    public void Setup()
    {
        throwablePins = new List<Pin>();
    }

    private void Update()
    {
        // ���ӿ���(Ŭ���� or ����)�̸� ����X
        if (stageController.isGameOver == true) return;

        // ���� ���� ���� �÷��̾ ���콺 ���� Ŭ������ �� ����
        if(Input.GetMouseButtonDown(0)&&throwablePins.Count>0) 
        {
            // throwablePins ����Ʈ�� ����� ù ��° ���� ���ῡ ��ġ
            SetInPinStuckToTarget(throwablePins[0].transform, bottomAngle);
            // ��� ���ῡ ��ġ�� ù ��° �� ��Ҹ� ����Ʈ���� ����
            throwablePins.RemoveAt(0);

            // ���ῡ ��ġ���� ���� throwablePins ����Ʈ�� ��� �� ��ġ �̵�
            for(int i=0;i<throwablePins.Count;i++)
            {
                throwablePins[i].MoveOneStep(stageController.TPinDistance);
            }
        }
    }
    public void SpawnThrowablePin(Vector3 position, int index)
    {
        // �� ������Ʈ ����
        GameObject clone = Instantiate(pinPrefab, position, Quaternion.identity);

        // "Pin" ������Ʈ ������ ���� Setup() �޼ҵ� ȣ��
        Pin pin= clone.GetComponent<Pin>();
        pin.Setup(stageController);
        // ��� ������ �� ������Ʈ�� "Pin" ������Ʈ�� ����Ʈ�� �߰�
        throwablePins.Add(pin);

        // �� ������Ʈ�� ǥ�õǴ� Text UI ����
        SpawnTextUI(clone.transform, index);
    }

    public void SpawnStuckPin(float angle, int index)
    {
        // �� ������Ʈ ����
        GameObject clone = Instantiate(pinPrefab);

        // "Pin" ������Ʈ ������ ���� Setup() �޼ҵ� ȣ��
        Pin pin = clone.GetComponent<Pin>();
        pin.Setup(stageController);

        // ���� ���ῡ ��ġ�� �� �ֵ��� ����
        SetInPinStuckToTarget(clone.transform, angle);

        // �� ������Ʈ�� ǥ�õǴ� Text UI ����
        SpawnTextUI(clone.transform, index);
    }

    private void SetInPinStuckToTarget(Transform pin,float angle)
    {
        // Ÿ���� �ش� ������ ���� ������ �� ��ġ
        pin.position = Utils.GetPositionFromAngle(targetRadius + pinLength, angle) + targetPosition;
        // �� ������Ʈ ȸ�� ����
        pin.rotation = Quaternion.Euler(0, 0, angle);
        // �� ������Ʈ�� target�� �ڽ����� �����ؼ� target�� ���� ȸ���ϵ��� �Ѵ�.
        pin.SetParent(targetTransform);
        // ���� ���ῡ ��ġ�Ǿ��� �� ����
        pin.GetComponent<Pin>().SetInPinStuckToTarget();
    }

    private void SpawnTextUI(Transform target, int index)
    {
        // ���ڸ� ��Ÿ���� Text UI ����
        GameObject textClone = Instantiate(textPinIndexPrefab);
        // Text UI�� �θ� textParent�� ����
        textClone.transform.SetParent(textParent);
        // ���� �������� �ٲ� ũ�⸦ �ٽ� (1,1,1)�� ����
        textClone.transform.localScale= Vector3.one;
        // UI�� �Ѿƴٴ� ��� ����
        textClone.GetComponent<WorldToScreenPosition>().Setup(target);
        // UI�� ǥ�õǴ� �ؽ�Ʈ ����
        textClone.GetComponent<TMPro.TextMeshProUGUI>().text = index.ToString();
    }
}
