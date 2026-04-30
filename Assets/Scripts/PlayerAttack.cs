using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject explosionPrefab;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 左クリック
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            int layerMask = LayerMask.GetMask("Enemy");

            if (Physics.Raycast(ray, out hit, 100f, layerMask))
            {
                GameObject obj = hit.collider.gameObject;
                Transform root = hit.collider.transform.root;

                if (root.CompareTag("Enemy"))
                {
                    EnemyVisibility vis = root.GetComponent<EnemyVisibility>();

                    if (vis != null && vis.IsVisible())
                    {
                        // ★ 敵の位置で爆発
                        GameObject effect = Instantiate(
                            explosionPrefab,
                            root.position,
                            Quaternion.identity
                        );

                        Destroy(root.gameObject);

                        // ★ エフェクトだけ消す
                        Destroy(effect, 2f);

                        Debug.Log("敵を撃破！");
                    }
                    else
                    {
                        Debug.Log("見えてないから倒せない");
                    }
                }
            }
        }
    }
}