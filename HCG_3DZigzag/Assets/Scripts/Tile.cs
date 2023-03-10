using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private float falldownTime = 2; // 타일이 아래로 떨어지는 시간
    private Rigidbody rigidbody; // 타일 추락 설정을 위한 Rigidbody
    private TileSpawner tileSpawner = null; // 타일 재생성 메소드 호출을 위한 TileSpawner

    private void Awake()
    {
        rigidbody= GetComponent<Rigidbody>();
    }

    public void Setup(TileSpawner tileSpawner)
    {
        this.tileSpawner = tileSpawner;
    }
    private void OnCollisionExit(Collision collision)
    {
        //플레이어가 타일을 밟고 지나가면 아래로 떨어진다
        if (collision.transform.tag.Equals("Player"))
        {
            StartCoroutine("FallDownAndRespawnTile");
        }
    }

    private IEnumerator FallDownAndRespawnTile()
    {
        yield return new WaitForSeconds(0.1f);

        //물리가 적용되도록 설정 (중력을 받아 아래로 떨어진다.)
        rigidbody.isKinematic = false;

        yield return new WaitForSeconds(falldownTime);

        //물리가 적용되지 않도록 설정
        rigidbody.isKinematic = true;

        if(tileSpawner != null) tileSpawner.SpawnTile(this.transform);
        else gameObject.SetActive(false);
    }
}
