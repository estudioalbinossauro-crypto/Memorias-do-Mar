using UnityEngine;

public class GerenciadorLinhaPesca : MonoBehaviour
{
    [SerializeField] Transform pontaVara;
    [SerializeField] Transform iscaVara;
    [SerializeField] private float curvatura = 0.1f;
    [SerializeField, Range(5, 30)] private int segmentos = 15;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    void FixedUpdate()
    {
        if (pontaVara == null || iscaVara == null) return;
        DesenharLinha();
    }
    void DesenharLinha()
    {
        lineRenderer.positionCount = segmentos;

        Vector3 pontoControle = (pontaVara.position + iscaVara.position) / 2;
        pontoControle.y -= curvatura;

        for (int i = 0; i < segmentos; i++)
        {
            float t = i / (float)(segmentos - 1);
            Vector3 posicaoNaCurva = CalcularBezier(t, pontaVara.position, pontoControle, iscaVara.position);
            lineRenderer.SetPosition(i, posicaoNaCurva);
        }
    }
    Vector3 CalcularBezier(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * p0 + 2 * u * t * p1 + tt * p2;
        return p;
    }
}