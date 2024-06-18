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

        // tamagoCount�� Touch ������Ʈ ��Ȱ��ȭ
        GameManager.Instance.tamagoCount.gameObject.SetActive(false);
        GameManager.Instance.touchObject.SetActive(false);

        // ���� ����
        string monsterName = GameManager.Instance.monsterManager.SpawnRandomMonster();

        // Success �� Have ������Ʈ Ȱ��ȭ
        GameManager.Instance.successText.gameObject.SetActive(true);
        GameManager.Instance.haveText.gameObject.SetActive(true);

        // Success �ؽ�Ʈ ����
        GameManager.Instance.successText.text = "��  ��ȭ �߽��ϴ�!  ��";

        // Have �ؽ�Ʈ ����
        GameManager.Instance.haveText.text = monsterName + "�� �����!";

        animator.SetTrigger("FadeIn");

        yield return new WaitForSeconds(1.0f);

        Debug.Log("ȭ�� ���̵� �� �Ϸ�");
    }
}