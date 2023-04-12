using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 50;                 // ȸ�� �ӵ�
    [SerializeField]
    private Vector3 rotateAngle = Vector3.forward;  // ȸ�� ����
    
    //GameOver�Ǿ��� �� StageController���� ������ ȸ���� ���߱� ���� �Լ�
    public void Stop()
    {
        rotateSpeed = 0;
    }
    private void Update()
    {
        //���� * �ӵ� * Time.deltaTime ���� ������Ʈ ȸ��
        transform.Rotate(rotateAngle*rotateSpeed*Time.deltaTime);
    }
}
