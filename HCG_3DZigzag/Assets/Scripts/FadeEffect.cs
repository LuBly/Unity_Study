using System.Collections;
using UnityEngine;
using TMPro;

public class FadeEffect : MonoBehaviour
{
    [SerializeField]
    private float fadeTime = 0.5f; // 페이드 효과가 완료되는 시간
    [SerializeField]
    private AnimationCurve fadeCurve;// 페이드 효과가 적용되는 값을 직선이 아닌 곡선으로 설정할 때 사용
    private TextMeshProUGUI fadeText;// 페이드 효과가 적용되는 Text UI

    private float endAlpha; // 페이드 효과 재생 완료 후 Alpha 값

    private void Awake()
    {
        fadeText = GetComponent<TextMeshProUGUI>();
        //UI마다 현재 설정되어 있는 알파값이 다르기 때문에 FadeIn이 종료되는 알파값을 따로 설정
        endAlpha = fadeText.color.a;
    }

    public void FadeIn()
    {
        //UI의 알파값이 0에서 1로
        StartCoroutine(Fade(0, endAlpha));
    }

    private IEnumerator Fade(float start, float end)
    {
        float current = 0;
        float percent = 0;
        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / fadeTime;
            Color color = fadeText.color;
            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));
            fadeText.color = color;

            yield return null;
        }
    }
}
