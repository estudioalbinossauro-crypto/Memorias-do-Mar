using UnityEngine;

public class ControlaLinha : MonoBehaviour
{
    [SerializeField] Transform pontaVara;
    private Rigidbody rb;
    private bool Arremessando = false;
    [SerializeField] float forcaArremesso = 3f;
    public Camera Cam;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        
        if (pontaVara == null) return;

        if (!Arremessando)
        {
            NaPonta();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Arremessada();
            Arremessando = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Arremessando = false;
        }
    }
    public void NaPonta()
    {
        transform.position = pontaVara.position - new Vector3(0, 1f, 0);

        if (rb != null) rb.isKinematic = true;
    }
    public void Arremessada()
    {
        if (rb != null) rb.isKinematic = false;
        Vector3 direcaoOlhar = Cam.transform.forward;

        Vector3 forcaFinal = (direcaoOlhar * forcaArremesso);

        rb.AddForce(forcaFinal, ForceMode.Impulse);
        
    }
    

}