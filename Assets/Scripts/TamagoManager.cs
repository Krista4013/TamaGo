using UnityEngine;

public class TamagoManager : MonoBehaviour
{
    public Animator animator;

    private int tamagoState;

    void Start()
    {
        tamagoState = 0; // �Ϲ� ��
        UpdateTamagoState();
    }

    public void InitializeTamagoState()
    {
        tamagoState = 0; // �Ϲ� ��
        UpdateTamagoState();
    }

    public void UpdateTamagoState(int currentCount)
    {
        if (currentCount < 5000 && currentCount >= 1000)
        {
            tamagoState = 1; // �߰����� ���� ��
        }
        else if (currentCount < 1000)
        {
            tamagoState = 2; // ���� �� ���� ��
        }

        UpdateTamagoState();
    }

    void UpdateTamagoState()
    {
        animator.SetInteger("tamagoState", tamagoState);
    }

    public void ClickTrigger()
    {
        animator.SetTrigger("ClickTrigger");
    }
}