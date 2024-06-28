using UnityEngine;

[RequireComponent(typeof(LineRenderer)), ExecuteAlways]
public class LineDrawer : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private LineRenderer lineRenderer;

    private void OnValidate()
    {
        lineRenderer ??= GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;

        UpdateLines();
    }

    private void Update()
    {
        UpdateLines();
    }

    private void UpdateLines()
    {
        lineRenderer.SetPosition(1, transform.position);
        lineRenderer.SetPosition(0, target.transform.position);
    }
}
