using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI tamagoCount;
    public TextMeshProUGUI successText;
    public TextMeshProUGUI haveText;
    public GameObject touchObject;
    public ScreenFader screenFader;
    public TamagoManager tamagoManager;
    public MonsterManager monsterManager;
    public AudioSource audioSource;

    public AudioClip[] sfxClips; // �߰�: ���� ���� SFX ����� Ŭ��

    private bool hasHatched = false; // ���� ��ȭ�ߴ��� ���θ� ��Ÿ���� ����

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        tamagoCount.text = "10000";
        tamagoManager.InitializeTamagoState();

        successText.gameObject.SetActive(false);
        haveText.gameObject.SetActive(false);

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (!hasHatched && Input.GetMouseButtonDown(0)) // ���� ��ȭ�ϱ� ������ Ŭ�� �Է��� ó��
        {
            int currentCount = int.Parse(tamagoCount.text);
            currentCount--;
            tamagoCount.text = currentCount.ToString();

            tamagoManager.UpdateTamagoState(currentCount);
            tamagoManager.ClickTrigger();

            // �������� SFX ���
            PlayRandomSFX();

            if (currentCount <= 0)
            {
                StartCoroutine(screenFader.StartFadeOutAndSpawnMonster());
                hasHatched = true; // ���� ��ȭ������ ����
            }
        }

        // ���콺 ��Ŭ���� �����Ͽ� ��ŸƮ ������ ���ư���
        if (Input.GetMouseButtonDown(1))
        {
            GoToStartScene();
        }
    }

    void PlayRandomSFX()
    {
        if (audioSource != null && sfxClips != null && sfxClips.Length > 0)
        {
            int randomIndex = Random.Range(0, sfxClips.Length);
            audioSource.clip = sfxClips[randomIndex];
            audioSource.Play();
        }
    }

    public void GoToStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}