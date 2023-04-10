using UnityEngine;

public class Utils
{
    /// <summary>
    /// ������ �������� ���� �ѷ� ��ġ�� ���Ѵ�.
    /// </summary>
    /// <param name="radius">���� ������</param>
    /// <param name="angle">����</param>
    /// <returns></returns>
    public static Vector3 GetPositionFromAngle(float radius, float angle)
    {
        Vector3 position = Vector3.zero;
        angle = DegreeToRadian(angle);
        //������ ���� �������� ��ǥ�� Ȱ���Ͽ� pin�� position�� ����
        position.x = Mathf.Cos(angle)*radius;
        position.y = Mathf.Sin(angle)*radius;

        return position;
    }
    /// <summary>
    /// Degree���� Radian ������ ����
    /// 1�� = Pi/180 radian
    /// angle�� = angle*Pi/180 radian
    /// </summary>
    /// <param name="angle">Degree��</param>
    /// <returns></returns>
    public static float DegreeToRadian(float angle)
    {
        return Mathf.PI * angle / 180;
    }
    /// <summary>
    /// Radian���� Degree ������ ��ȯ
    /// 1radian = 180/Pi ��
    /// angle radian = 180/Pi * angle ��
    /// </summary>
    /// <param name="angle">radian ��</param>
    /// <returns></returns>
    public static float RadianToDegree(float angle)
    {
        return angle*(180/Mathf.PI);
    }
}
