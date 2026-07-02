using UnityEngine;
 
[RequireComponent(typeof(Rigidbody))]
public class BarcoController : MonoBehaviour
{
    [Header("Movimento")]
    [SerializeField] float forcaMotor = 500f;
    [SerializeField] float forcaRe = 250f;
    [SerializeField] float velocidadeMaxima = 15f;
    [SerializeField] float velocidadeMaximaRe = 5f;
 
    [Header("Viragem")]
    [SerializeField] float velocidadeVirada = 80f;
    [SerializeField] float velocidadeMinimaPraVirar = 0.5f;
 
    [Header("Arrasto")]
    [SerializeField] float arrastoLinear = 0.5f;
    [SerializeField] float arrastoAngular = 5f;
 
    [Header("Referências")]
    [SerializeField] Transform pontoSaida;
    [SerializeField] Transform pontoCameraBarco;
 
    public Transform PontoSaida => pontoSaida;
    public Transform PontoCameraBarco => pontoCameraBarco;
 
    Rigidbody rb;
    float inputVertical;
    float inputHorizontal;
 
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = arrastoLinear;
        rb.angularDamping = arrastoAngular;
 
        // Impede que objetos filhos (ex: player sentado) desloquem o centro de massa
        rb.automaticCenterOfMass = false;
        rb.centerOfMass = Vector3.zero;
 
        rb.constraints = RigidbodyConstraints.FreezeRotationX
                       | RigidbodyConstraints.FreezeRotationZ;
    }
 
    void Update()
    {
        inputVertical   = Input.GetAxis("Vertical");
        inputHorizontal = Input.GetAxis("Horizontal");
    }
 
    void FixedUpdate()
    {
        Mover();
        Virar();
    }
 
    void Mover()
    {
        if (rb.linearVelocity.magnitude >= velocidadeMaxima && inputVertical > 0)
            return;
        if (rb.linearVelocity.magnitude >= velocidadeMaximaRe && inputVertical < 0)
            return;
 
        Vector3 direcaoHorizontal = Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;
 
        float forca = inputVertical > 0
            ? inputVertical * forcaMotor
            : inputVertical * forcaRe;
 
        rb.AddForce(direcaoHorizontal * forca, ForceMode.Force);
    }
 
    void Virar()
    {
        Vector3 velocidadeHorizontal = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        bool estaSeMovendo = velocidadeHorizontal.magnitude > velocidadeMinimaPraVirar;
 
        if (!estaSeMovendo || inputHorizontal == 0f)
            return;
 
        float direcao = inputVertical >= 0 ? 1f : -1f;
 
        float rotacao = inputHorizontal * velocidadeVirada * direcao * Time.fixedDeltaTime;
        Quaternion deltaRotacao = Quaternion.Euler(0f, rotacao, 0f);
        rb.MoveRotation(rb.rotation * deltaRotacao);
    }
 
    // Reforça o centro de massa ao entrar/sair do barco
    public void ResetarCenterOfMass()
    {
        rb.centerOfMass = Vector3.zero;
    }
 
#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        if (rb == null) return;
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, rb.linearVelocity);
    }
#endif
}