using UnityEngine;

public class GoalArea : MonoBehaviour
{
    public int escapedCount = 0;
    public int maxEscape = 10;

    public int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        Transform root = other.transform.root;
        if (root.CompareTag("Enemy"))
        {
            escapedCount++;

            Destroy(root.gameObject);

            GameManager.Instance.TakeDamage(damage);

            Debug.Log("逃げた数: " + escapedCount);

            if (escapedCount >= maxEscape)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}