using UnityEngine;

public class EnemyVisibility : MonoBehaviour
{
    private Renderer[] renderers;


    [SerializeField] private bool isVisible = false; // 初期状態
    [SerializeField] private bool useVisibilitySystem = true; // ON/OFF切替

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        ApplyVisibility();
    }

    public bool IsVisible()
    {
        return isVisible;
    }

    public void SetVisible(bool visible)
    {
        if (!useVisibilitySystem) return;

        isVisible = visible;
        ApplyVisibility();
    }

    private void ApplyVisibility()
    {
        if (renderers == null) return;

        foreach (Renderer r in renderers)
        {
            r.enabled = isVisible;
        }
    }
}