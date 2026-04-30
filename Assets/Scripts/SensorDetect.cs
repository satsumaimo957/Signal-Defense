using UnityEngine;

public class SensorDetect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Transform root = other.transform.root;

        if (root.CompareTag("Enemy"))
        {
            var vis = root.GetComponent<EnemyVisibility>();
            if (vis != null)
            {
                vis.SetVisible(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Transform root = other.transform.root;

        if (root.CompareTag("Enemy"))
        {
            var vis = root.GetComponent<EnemyVisibility>();
            if (vis != null)
            {
                vis.SetVisible(false);
            }
        }
    }
}