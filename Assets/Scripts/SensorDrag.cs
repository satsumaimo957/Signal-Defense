using UnityEngine;

public class SensorDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Transform dragTarget = null;
    private Camera cam;

    private bool isPlaced = false;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (!GameManager.Instance.isPlacing) return;

        // クリック開始
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaced) return;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit[] hits = Physics.RaycastAll(ray, 100f, LayerMask.GetMask("Sensor"));

            float closestDist = Mathf.Infinity;
            Transform closest = null;

            foreach (var hit in hits)
            {
                Transform root = hit.collider.transform.root;

                if (root == transform)
                {
                    if (hit.distance < closestDist)
                    {
                        closestDist = hit.distance;
                        closest = root;
                    }
                }
            }

            if (closest == transform)
            {
                dragTarget = transform;
                isDragging = true;
            }
        }

        // 離したら終了
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            dragTarget = null;
            isPlaced = true; // ← ここで固定
        }

        // ドラッグ中
        if (isDragging && dragTarget == transform)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            Plane plane = new Plane(Vector3.up, Vector3.zero);

            float distance;
            if (plane.Raycast(ray, out distance))
            {
                Vector3 pos = ray.GetPoint(distance);
                transform.position = new Vector3(pos.x, 0.1f, pos.z);
            }
        }
    }
}