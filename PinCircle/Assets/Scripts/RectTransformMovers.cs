using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class RectTransformMovers : MonoBehaviour
{
    // 이벤트 등록 및 이벤트에 등록된 메소드 호출을 위한 이벤트 클래스, 클래스 인스턴스
    private class EndMoveEvent : UnityEvent { } // 1. 이벤트 클래스 생성
    private EndMoveEvent onEndMoveEvent;        // 2. 이벤트 클래스 인스턴스 생성

    [SerializeField]
    private float moveTime = 1.0f;
    private RectTransform rectTransform;
    private bool isMoved = false;

    private void Awake()
    {
        onEndMoveEvent= new EndMoveEvent();     // 3. 클래스 인스턴스 메모리 할당
        rectTransform = GetComponent<RectTransform>();
    }

    public void MoveTo(UnityAction action, Vector3 position)
    {
        if (!isMoved)
        {
            // 매개변수로 받아온 action 메소드를 onEndMoveEvent에 등록
            onEndMoveEvent.AddListener(action); // 4. 이벤트 메소드등록

            StartCoroutine(OnMove(action, position));
        }
    }
    // 메인메뉴 페널을 이동시키는 Method
    private IEnumerator OnMove(UnityAction action, Vector3 end)
    {
        float current = 0;
        float percent = 0;
        Vector3 start = rectTransform.anchoredPosition;

        isMoved= true;
        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTime;

            rectTransform.anchoredPosition = Vector3.Lerp(start, end, percent);

            yield return null;
        }
        isMoved = false;

        // onEndMoveEvent에 등록되어 있는 action 메소드 실행
        onEndMoveEvent.Invoke();                // 5. 이벤트 메소드 호출

        // action 메소드를 onEndMoveEvent 이벤트에서 제거
        onEndMoveEvent.RemoveListener(action);  // 6. 이벤트 메소드 해제
    }
}
