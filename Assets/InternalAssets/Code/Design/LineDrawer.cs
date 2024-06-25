using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineDrawer : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private LineRenderer lineRenderer;

    private void OnValidate()
    {
        lineRenderer ??= GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        lineRenderer.SetPosition(1, transform.position);
        lineRenderer.SetPosition(0, target.transform.position);
    }
}
