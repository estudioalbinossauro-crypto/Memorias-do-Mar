using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ControleCompraVara : MonoBehaviour
{
    [Header("Valores")]
    [SerializeField] float valorVaraAtual;
    [SerializeField] float pila = 1000000;

    [Header("Molduras")]
    [SerializeField] Image molduraVaraIniciante;
    [SerializeField] Image molduraVaraMediana;
    [SerializeField] Image molduraVaraAvancada;
    [SerializeField] Image molduraVaraProfissional;
    [SerializeField] Image molduraVaraHeroica;
    [SerializeField] Image selecionado;
    [Header("Selecao")]
    [SerializeField] bool selecaoAtiva;
    [SerializeField] bool CompradoIniciante;
    [SerializeField] bool CompradoMediana;
    [SerializeField] bool CompradoAvancada;
    [SerializeField] bool CompradoProfissional;
    [SerializeField] bool CompradoHeroica;
    [Header("Erros")]
    [SerializeField] GameObject saldoInsuficiente;
    [SerializeField] GameObject erroGeral;
    [SerializeField] GameObject Indisponivel;
    [Header("Texto")]
    [SerializeField] TextMeshProUGUI textoPila;
    [SerializeField] TextMeshProUGUI disponivelIniciante;
    [SerializeField] TextMeshProUGUI disponivelMediana;
    [SerializeField] TextMeshProUGUI disponivelAvancada;
    [SerializeField] TextMeshProUGUI disponivelProfissional;
    [SerializeField] TextMeshProUGUI disponivelHeroica;
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
    // Centraliza a lógica de seleção para evitar repetição
    private void SelecionarVara(Image moldura, float valor)
    {
        DesativarTodasMolduras();
        moldura.enabled = true;
        selecionado = moldura;
        valorVaraAtual = valor;
        selecaoAtiva = true;
        erroGeral.SetActive(false);
        saldoInsuficiente.SetActive(false);
    }
    public void ClickVaraIniciante() => SelecionarVara(molduraVaraIniciante, 200f);
    public void ClickVaraMediana() => SelecionarVara(molduraVaraMediana, 600f);
    public void ClickVaraAvancada() => SelecionarVara(molduraVaraAvancada, 1000f);
    public void ClickVaraProfissional() => SelecionarVara(molduraVaraProfissional, 2500f);
    public void ClickVaraHeroica() => SelecionarVara(molduraVaraHeroica, 6500f);
    public void Compra()
    {
        if (!selecaoAtiva)
        {
            erroGeral.SetActive(true);
            return;
        }
        if (selecionado == molduraVaraIniciante & CompradoIniciante == false)
        {
            if (pila >= valorVaraAtual)
            {
                pila -= valorVaraAtual;
                AtualizarTextoSaldo();
                VerificacaoCompraConcluida();
            }
        }
        if (selecionado == molduraVaraMediana & CompradoMediana == false)
        {
            if (pila >= valorVaraAtual)
            {
                pila -= valorVaraAtual;
                AtualizarTextoSaldo();
                VerificacaoCompraConcluida();
            }
        }
        if (selecionado == molduraVaraAvancada & CompradoAvancada == false)
        {
            if (pila >= valorVaraAtual)
            {
                pila -= valorVaraAtual;
                AtualizarTextoSaldo();
                VerificacaoCompraConcluida();
                Debug.Log("compra");
            }
        }
        if (selecionado == molduraVaraProfissional & CompradoProfissional == false)
        {
            if (pila >= valorVaraAtual)
            {
                pila -= valorVaraAtual;
                AtualizarTextoSaldo();
                VerificacaoCompraConcluida();
                Debug.Log("compra");
            }
        }
        if (selecionado == molduraVaraHeroica & CompradoHeroica == false)
        {
            if (pila >= valorVaraAtual)
            {
                pila -= valorVaraAtual;
                AtualizarTextoSaldo();
                VerificacaoCompraConcluida();
                Debug.Log("compra");
            }
        }
                else if (pila <= valorVaraAtual)
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
        if (selecionado == molduraVaraIniciante) { disponivelIniciante.text = "Comprado"; CompradoIniciante = true; }
        else if (selecionado == molduraVaraMediana) { disponivelMediana.text = "Comprado"; CompradoMediana = true; }
        else if (selecionado == molduraVaraAvancada) { disponivelAvancada.text = "Comprado"; CompradoAvancada = true; }
        else if (selecionado == molduraVaraProfissional) { disponivelProfissional.text = "Comprado"; CompradoProfissional = true; }
        else if (selecionado == molduraVaraHeroica) { disponivelHeroica.text = "Comprado"; CompradoHeroica = true; }
    }
    void DesativarTodasMolduras()
    {
        molduraVaraIniciante.enabled = false;
        molduraVaraMediana.enabled = false;
        molduraVaraAvancada.enabled = false;
        molduraVaraProfissional.enabled = false;
        molduraVaraHeroica.enabled = false;
    }
    void Disponivel()
    {
        CompradoIniciante = false;
        CompradoMediana = false;
        CompradoAvancada = false;
        CompradoProfissional = false;
        CompradoHeroica = false;
    }
}