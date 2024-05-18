using UnityEngine;

public class GemController : MonoBehaviour
{
    Camera cam;                     // Biến lưu trữ camera
    GameObject selectedGem = null; // Biến lưu trữ khối gem được chọn

    public GameObject GetSelectedGem()
    {
        return selectedGem;
    }

    void Start()
    {
        cam = Camera.main; // Lấy camera chính của scene
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))                // Kiểm tra xem chuột trái có được nhấn xuống không
        {
            Vector3 mousePos = Input.mousePosition;     // Lấy vị trí chuột trên màn hình
            Vector2 worldPos = cam.ScreenToWorldPoint(mousePos); // Chuyển đổi vị trí chuột từ màn hình sang tọa độ thế giới

            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero); // Thực hiện raycast và kiểm tra xem nó có trúng đối tượng nào không

            if (hit.collider != null && hit.collider.gameObject.CompareTag("Gem")) // Kiểm tra xem đối tượng bị trúng có tag là "Gem" không
            {
                selectedGem = hit.collider.gameObject; // Lưu đối tượng bị trúng vào biến selectedGem
            }
        }

        if (Input.GetMouseButton(0) && selectedGem != null) // Kiểm tra nếu chuột trái đang được giữ và có một khối được chọn
        {
            Vector3 mousePos = Input.mousePosition; // Lấy lại vị trí chuột
            Vector2 worldPos = cam.ScreenToWorldPoint(mousePos); // Chuyển đổi vị trí chuột từ màn hình sang tọa độ thế giới

            selectedGem.transform.position = new Vector3(worldPos.x, worldPos.y, selectedGem.transform.position.z); // Cập nhật vị trí của khối theo trục x và y
        }

        if (Input.GetMouseButtonUp(0)) // Kiểm tra nếu chuột trái được thả ra
        {
            selectedGem = null; // Hủy bỏ việc chọn khối
        }
    }
}
