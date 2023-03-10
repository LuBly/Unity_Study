using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed; // �̵� �ӵ�
    private Vector3 moveDirection; // �̵� ����

    //�ܺο��� �̵������� Ȯ���� �� �ֵ��� Get ������Ƽ ����
    public Vector3 MoveDirection => moveDirection;

    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// �ܺο��� �̵������� ������ �� ȣ��
    /// </summary>
    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
