using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    [Header("Commons")]
    [SerializeField]
    private GameObject pinPrefab; //»ç¿ëÇÒ ÇÉ ÇÁ¸®ÆÕ

    public void SpawnThrowablePin(Vector3 position)
    {
        //ÇÉ ¿ÀºêÁ§Æ® »ý¼º
        Instantiate(pinPrefab, position, Quaternion.identity);
    }
}
