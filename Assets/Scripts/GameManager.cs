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

    public AudioClip[] sfxClips; // 추가: 여러 개의 SFX 오디오 클립

    private bool hasHatched = false; // 알이 부화했는지 여부를 나타내는 변수

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
        if (!hasHatched && Input.GetMouseButtonDown(0)) // 알이 부화하기 전에만 클릭 입력을 처리
        {
            int currentCount = int.Parse(tamagoCount.text);
            currentCount--;
            tamagoCount.text = currentCount.ToString();

            tamagoManager.UpdateTamagoState(currentCount);
            tamagoManager.ClickTrigger();

            // 랜덤으로 SFX 재생
            PlayRandomSFX();

            if (currentCount <= 0)
            {
                StartCoroutine(screenFader.StartFadeOutAndSpawnMonster());
                hasHatched = true; // 알이 부화했음을 설정
            }
        }

        // 마우스 우클릭을 감지하여 스타트 씬으로 돌아가기
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