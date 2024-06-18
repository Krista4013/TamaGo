using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectionManager : MonoBehaviour
{
    // 콜렉션 씬에서 스타트 씬으로 전환하는 함수
    public void GoToStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
