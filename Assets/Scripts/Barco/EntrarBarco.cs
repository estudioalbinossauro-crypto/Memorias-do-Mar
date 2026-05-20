using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [Header("Configurações")]
    [SerializeField] private float range = 3f;
    
    [Header("Referências de Câmera")]
    [SerializeField] private Camera camPrincipal; // Arraste a Main Camera aqui
    [SerializeField] private Transform pontoCameraPlayer; // Objeto vazio no 'rosto' do player

    private BarcoController barcoAtual;
    private bool estaNoBarco = false;

    // Cache de componentes do Player
    private MovPlayer scriptMovPlayer;
    private MonoBehaviour scriptTravaCamera;
    private Rigidbody playerRb;

    void Awake()
    {
        scriptMovPlayer = GetComponent<MovPlayer>();
        scriptTravaCamera = GetComponentInChildren<TravaCamera>();
        playerRb = GetComponent<Rigidbody>();

        // Se não arrastou as câmeras no inspetor, tenta achar automaticamente
        if (camPrincipal == null) camPrincipal = Camera.main;
        if (pontoCameraPlayer == null) pontoCameraPlayer = transform.Find("PontoCameraFPS"); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            VerificarEEntrar();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (estaNoBarco) SairDoBarco();
        }
    }
   void VerificarEEntrar()
    {
        // Criamos o raio a partir do centro da tela
        Ray ray = camPrincipal.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        // Debug para você ver o raio no modo Scene (ajuda a saber se está alcançando)
        Debug.DrawRay(ray.origin, ray.direction * range, Color.red);

        if (Physics.Raycast(ray, out hit, range))
        {
            Debug.Log("Acertou objeto: " + hit.collider.name + " com tag: " + hit.collider.tag);

            if (hit.collider.CompareTag("Pilotar"))
            {
                // Tenta pegar o script no objeto que acertou ou nos pais dele
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
        
        scriptMovPlayer.enabled = false;
        if (scriptTravaCamera != null) scriptTravaCamera.enabled = false;

        playerRb.isKinematic = true;
        transform.SetParent(assento);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        // --- Gerenciamento da Câmera ao Entrar ---
        // Desativamos a renderização da câmera FPS porque o barco tem sua própria lógica
        if (camPrincipal != null) camPrincipal.enabled = false; 

        barcoAtual.enabled = true; // Ativa controle e câmera do barco
    }
    void SairDoBarco()
    {
        estaNoBarco = true; // Mantemos true temporariamente para evitar re-entrada imediata
        transform.SetParent(null);

        if (barcoAtual != null) barcoAtual.enabled = false; // Para motor e câmera suave

        playerRb.isKinematic = false;
        scriptMovPlayer.enabled = true;
        
        // --- Gerenciamento da Câmera ao Sair ---
        if (camPrincipal != null && pontoCameraPlayer != null)
        {
            // Volta a Câmera Principal para o Player
            camPrincipal.transform.SetParent(pontoCameraPlayer);
            camPrincipal.transform.localPosition = Vector3.zero;
            camPrincipal.transform.localRotation = Quaternion.identity;

            // Reativa a Câmera e o script de rotação do mouse (FPS)
            camPrincipal.enabled = true;
        }

        if (scriptTravaCamera != null) scriptTravaCamera.enabled = true;
        
        barcoAtual = null;
        estaNoBarco = false; // Agora sim, saiu totalmente
    }
}