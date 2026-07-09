using UnityEngine;

public class Flutuacao : MonoBehaviour
{
    [SerializeField] float superficieMar;
    [SerializeField] float flutuabilidade = 10f;
    [SerializeField] float arrasto = 0.1f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
            Debug.LogError("Rigidbody não encontrado em " + gameObject.name);
    }

    void FixedUpdate()
    {
        if (transform.position.y < superficieMar)
        {
            Flutua();
        }
    }

    void Flutua()
    {
        float profundidade = superficieMar - transform.position.y;
        float forcaFlutuacao = profundidade * flutuabilidade;

        rb.AddForce(Vector3.up * forcaFlutuacao, ForceMode.Acceleration);

        rb.linearVelocity *= (1f - arrasto);
    }
}