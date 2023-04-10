using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    [Header("Commons")]
    [SerializeField]
    private GameObject pinPrefab; //����� �� ������

    public void SpawnThrowablePin(Vector3 position)
    {
        //�� ������Ʈ ����
        Instantiate(pinPrefab, position, Quaternion.identity);
    }
}
