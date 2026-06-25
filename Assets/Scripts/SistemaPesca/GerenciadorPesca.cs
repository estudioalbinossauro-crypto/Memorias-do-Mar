using System.Collections;
using NUnit.Framework.Constraints;
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
    static public int randomizadorRaridade = 0;
    public string raridadeEscolhida;



    public int xpDoPlayer;



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
        //Seleção da raridade de acordo com o número gerado. OOOHHHH YEEAAAAHH BABYYY!!!!
        switch (randomizadorRaridade)
        {
            case int n when n == 0:
                //só para 0 nao ser igual a erro
                break;

            case int n when n >= 1 && n <= 500:
                raridadeEscolhida = "Comum";
                break;

            case int n when n > 500 && n <= 750:
                raridadeEscolhida = "Incomum";
                break;

            case int n when n > 750 && n <= 875:
                raridadeEscolhida = "Raro";
                break;

            case int n when n > 875 && n <= 950:
                raridadeEscolhida = "UltraRaro";
                break;

            case int n when n > 950 && n <= 975:
                Debug.Log("ficou entre 950 e 975");
                raridadeEscolhida = "Epico";
                break;

            case int n when n > 975 && n <= 990:
                Debug.Log("ficou entre 975 e 990");
                raridadeEscolhida = "Lendario";
                break;

            case int n when n > 990 && n <= 1000:
                Debug.Log("ficou entre 990 e 1000");
                raridadeEscolhida = "Mitico";
                break;

            default:
                Debug.Log("ERROOOO");
                break;
          //}
        }


        //Randomiza o Peixe de acordo com a raridade.
        if (ePraRandomizar == true)
        {
            if (raridadeEscolhida == "Comum")
            {
                randomizadorPeixe = Random.Range(1, 6);
                switch (randomizadorPeixe)
                {
                    case int n when n == 1:
                        peixeFisgado = "Tainha";
                        ePraRandomizar = false;
                        break;
                    case int n when n == 2:
                        peixeFisgado = "Bagre";
                        ePraRandomizar = false;
                        break;
                    case int n when n == 3:
                        peixeFisgado = "Anchova";
                        ePraRandomizar = false;
                        break;
                    case int n when n == 4:
                        peixeFisgado = "Baiacu";
                        ePraRandomizar = false;
                        break;
                    case int n when n == 5:
                        peixeFisgado = "Lambari";
                        ePraRandomizar = false;
                        break;

                    default:
                        Debug.Log("Erro");
                        break;
                        //}     
                }
            }
            else if (raridadeEscolhida == "Incomum")
            {
                randomizadorPeixe = Random.Range(1, 3);
                switch (randomizadorPeixe)
                {
                    case int n when n == 1:
                        peixeFisgado = "PeixeIncomum";
                        ePraRandomizar = false;
                        break;
                    case int n when n == 2:
                        peixeFisgado = "PeixeIncomum2";
                        ePraRandomizar = false;
                        break;
                    default:
                        Debug.Log("Erro");
                        break;
                        //}
                }
            }
            else if (raridadeEscolhida == "Raro")
            {
                randomizadorPeixe = Random.Range(1, 3);
                switch (randomizadorPeixe)
                {
                    case int n when n == 1:
                        peixeFisgado = "PeixeRaro";
                        ePraRandomizar = false;
                        break;
                    case int n when n == 2:
                        peixeFisgado = "PeixeRaro2";
                        ePraRandomizar = false;
                        break;
                    default:
                        Debug.Log("Erro");
                        break;
                        //}
                }
            }
            else if (raridadeEscolhida == "UltraRaro")
            {
                randomizadorPeixe = Random.Range(1, 3);
                switch (randomizadorPeixe)
                {
                    case int n when n == 1:
                        peixeFisgado = "PeixeUltraRaro";
                        ePraRandomizar = false;
                        break;
                    case int n when n == 2:
                        peixeFisgado = "PeixeUltraRaro2";
                        ePraRandomizar = false;
                        break;
                    default:
                        Debug.Log("Erro");
                        break;
                        //}
                }
            }
            else if (raridadeEscolhida == "Epico")
            {
                randomizadorPeixe = Random.Range(1, 3);
                switch (randomizadorPeixe)
                {
                    case int n when n == 1:
                        peixeFisgado = "PeixeEpico";
                        ePraRandomizar = false;
                        break;
                    case int n when n == 2:
                        peixeFisgado = "PeixeEpico2";
                        ePraRandomizar = false;
                        break;
                    default:
                        Debug.Log("Erro");
                        break;
                        //}
                }
            }
            else if (raridadeEscolhida == "Lendario")
            {
                randomizadorPeixe = Random.Range(1, 3);
                switch (randomizadorPeixe)
                {
                    case int n when n == 1:
                        peixeFisgado = "PeixeLendario";
                        ePraRandomizar = false;
                        break;
                    case int n when n == 2:
                        peixeFisgado = "PeixeLendario2";
                        ePraRandomizar = false;
                        break;
                    default:
                        Debug.Log("Erro");
                        break;
                        //}
                }
            }
            else if (raridadeEscolhida == "Mitico")
            {
                randomizadorPeixe = Random.Range(1, 3);
                switch (randomizadorPeixe)
                {
                    case int n when n == 1:
                        peixeFisgado = "PeixeMitico";
                        ePraRandomizar = false;
                        break;
                    case int n when n == 2:
                        peixeFisgado = "PeixeMitico2";
                        ePraRandomizar = false;
                        break;
                    default:
                        Debug.Log("Erro");
                        break;
                        //}
                }
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

        //Envia o peixe pescado pro inventario.
        if (peixeFisgado == "Tainha")
        {
            Inventario.peixesPescardos["Tainha"]++;
            peixeFisgado = null;
        }
        else if (peixeFisgado == "Bagre")
        {
            Inventario.peixesPescardos["Bagre"]++;
            peixeFisgado = null;
        }
        else if (peixeFisgado == "Anchova")
        {
            Inventario.peixesPescardos["Anchova"]++;
            peixeFisgado = null;
        }
        else if (peixeFisgado == "Baiacu")
        {
            Inventario.peixesPescardos["Baiacu"]++;
            peixeFisgado = null;
        }
        else if (peixeFisgado == "Lambari")
        {
            Inventario.peixesPescardos["Lambari"]++;
            peixeFisgado = null;
        }
        
    }
}
