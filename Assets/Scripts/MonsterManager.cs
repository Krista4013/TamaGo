using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // 여러 종류의 몬스터 프리팹을 배열로 관리
    public string[] monsterNames; // 몬스터 이름을 배열로 관리

    public string SpawnRandomMonster()
    {
        int index = Random.Range(0, monsterPrefabs.Length);
        GameObject randomMonsterPrefab = monsterPrefabs[index];

        Vector3 spawnPosition = new Vector3(0f, 0f, 0f);
        Instantiate(randomMonsterPrefab, spawnPosition, Quaternion.identity);

        return monsterNames[index]; // 몬스터 이름 반환
    }
}