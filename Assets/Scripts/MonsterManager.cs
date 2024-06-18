using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // ���� ������ ���� �������� �迭�� ����
    public string[] monsterNames; // ���� �̸��� �迭�� ����

    public string SpawnRandomMonster()
    {
        int index = Random.Range(0, monsterPrefabs.Length);
        GameObject randomMonsterPrefab = monsterPrefabs[index];

        Vector3 spawnPosition = new Vector3(0f, 0f, 0f);
        Instantiate(randomMonsterPrefab, spawnPosition, Quaternion.identity);

        return monsterNames[index]; // ���� �̸� ��ȯ
    }
}