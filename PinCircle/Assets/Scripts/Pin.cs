using System.Collections; // 코루틴 사용을 위해 추가
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    private GameObject square; // 핀의 막대 부분
    [SerializeField]
    private float moveTime = 0.2f; // 게임 하단에서 핀 1회 이동 시간.

    public void SetInPinStuckToTarget()
    {
        // Throwable Pin으로 사용되던 핀의 경우 움직이고 있을 수도 있기 때문에 이동 중지
        StopCoroutine("MoveTo");
        // 핀의 막대 오브젝트 활성화
        square.SetActive(true);
    }

    public void MoveOneStep(float moveDistancce)
    {
        StartCoroutine("MoveTo", moveDistancce);
    }

    private IEnumerator MoveTo(float moveDistance) 
    {
        Vector3 start = transform.position;
        Vector3 end = transform.position+Vector3.up*moveDistance;

        float current = 0;
        float percent = 0;
        while(percent<1)
        {
            current += Time.deltaTime;
            percent = current / moveTime;

            transform.position = Vector3.Lerp(start, end, percent);

            yield return null;
        }
    }
}
