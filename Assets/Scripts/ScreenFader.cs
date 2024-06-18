using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        if (animator == null)
        {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }
    }

    public IEnumerator StartFadeOutAndSpawnMonster()
    {
        animator.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1.0f);

        GameManager.Instance.tamagoManager.gameObject.SetActive(false);

        // tamagoCount와 Touch 오브젝트 비활성화
        GameManager.Instance.tamagoCount.gameObject.SetActive(false);
        GameManager.Instance.touchObject.SetActive(false);

        // 몬스터 생성
        string monsterName = GameManager.Instance.monsterManager.SpawnRandomMonster();

        // Success 및 Have 오브젝트 활성화
        GameManager.Instance.successText.gameObject.SetActive(true);
        GameManager.Instance.haveText.gameObject.SetActive(true);

        // Success 텍스트 설정
        GameManager.Instance.successText.text = "축  부화 했습니다!  하";

        // Have 텍스트 설정
        GameManager.Instance.haveText.text = monsterName + "를 얻었다!";

        animator.SetTrigger("FadeIn");

        yield return new WaitForSeconds(1.0f);

        Debug.Log("화면 페이드 인 완료");
    }
}