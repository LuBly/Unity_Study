using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefabs; // 맵에 배치되는 타일 프리팹
    [SerializeField]
    private Transform currentTile; // 현재 타일 Transform 정보 (새로운 타일의 생성 위치 설정에 사용)

    [SerializeField]
    private int spawnTileCountAtStart = 100; // 게임을 시작할 때 생성되는 타일 개수

    private void Awake()
    {
        for(int i=0; i<spawnTileCountAtStart; i++)
        {
            CreateTile();
        }
    }

    public void CreateTile()
    {
        // tilePrefab 오브젝트 생성
        GameObject clone = Instantiate(tilePrefabs);
        // 생성된 타일의 부모 오브젝트를 "TileSpawner"로 설정
        clone.transform.SetParent(transform);
        // 타일이 재생성될 때 TileSpawner가 필요하기 때문에 Setup()메소드 매개변수로 넘겨준다.
        clone.GetComponent<Tile>().Setup(this);
        SpawnTile(clone.transform);
    }

    public void SpawnTile(Transform tile)
    {
        //스폰하려는 타일을 보이도록 설정
        tile.gameObject.SetActive(true);

        // 0,1 중 임의의 숫자 생성
        // 0이 나오면 currentTile의 오른쪽에
        // 1이 나오면 currentTIle의 앞쪽에 타일 배치
        int index = Random.Range(0, 2);
        Vector3 addPosition = index == 0 ? Vector3.right : Vector3.forward;
        tile.position = currentTile.position + addPosition;

        //마지막에 설정한 tile을 currentTile로 설정 (다음 타일을 배치할 때 위치 정보 활용)
        currentTile = tile;
    }

}
