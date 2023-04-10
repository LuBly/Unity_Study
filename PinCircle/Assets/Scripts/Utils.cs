using UnityEngine;

public class Utils
{
    /// <summary>
    /// 각도를 기준으로 원의 둘레 위치를 구한다.
    /// </summary>
    /// <param name="radius">원의 반지름</param>
    /// <param name="angle">각도</param>
    /// <returns></returns>
    public static Vector3 GetPositionFromAngle(float radius, float angle)
    {
        Vector3 position = Vector3.zero;
        angle = DegreeToRadian(angle);
        //각도에 따른 원에서의 좌표를 활용하여 pin의 position을 셋팅
        position.x = Mathf.Cos(angle)*radius;
        position.y = Mathf.Sin(angle)*radius;

        return position;
    }
    /// <summary>
    /// Degree값을 Radian 값으로 변경
    /// 1도 = Pi/180 radian
    /// angle도 = angle*Pi/180 radian
    /// </summary>
    /// <param name="angle">Degree값</param>
    /// <returns></returns>
    public static float DegreeToRadian(float angle)
    {
        return Mathf.PI * angle / 180;
    }
    /// <summary>
    /// Radian값을 Degree 값으로 변환
    /// 1radian = 180/Pi 도
    /// angle radian = 180/Pi * angle 도
    /// </summary>
    /// <param name="angle">radian 값</param>
    /// <returns></returns>
    public static float RadianToDegree(float angle)
    {
        return angle*(180/Mathf.PI);
    }
}
