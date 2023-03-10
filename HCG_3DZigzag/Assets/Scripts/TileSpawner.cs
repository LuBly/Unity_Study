using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefabs; // �ʿ� ��ġ�Ǵ� Ÿ�� ������
    [SerializeField]
    private Transform currentTile; // ���� Ÿ�� Transform ���� (���ο� Ÿ���� ���� ��ġ ������ ���)

    [SerializeField]
    private int spawnTileCountAtStart = 100; // ������ ������ �� �����Ǵ� Ÿ�� ����

    private void Awake()
    {
        for(int i=0; i<spawnTileCountAtStart; i++)
        {
            CreateTile();
        }
    }

    public void CreateTile()
    {
        // tilePrefab ������Ʈ ����
        GameObject clone = Instantiate(tilePrefabs);
        // ������ Ÿ���� �θ� ������Ʈ�� "TileSpawner"�� ����
        clone.transform.SetParent(transform);
        // Ÿ���� ������� �� TileSpawner�� �ʿ��ϱ� ������ Setup()�޼ҵ� �Ű������� �Ѱ��ش�.
        clone.GetComponent<Tile>().Setup(this);
        SpawnTile(clone.transform);
    }

    public void SpawnTile(Transform tile)
    {
        //�����Ϸ��� Ÿ���� ���̵��� ����
        tile.gameObject.SetActive(true);

        // 0,1 �� ������ ���� ����
        // 0�� ������ currentTile�� �����ʿ�
        // 1�� ������ currentTIle�� ���ʿ� Ÿ�� ��ġ
        int index = Random.Range(0, 2);
        Vector3 addPosition = index == 0 ? Vector3.right : Vector3.forward;
        tile.position = currentTile.position + addPosition;

        //�������� ������ tile�� currentTile�� ���� (���� Ÿ���� ��ġ�� �� ��ġ ���� Ȱ��)
        currentTile = tile;
    }

}
