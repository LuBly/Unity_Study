using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 50;                 // ȸ�� �ӵ�
    [SerializeField]
    private Vector3 rotateAngle = Vector3.forward;  // ȸ�� ����

    private void Update()
    {
        //���� * �ӵ� * Time.deltaTime ���� ������Ʈ ȸ��
        transform.Rotate(rotateAngle*rotateSpeed*Time.deltaTime);
    }
}
