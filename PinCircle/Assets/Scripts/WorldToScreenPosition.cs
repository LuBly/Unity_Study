using UnityEngine;

public class WorldToScreenPosition : MonoBehaviour
{
    [SerializeField]
    private Vector3 distance = Vector3.zero; // ��ǥ ��ġ�κ��� ���� �Ÿ� �������� ��ġ�� �� ����
    private Transform targetTransform;
    private RectTransform rectTransform;

    public void Setup(Transform target)
    {
        // UI�� �Ѿƴٴ� ��� ����
        targetTransform = target;
        // RectTransform ������Ʈ ���� ������
        rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        // ȭ�鿡 target�� ������ ������ UI ����
        if( targetTransform == null)
        {
            Destroy(gameObject);
            return;
        }

        // ������Ʈ�� ��ġ�� ���ŵ� ���Ŀ� UI�� �Բ� ��ġ�� �����ϵ��� �ϱ� ����
        // LateUpdate()���� ȣ���Ѵ�

        // ������Ʈ�� ���� ��ǥ�� �������� ȭ�鿡���� ��ǥ ���� ����
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetTransform.position);
        // ȭ�鳻���� ��ǥ + distance��ŭ ������ ��ġ�� UI�� ��ġ�� ����
        rectTransform.position = screenPosition + distance;
    }
}
