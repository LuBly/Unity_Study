using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class RectTransformMovers : MonoBehaviour
{
    // �̺�Ʈ ��� �� �̺�Ʈ�� ��ϵ� �޼ҵ� ȣ���� ���� �̺�Ʈ Ŭ����, Ŭ���� �ν��Ͻ�
    private class EndMoveEvent : UnityEvent { } // 1. �̺�Ʈ Ŭ���� ����
    private EndMoveEvent onEndMoveEvent;        // 2. �̺�Ʈ Ŭ���� �ν��Ͻ� ����

    [SerializeField]
    private float moveTime = 1.0f;
    private RectTransform rectTransform;
    private bool isMoved = false;

    private void Awake()
    {
        onEndMoveEvent= new EndMoveEvent();     // 3. Ŭ���� �ν��Ͻ� �޸� �Ҵ�
        rectTransform = GetComponent<RectTransform>();
    }

    public void MoveTo(UnityAction action, Vector3 position)
    {
        if (!isMoved)
        {
            // �Ű������� �޾ƿ� action �޼ҵ带 onEndMoveEvent�� ���
            onEndMoveEvent.AddListener(action); // 4. �̺�Ʈ �޼ҵ���

            StartCoroutine(OnMove(action, position));
        }
    }
    // ���θ޴� ����� �̵���Ű�� Method
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

        // onEndMoveEvent�� ��ϵǾ� �ִ� action �޼ҵ� ����
        onEndMoveEvent.Invoke();                // 5. �̺�Ʈ �޼ҵ� ȣ��

        // action �޼ҵ带 onEndMoveEvent �̺�Ʈ���� ����
        onEndMoveEvent.RemoveListener(action);  // 6. �̺�Ʈ �޼ҵ� ����
    }
}
