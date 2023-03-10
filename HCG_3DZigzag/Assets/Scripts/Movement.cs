using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed; // 이동 속도
    private Vector3 moveDirection; // 이동 방향

    //외부에서 이동방향을 확인할 수 있도록 Get 프로퍼티 선언
    public Vector3 MoveDirection => moveDirection;

    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// 외부에서 이동방향을 설정할 때 호출
    /// </summary>
    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
