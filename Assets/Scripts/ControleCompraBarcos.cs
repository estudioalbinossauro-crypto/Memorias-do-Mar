using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ControleCompraBarcos : MonoBehaviour
{
   [Header("Valores")]
    [SerializeField] float valorBarcoAtual;
    [SerializeField] float pila = 1000000;

    [Header("Molduras")]
    [SerializeField] Image molduraCanoa;
    [SerializeField] Image molduraSaveiro;
    [SerializeField] Image molduraChalana;
    [SerializeField] Image molduraMarajo;
    [SerializeField] Image molduraApolusFishTracker;
    [SerializeField] Image molduraProFishing;
    [SerializeField] Image molduraTrawler;
    [SerializeField] Image molduraArrastaoDePesca;
    [SerializeField] Image molduraPesqueiro;
    [SerializeField] Image selecionado;
    [Header("Selecao")]
    [SerializeField] bool selecaoAtiva;
    [SerializeField] bool CompradoCanoa;
    [SerializeField] bool CompradoSaveiro;
    [SerializeField] bool CompradoChalana;
    [SerializeField] bool CompradoMarajo;
    [SerializeField] bool CompradoApolusFishTracker;
    [SerializeField] bool CompradoProFishing;
    [SerializeField] bool CompradoTrawler;
    [SerializeField] bool CompradoArrastaoDePesca;
    [SerializeField] bool CompradoPesqueiro;
    [Header("Erros")]
    [SerializeField] GameObject saldoInsuficiente;
    [SerializeField] GameObject erroGeral;
    [SerializeField] GameObject Indisponivel;
    [Header("Texto")]
    [SerializeField] TextMeshProUGUI textoPila;
    [SerializeField] TextMeshProUGUI disponivelCanoa;
    [SerializeField] TextMeshProUGUI disponivelSaveiro;
    [SerializeField] TextMeshProUGUI disponivelChalana;
    [SerializeField] TextMeshProUGUI disponivelMarajo;
    [SerializeField] TextMeshProUGUI disponivelApolusFishTracker;
    [SerializeField] TextMeshProUGUI disponivelProFishing;
    [SerializeField] TextMeshProUGUI disponivelTrawler;
    [SerializeField] TextMeshProUGUI disponivelArrastaoDePesca;
    [SerializeField] TextMeshProUGUI disponivelPesqueiro;
    void Start()
    {
        // Reset inicial
        erroGeral.SetActive(false);
        saldoInsuficiente.SetActive(false);
        Indisponivel.SetActive(false);
        DesativarTodasMolduras();
        AtualizarTextoSaldo();
        Disponivel();
    }
    private void SelecionarBarco(Image moldura, float valor)
    {
        DesativarTodasMolduras();
        moldura.enabled = true;
        selecionado = moldura;
        valorBarcoAtual = valor;
        selecaoAtiva = true;
        erroGeral.SetActive(false);
        saldoInsuficiente.SetActive(false);
    }
    public void ClickCanoa() => SelecionarBarco(molduraCanoa, 250f);
    public void ClickSaveiro() => SelecionarBarco(molduraSaveiro, 800f);
    public void ClickChalana() => SelecionarBarco(molduraChalana, 1300f);
    public void ClickMarajo() => SelecionarBarco(molduraMarajo, 3750f);
    public void ClickApolusFishTracker() => SelecionarBarco(molduraApolusFishTracker, 5000f);
    public void ClickProFishing() => SelecionarBarco(molduraProFishing, 7000f);
    public void ClickTrawler() => SelecionarBarco(molduraTrawler, 11000f);
    public void ClickArrastaoDePesca() => SelecionarBarco(molduraArrastaoDePesca, 17000f);
    public void ClickPesqueiro() => SelecionarBarco(molduraPesqueiro, 20000f);
    public void Compra()
    {
        if (!selecaoAtiva)
        {
            erroGeral.SetActive(true);
            return;
        }
        if (selecionado == molduraCanoa & CompradoCanoa == false)
        {
            if (pila >= valorBarcoAtual)
            {
                pila -= valorBarcoAtual;
                AtualizarTextoSaldo();
                VerificacaoCompraConcluida();
            }
        }
        if (selecionado == molduraSaveiro & CompradoSaveiro == false)
        {
            if (pila >= valorBarcoAtual)
            {
                pila -= valorBarcoAtual;
                AtualizarTextoSaldo();
                VerificacaoCompraConcluida();
            }
        }
        if (selecionado == molduraChalana & CompradoChalana == false)
        {
            if (pila >= valorBarcoAtual)
            {
                pila -= valorBarcoAtual;
                AtualizarTextoSaldo();
                VerificacaoCompraConcluida();
                Debug.Log("compra");
            }
        }
        if (selecionado == molduraMarajo & CompradoMarajo == false)
        {
            if (pila >= valorBarcoAtual)
            {
                pila -= valorBarcoAtual;
                AtualizarTextoSaldo();
                VerificacaoCompraConcluida();
                Debug.Log("compra");
            }
        }
        if (selecionado == molduraApolusFishTracker & CompradoApolusFishTracker == false)
        {
            if (pila >= valorBarcoAtual)
            {
                pila -= valorBarcoAtual;
                AtualizarTextoSaldo();
                VerificacaoCompraConcluida();
                Debug.Log("compra");
            }
        }
        if (selecionado == molduraProFishing & CompradoProFishing == false)
        {
            if (pila >= valorBarcoAtual)
            {
                pila -= valorBarcoAtual;
                AtualizarTextoSaldo();
                VerificacaoCompraConcluida();
                Debug.Log("compra");
            }
        }
        if (selecionado == molduraTrawler & CompradoTrawler == false)
        {
            if (pila >= valorBarcoAtual)
            {
                pila -= valorBarcoAtual;
                AtualizarTextoSaldo();
                VerificacaoCompraConcluida();
                Debug.Log("compra");
            }
        }
        if (selecionado == molduraArrastaoDePesca & CompradoArrastaoDePesca == false)
        {
            if (pila >= valorBarcoAtual)
            {
                pila -= valorBarcoAtual;
                AtualizarTextoSaldo();
                VerificacaoCompraConcluida();
                Debug.Log("compra");
            }
        }
        if (selecionado == molduraPesqueiro & CompradoPesqueiro == false)
        {
            if (pila >= valorBarcoAtual)
            {
                pila -= valorBarcoAtual;
                AtualizarTextoSaldo();
                VerificacaoCompraConcluida();
                Debug.Log("compra");
            }
        }
                else if (pila <= valorBarcoAtual)
                {
                    saldoInsuficiente.SetActive(true);
                }
                        else
                        {
                            Indisponivel.SetActive(true);
                        }
    }
    void AtualizarTextoSaldo()
    {
        textoPila.text = $"Pila: {pila:N0}";
    }
    void VerificacaoCompraConcluida()
    {
        if (selecionado == molduraCanoa) { disponivelCanoa.text = "Comprado"; CompradoCanoa = true; }
        else if (selecionado == molduraSaveiro) { disponivelSaveiro.text = "Comprado"; CompradoSaveiro = true; }
        else if (selecionado == molduraChalana) { disponivelChalana.text = "Comprado"; CompradoChalana = true; }
        else if (selecionado == molduraMarajo) { disponivelMarajo.text = "Comprado"; CompradoMarajo = true; }
        else if (selecionado == molduraApolusFishTracker) { disponivelApolusFishTracker.text = "Comprado"; CompradoApolusFishTracker = true; }
        else if (selecionado == molduraProFishing) { disponivelProFishing.text = "comprado"; CompradoProFishing = true; }
        else if (selecionado == molduraTrawler) { disponivelTrawler.text = "comprado"; CompradoTrawler = true; }
        else if (selecionado == molduraArrastaoDePesca) { disponivelArrastaoDePesca.text = "comprado"; CompradoArrastaoDePesca = true; }
        else if (selecionado == molduraPesqueiro) { disponivelPesqueiro.text = "comprado"; CompradoPesqueiro = true; }
        
    }
    void DesativarTodasMolduras()
    {
        molduraCanoa.enabled = false;
        molduraSaveiro.enabled = false;
        molduraChalana.enabled = false;
        molduraMarajo.enabled = false;
        molduraApolusFishTracker.enabled = false;
        molduraProFishing.enabled = false;
        molduraTrawler.enabled = false;
        molduraArrastaoDePesca.enabled = false;
        molduraPesqueiro.enabled = false;
    }
    void Disponivel()
    {
        CompradoCanoa = false;
        CompradoSaveiro = false;
        CompradoChalana = false;
        CompradoMarajo = false;
        CompradoApolusFishTracker = false;
        CompradoProFishing = false;
        CompradoTrawler = false;
        CompradoArrastaoDePesca = false;
        CompradoPesqueiro = false;
    }

}

