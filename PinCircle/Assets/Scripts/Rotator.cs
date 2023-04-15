using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private StageController stageController;
    [SerializeField]
    private float rotateSpeed = 50;                 // 회전 속도
    [SerializeField]
    private float maxRotateSpeed = 500;             // 최대 회전 속도
    [SerializeField]
    private Vector3 rotateAngle = Vector3.forward;  // 회전 방향
    
    //GameOver되었을 때 StageController에서 과녁의 회전을 멈추기 위한 함수
    public void Stop()
    {
        rotateSpeed = 0;
    }

    public void RotateFast()
    {
        rotateSpeed = maxRotateSpeed;
    }
    private void Update()
    {
        //IsGameStart가 false일 때에는 게임시작 전이기 때문에 회전체가 회전하지 않는다.
        if (!stageController.isGameStart) return;
        //방향 * 속도 * Time.deltaTime 으로 오브젝트 회전
        transform.Rotate(rotateAngle*rotateSpeed*Time.deltaTime);
    }
}
