using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    [Header("Commons")]
    [SerializeField]
    private GameObject pinPrefab; // ����� �� ������

    [Header("Stuck Pin")]
    [SerializeField]
    private Transform targetTransform;                  // ���� ������Ʈ�� Transfrom
    [SerializeField]
    private Vector3 targetPosition = Vector3.up * 2;    // ������ ��ġ
    [SerializeField]
    private float targetRadius = 0.8f;                  // ������ ������
    [SerializeField]
    private float pinLength = 1.5f;                     // �� ���� ����
    public void SpawnThrowablePin(Vector3 position)
    {
        //�� ������Ʈ ����
        Instantiate(pinPrefab, position, Quaternion.identity);
    }

    public void SpawnStuckPin(float angle)
    {
        // �� ������Ʈ ����
        GameObject clone = Instantiate(pinPrefab);

        // ���� ���ῡ ��ġ�� �� �ֵ��� ����
        SetInPinStuckToTarget(clone.transform, angle);
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
}
