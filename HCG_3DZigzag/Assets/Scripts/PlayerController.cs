using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement movement; // �÷��̾� �̵� ��� ���� Movement
    private float limitDeathY; // �÷��̾ ����ϴ� �ּ� y��
    private void Awake()
    {
        movement = GetComponent<Movement>();

        // ���� �̵������� ���������� ����
        movement.MoveTo(Vector3.right);

        // ���� �÷��̾��� y ��ġ���� y/2 ũ�⸦ �� ��ŭ�� ����ϴ� y ��ġ
        limitDeathY = transform.position.y - transform.localScale.y * 0.5f;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // ���� �̵������� Vector3.forward(0,0,1)�̸� �̵������� Vector3.right(1,0,0)���� ����
            // ���� �̵������� Vector3.right(1,0,0)�̸� �̵������� Vector3.forward(0,0,1)���� ����
            Vector3 direction = movement.MoveDirection == Vector3.forward? Vector3.right : Vector3.forward;
            movement.MoveTo(direction);
        }

        if (transform.position.y < limitDeathY)
        {
            Debug.Log("GameOver");
        }
    }
}
