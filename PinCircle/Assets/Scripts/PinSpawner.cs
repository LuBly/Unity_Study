using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    [Header("Commons")]
    [SerializeField]
    private GameObject pinPrefab; // 사용할 핀 프리팹

    [Header("Stuck Pin")]
    [SerializeField]
    private Transform targetTransform;                  // 과녁 오브젝트의 Transfrom
    [SerializeField]
    private Vector3 targetPosition = Vector3.up * 2;    // 과녁의 위치
    [SerializeField]
    private float targetRadius = 0.8f;                  // 과녁의 반지름
    [SerializeField]
    private float pinLength = 1.5f;                     // 핀 막대 길이
    public void SpawnThrowablePin(Vector3 position)
    {
        //핀 오브젝트 생성
        Instantiate(pinPrefab, position, Quaternion.identity);
    }

    public void SpawnStuckPin(float angle)
    {
        // 핀 오브젝트 생성
        GameObject clone = Instantiate(pinPrefab);

        // 핀이 과녁에 배치될 수 있도록 설정
        SetInPinStuckToTarget(clone.transform, angle);
    }

    private void SetInPinStuckToTarget(Transform pin,float angle)
    {
        // 타겟의 해당 각도에 핀이 꽃혔을 때 위치
        pin.position = Utils.GetPositionFromAngle(targetRadius + pinLength, angle) + targetPosition;
        // 핀 오브젝트 회전 설정
        pin.rotation = Quaternion.Euler(0, 0, angle);
        // 핀 오브젝트를 target의 자식으로 설정해서 target과 같이 회전하도록 한다.
        pin.SetParent(targetTransform);
        // 핀이 과녁에 배치되었을 때 설정
        pin.GetComponent<Pin>().SetInPinStuckToTarget();
    }
}
