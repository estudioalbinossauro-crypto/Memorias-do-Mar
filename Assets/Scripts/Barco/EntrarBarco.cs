using UnityEngine;
 
public class PlayerRaycast : MonoBehaviour
{
    [Header("Configurações")]
    [SerializeField] private float range = 3f;
 
    [Header("Referências de Câmera")]
    [SerializeField] private Camera camPrincipal;
    [SerializeField] private Transform pontoCameraPlayer;
 
    private BarcoController barcoAtual;
    private bool estaNoBarco = false;
    [SerializeField] Collider playerCollider;
 
    // Cache de componentes do Player
    private MovPlayer scriptMovPlayer;
    private MonoBehaviour scriptTravaCamera;
    private Rigidbody playerRb;
 
    void Awake()
    {
        scriptMovPlayer = GetComponent<MovPlayer>();
        scriptTravaCamera = GetComponentInChildren<TravaCamera>();
        playerRb = GetComponent<Rigidbody>();
        if (playerCollider == null) playerCollider = GetComponent<Collider>();
 
        if (camPrincipal == null) camPrincipal = Camera.main;
        if (pontoCameraPlayer == null) pontoCameraPlayer = transform.Find("PontoCameraFPS");
    }
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !estaNoBarco)
        {
            VerificarEEntrar();
        }
        if (Input.GetKeyDown(KeyCode.Q) && estaNoBarco)
        {
            SairDoBarco();
            transform.rotation = Quaternion.identity;        }
    }
 
    void VerificarEEntrar()
    {
        Ray ray = camPrincipal.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
 
        Debug.DrawRay(ray.origin, ray.direction * range, Color.red);
 
        if (Physics.Raycast(ray, out hit, range))
        {
            Debug.Log("Acertou objeto: " + hit.collider.name + " com tag: " + hit.collider.tag);
 
            if (hit.collider.CompareTag("Pilotar"))
            {
                barcoAtual = hit.collider.GetComponentInParent<BarcoController>();
 
                if (barcoAtual != null)
                {
                    EntrarNoBarco(hit.collider.transform);
                }
                else
                {
                    Debug.LogError("Objeto com tag 'Pilotar' encontrado, mas BarcoController não está no objeto ou nos pais!");
                }
            }
        }
    }
 
    void EntrarNoBarco(Transform assento)
    {
        estaNoBarco = true;
        playerCollider.enabled = false;
 
        scriptMovPlayer.enabled = false;
        if (scriptTravaCamera != null) scriptTravaCamera.enabled = false;
 
        playerRb.isKinematic = true;
        transform.SetParent(assento);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
 
        if (camPrincipal != null && barcoAtual.PontoCameraBarco != null)
        {
            camPrincipal.transform.SetParent(barcoAtual.PontoCameraBarco);
            camPrincipal.transform.localPosition = Vector3.zero;
            camPrincipal.transform.localRotation = Quaternion.identity;
            camPrincipal.enabled = true;
        }
 
        barcoAtual.enabled = true;
        barcoAtual.ResetarCenterOfMass(); // Garante CoM no centro após parenting
    }
 
    void SairDoBarco()
    {
        if (barcoAtual.PontoSaida != null)
            transform.position = barcoAtual.PontoSaida.position;
 
        transform.SetParent(null);
 
        if (barcoAtual != null)
        {
            barcoAtual.ResetarCenterOfMass(); // Reseta CoM ao remover o player como filho
            barcoAtual.enabled = false;
        }
 
        playerRb.isKinematic = false;
        scriptMovPlayer.enabled = true;
 
        if (camPrincipal != null && pontoCameraPlayer != null)
        {
            camPrincipal.transform.SetParent(pontoCameraPlayer);
            camPrincipal.transform.localPosition = Vector3.zero;
            camPrincipal.transform.localRotation = Quaternion.identity;
            camPrincipal.enabled = true;
        }
 
        if (scriptTravaCamera != null) scriptTravaCamera.enabled = true;
 
        barcoAtual = null;
        estaNoBarco = false;
        playerCollider.enabled = true;
    }
}