using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectionManager : MonoBehaviour
{
    // �ݷ��� ������ ��ŸƮ ������ ��ȯ�ϴ� �Լ�
    public void GoToStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
