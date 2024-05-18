using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    public List<GameObject> gridObjects = new List<GameObject>(); // Danh sách các vị trí trên bàn
    GemController gemController; // Tham chiếu tới GemController để lấy selectedGem

    void Start()
    {
        gemController = FindObjectOfType<GemController>(); // Tìm GemController trong scene
    }

    void Update()
    {
        // Kiểm tra nếu có selectedGem và đã thả chuột
        if (gemController.GetSelectedGem() != null && Input.GetMouseButtonUp(0))
        {
            // Lặp qua tất cả các vị trí trên bàn
            foreach (GameObject gridObject in gridObjects)
            {
                // Tính khoảng cách giữa selectedGem và vị trí trên bàn
                float distance = Vector2.Distance(gemController.GetSelectedGem().transform.position, gridObject.transform.position);

                // Nếu khoảng cách nhỏ hơn 0.5, di chuyển selectedGem đến vị trí trên bàn và kết thúc vòng lặp
                if (distance < 0.5f)
                {
                    gemController.GetSelectedGem().transform.position = gridObject.transform.position;
                    break;
                }
            }
        }
    }
}
