using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawn : MonoBehaviour
{
    public List<GameObject> gemPrefabs; // Danh sách các prefab Gem
    public List<Transform> spawnPoints; // Danh sách các vị trí spawn
    private int gemTagCount; // Số lượng đối tượng có tag Gem

    void Start()
    {
        // Đếm số lượng đối tượng có tag Gem
        gemTagCount = GameObject.FindGameObjectsWithTag("Gem").Length;

        // Nếu không có đối tượng nào có tag Gem, thì bắt đầu spawn lại các gem
        if (gemTagCount == 0)
        {
            SpawnGems();
        }
    }

    void SpawnGems()
    {
        // Tạo danh sách vị trí spawn gem và các prefab gem tương ứng
        List<Transform> availableSpawnPoints = new List<Transform>(spawnPoints);
        List<GameObject> availableGemPrefabs = new List<GameObject>(gemPrefabs);

        // Tạo gem cho mỗi vị trí spawn
        foreach (Transform spawnPoint in spawnPoints)
        {
            // Nếu không còn vị trí spawn hoặc prefab gem nào khả dụng, thoát khỏi vòng lặp
            if (availableSpawnPoints.Count == 0 || availableGemPrefabs.Count == 0)
                break;

            // Chọn ngẫu nhiên một prefab gem từ danh sách có sẵn
            int randomIndex = Random.Range(0, availableGemPrefabs.Count);
            GameObject selectedGemPrefab = availableGemPrefabs[randomIndex];

            // Chọn ngẫu nhiên một vị trí spawn từ danh sách có sẵn
            randomIndex = Random.Range(0, availableSpawnPoints.Count);
            Transform selectedSpawnPoint = availableSpawnPoints[randomIndex];

            // Spawn gem tại vị trí đã chọn
            Instantiate(selectedGemPrefab, selectedSpawnPoint.position, Quaternion.identity);

            // Xóa vị trí và prefab gem đã sử dụng khỏi danh sách để tránh spawn hai gem cùng một vị trí
            availableSpawnPoints.RemoveAt(randomIndex);
            availableGemPrefabs.Remove(selectedGemPrefab);
        }
    }
}
