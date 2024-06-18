using UnityEngine;

public class TamagoManager : MonoBehaviour
{
    public Animator animator;

    private int tamagoState;

    void Start()
    {
        tamagoState = 0; // 일반 알
        UpdateTamagoState();
    }

    public void InitializeTamagoState()
    {
        tamagoState = 0; // 일반 알
        UpdateTamagoState();
    }

    public void UpdateTamagoState(int currentCount)
    {
        if (currentCount < 5000 && currentCount >= 1000)
        {
            tamagoState = 1; // 중간정도 깨진 알
        }
        else if (currentCount < 1000)
        {
            tamagoState = 2; // 거의 다 깨진 알
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