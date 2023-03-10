using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target; // ī�޶� �����ϴ� ���
    private float distance; // ī�޶�� target�� �Ÿ�

    private void Awake()
    {
        // ���� ������ target�� ī�޶��� ��ġ�� �������� distance �� �ʱ�ȭ
        distance = Vector3.Distance(transform.position, target.position);
    }

    private void LateUpdate()
    {
        // target�� �������� ������ �������� �ʴ´�.
        if(target == null) return;

        // ī�޶��� ��ġ(position) ���� ����
        // target�� ��ġ�� �������� distance��ŭ �������� �Ѿư���.
        transform.position = target.position + transform.rotation * new Vector3(0, 0, -distance); 
    }
}
