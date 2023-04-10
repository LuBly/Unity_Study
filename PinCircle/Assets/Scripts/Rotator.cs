using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 50;                 // 회전 속도
    [SerializeField]
    private Vector3 rotateAngle = Vector3.forward;  // 회전 방향

    private void Update()
    {
        //방향 * 속도 * Time.deltaTime 으로 오브젝트 회전
        transform.Rotate(rotateAngle*rotateSpeed*Time.deltaTime);
    }
}
