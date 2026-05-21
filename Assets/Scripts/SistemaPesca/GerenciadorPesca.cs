using UnityEditor.ShaderGraph;
using UnityEngine;

public class GerenciadorPesca : MonoBehaviour
{
    [SerializeField] private GameObject barraDePesca;
    [SerializeField] private int fisgadasNecessarias = 3;
    public static bool barraAtiva;
    public static bool peixeTaFisgado;
    public static bool ePraRandomizar = false;



    public string peixeFisgado;
    private int randomizadorPeixe;



    [SerializeField] private int quantidadeDeFisgadas = 1;

    [SerializeField] private GameObject barraVerde;
    private RectTransform rt;
    private BoxCollider bC;

    bool TaNaVerde;

    void Start()
    {
        rt = barraVerde.GetComponent<RectTransform>();
        bC = barraVerde.GetComponent<BoxCollider>();
    }
    void Update()
    {
        
        EscolherPeixe();
        AveriguadorDeTaNaVerde();

        if (quantidadeDeFisgadas == 1)
        {
            rt.sizeDelta = new Vector2(100f, 100f);
            bC.size = new Vector2(100f, 150f);
            BarraDePesca.velocidadeDeMovimento = 300f;
        }
        else if (quantidadeDeFisgadas == 2)
        {
            rt.sizeDelta = new Vector2(70f, 100f);
            bC.size = new Vector2(70f, 150f);
            BarraDePesca.velocidadeDeMovimento = 450f;
        }
        else if (quantidadeDeFisgadas == 3)
        {
            rt.sizeDelta = new Vector2(30f, 100f);
            bC.size = new Vector2(30f, 150f);
            BarraDePesca.velocidadeDeMovimento = 550f;
        }
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("AreaVerde"))
        {
            TaNaVerde = true;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("AreaVerde"))
        {
            TaNaVerde = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("AreaVerde"))
        {
            TaNaVerde = false;
        }
    }


    void EscolherPeixe()
    {
        if (ePraRandomizar == true)
        {
            randomizadorPeixe = Random.Range(0, 2);
            if (randomizadorPeixe == 0)
            {
                peixeFisgado = "Tainha";
                ePraRandomizar = false;
            }
            else if (randomizadorPeixe == 1)
            {
                peixeFisgado = "Bagre";
                ePraRandomizar = false;
            }
        }
    }

    void AveriguadorDeTaNaVerde()
    {
        if (TaNaVerde == true)
        {
            ClicouNoVerde();
        }
    }

    void ClicouNoVerde()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            fisgadasNecessarias--;
            quantidadeDeFisgadas++;
            VerificadorDeFisgadas();
            Debug.Log("ClicouCerto");
            
        }
    }

    void VerificadorDeFisgadas()
    {
        if (fisgadasNecessarias <= 0)
        {

            ResetarFisgadas();
            PegouOPeixe();


        }
    }
    void ResetarFisgadas()
    {
        fisgadasNecessarias = 3;
    }

    void PegouOPeixe()
    {
        Debug.Log("Pegou o peixe " + peixeFisgado);
        quantidadeDeFisgadas = 1;
        peixeTaFisgado = false;
        AreaDePesca.jaRandomizou = false;
        if (peixeFisgado == "Tainha")
        {
            Inventario.peixesPescardos["Tainha"]++;
        }
        else if (peixeFisgado == "Bagre")
        {
            Inventario.peixesPescardos["Bagre"]++;
        }
        
    }
}
