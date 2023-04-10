using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    private GameObject square; // 핀의 막대 부분

    public void SetInPinStuckToTarget()
    {
        // 핀의 막대 오브젝트 활성화
        square.SetActive(true);
    }
}
