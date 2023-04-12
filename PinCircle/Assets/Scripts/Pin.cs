using System.Collections; // �ڷ�ƾ ����� ���� �߰�
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    private GameObject square;               // ���� ���� �κ�
    [SerializeField]
    private float moveTime = 0.2f;           // ���� �ϴܿ��� �� 1ȸ �̵� �ð�.

    private StageController stageController; // GameOver()������ ���� StageController ������Ʈ

    public void Setup(StageController stageController)
    {
        this.stageController = stageController;
    }
    public void SetInPinStuckToTarget()
    {
        // Throwable Pin���� ���Ǵ� ���� ��� �����̰� ���� ���� �ֱ� ������ �̵� ����
        StopCoroutine("MoveTo");
        // ���� ���� ������Ʈ Ȱ��ȭ
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Pin"))
        {
            stageController.GameOver();
        }
    }
}
