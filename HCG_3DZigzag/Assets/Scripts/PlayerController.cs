using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameController gameController; // 게임시작, 종료 여부 판단을 위한 GameController
    private Movement movement; // 플레이어 이동 제어를 위한 Movement
    private float limitDeathY; // 플레이어가 사망하는 최소 y값
    private void Awake()
    {
        movement = GetComponent<Movement>();

        // 최초 이동방향을 오른쪽으로 설정
        //movement.MoveTo(Vector3.right);

        // 현재 플레이어의 y 위치에서 y/2 크기를 뺀 만큼이 사망하는 y 위치
        limitDeathY = transform.position.y - transform.localScale.y * 0.5f;
    }
    private IEnumerator Start()
    {
        while (true)
        {
            if(gameController.IsGameStart == true)
            {
                //최초 이동방향을 오른쪽으로 설정
                movement.MoveTo(Vector3.right);

                yield break;
            }

            yield return null;
        }
    }
    private void Update()
    {
        // 게임오버 상태이면 플레이어의 모든 행동 중지
        if (gameController.IsGameOver == true) return;

        if(Input.GetMouseButtonDown(0))
        {
            // 현재 이동방향이 Vector3.forward(0,0,1)이면 이동방향을 Vector3.right(1,0,0)으로 설정
            // 현재 이동방향이 Vector3.right(1,0,0)이면 이동방향을 Vector3.forward(0,0,1)으로 설정
            Vector3 direction = movement.MoveDirection == Vector3.forward? Vector3.right : Vector3.forward;
            movement.MoveTo(direction);

            // 방향을 전환할 때마다 점수 +1
            gameController.IncreaseScore();
        }

        if (transform.position.y < limitDeathY)
        {
            //Debug.Log("GameOver");
            gameController.GameOver();//플레이어가 낭떨어지에 떨어졌을 때, 게임오버 처리
        }
    }
}
