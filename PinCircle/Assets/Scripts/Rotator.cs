using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private StageController stageController;
    [SerializeField]
    private float rotateSpeed = 50;                 // ȸ�� �ӵ�
    [SerializeField]
    private float maxRotateSpeed = 500;             // �ִ� ȸ�� �ӵ�
    [SerializeField]
    private Vector3 rotateAngle = Vector3.forward;  // ȸ�� ����
    
    //GameOver�Ǿ��� �� StageController���� ������ ȸ���� ���߱� ���� �Լ�
    public void Stop()
    {
        rotateSpeed = 0;
    }

    public void RotateFast()
    {
        rotateSpeed = maxRotateSpeed;
    }
    private void Update()
    {
        //IsGameStart�� false�� ������ ���ӽ��� ���̱� ������ ȸ��ü�� ȸ������ �ʴ´�.
        if (!stageController.isGameStart) return;
        //���� * �ӵ� * Time.deltaTime ���� ������Ʈ ȸ��
        transform.Rotate(rotateAngle*rotateSpeed*Time.deltaTime);
    }
}
