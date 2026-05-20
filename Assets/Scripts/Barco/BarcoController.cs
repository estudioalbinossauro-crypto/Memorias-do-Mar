using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BarcoController : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    [SerializeField] private float forcaMotor = 20f;
    [SerializeField] private float vMax = 15f;
    [SerializeField] private float torqueGiro = 2f;
    [SerializeField] private float arrastoLinear = 0.5f;
    [SerializeField] private float arrastoAngular = 0.8f;

    [Header("Câmera do Barco (Terceira Pessoa)")]
    [SerializeField] private Transform cameraTransform; // Arraste a Main Camera aqui
    [SerializeField] private Vector3 offsetCamera = new Vector3(0, 5, -10);
    [SerializeField] private float suavidadeCamera = 0.125f;

    private Rigidbody rb;
    private float inputVertical;
    private float inputHorizontal;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = arrastoLinear;
        rb.angularDamping = arrastoAngular;
    }
    void OnEnable()
    {
        // Se a câmera não foi definida, tenta pegar a Main Camera
        if (cameraTransform == null) cameraTransform = Camera.main.transform;
    }
    void OnDisable()
    {
        // Reseta inputs e para o barco imediatamente ao sair
        inputVertical = 0;
        inputHorizontal = 0;
        if (rb != null) rb.linearVelocity = Vector3.zero;
    }
    void Update()
    {
        inputVertical = Input.GetAxis("Vertical");
        inputHorizontal = Input.GetAxis("Horizontal");
    }
    void FixedUpdate()
    {
        MoverBarco();
        GirarBarco();
    }
    void LateUpdate()
    {
        // SÓ gerencia a câmera se o script estiver ativo (player dentro)
        if (cameraTransform != null && enabled) 
        {
            GerenciarCamera();
        }
    }
    void MoverBarco()
    {
        if (Mathf.Abs(inputVertical) > 0.01f)
        {
            rb.AddForce(transform.forward * inputVertical * forcaMotor, ForceMode.Acceleration);
        }

        // Clamp de velocidade eficiente
        if (rb.linearVelocity.sqrMagnitude > vMax * vMax)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * vMax;
        }
    }
    void GirarBarco()
    {
        // Evita girar parado
        float fatorVelocidade = Mathf.Clamp01(rb.linearVelocity.magnitude / (vMax * 0.2f));
        float forcaFinalGiro = inputHorizontal * torqueGiro * fatorVelocidade;

        rb.AddTorque(Vector3.up * forcaFinalGiro, ForceMode.Acceleration);
    }

    void GerenciarCamera()
    {
        // Move a câmera para perto do barco temporariamente
        if (cameraTransform.parent != transform)
        {
             cameraTransform.SetParent(transform);
        }

        Vector3 posicaoDesejada = transform.TransformPoint(offsetCamera);
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, posicaoDesejada, suavidadeCamera);
        cameraTransform.LookAt(transform.position + Vector3.up * 2f);
    }
}