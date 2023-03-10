using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target; // 카메라가 추적하는 대상
    private float distance; // 카메라와 target의 거리

    private void Awake()
    {
        // 최초 설정된 target과 카메라의 위치를 바탕으로 distance 값 초기화
        distance = Vector3.Distance(transform.position, target.position);
    }

    private void LateUpdate()
    {
        // target이 존재하지 않으면 실행하지 않는다.
        if(target == null) return;

        // 카메라의 위치(position) 정보 갱신
        // target의 위치를 기준으로 distance만큼 떨어져서 쫓아간다.
        transform.position = target.position + transform.rotation * new Vector3(0, 0, -distance); 
    }
}
