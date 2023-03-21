using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName = "")
    {
        // 매개변수가 비어있으면 현재 씬을 다시로드
        if(sceneName == "")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // 매개변수가 비어있지 않으면 매개변수에 입력된 문자열의 씬 로드
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }



}
