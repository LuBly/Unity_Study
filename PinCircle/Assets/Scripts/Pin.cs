using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    private GameObject square; // ���� ���� �κ�

    public void SetInPinStuckToTarget()
    {
        // ���� ���� ������Ʈ Ȱ��ȭ
        square.SetActive(true);
    }
}
