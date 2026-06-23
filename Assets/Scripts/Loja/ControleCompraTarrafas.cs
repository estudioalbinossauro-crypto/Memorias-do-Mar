using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ControleCompraTarrafas : MonoBehaviour
{
   [Header("Valores")]
    [SerializeField] float valorTarrafaAtual;
    [SerializeField] float pila = 1000000;

    [Header("Molduras")]
    [SerializeField] Image molduraTarrafaIniciante;
    [SerializeField] Image molduraTarrafaMediana;
    [SerializeField] Image molduraTarrafaAvancada;
    [SerializeField] Image molduraTarrafaProfissional;
    [SerializeField] Image molduraTarrafaHeroica;
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
        valorTarrafaAtual = valor;
        selecaoAtiva = true;
        erroGeral.SetActive(false);
        saldoInsuficiente.SetActive(false);
    }
    public void ClickVaraIniciante() => SelecionarVara(molduraTarrafaIniciante, 100f);
    public void ClickVaraMediana() => SelecionarVara(molduraTarrafaMediana, 750f);
    public void ClickVaraAvancada() => SelecionarVara(molduraTarrafaAvancada, 1250f);
    public void ClickVaraProfissional() => SelecionarVara(molduraTarrafaProfissional, 3000f);
    public void ClickVaraHeroica() => SelecionarVara(molduraTarrafaHeroica, 8000f);
    public void Compra()
    {
        if (!selecaoAtiva)
        {
            erroGeral.SetActive(true);
            return;
        }
        if (selecionado == molduraTarrafaIniciante & CompradoIniciante == false)
        {
            if (pila >= valorTarrafaAtual)
            {
                pila -= valorTarrafaAtual;
                AtualizarTextoSaldo();
                VerificacaoCompraConcluida();
            }
        }
        if (selecionado == molduraTarrafaMediana & CompradoMediana == false)
        {
            if (pila >= valorTarrafaAtual)
            {
                pila -= valorTarrafaAtual;
                AtualizarTextoSaldo();
                VerificacaoCompraConcluida();
            }
        }
        if (selecionado == molduraTarrafaAvancada & CompradoAvancada == false)
        {
            if (pila >= valorTarrafaAtual)
            {
                pila -= valorTarrafaAtual;
                AtualizarTextoSaldo();
                VerificacaoCompraConcluida();
                Debug.Log("compra");
            }
        }
        if (selecionado == molduraTarrafaProfissional & CompradoProfissional == false)
        {
            if (pila >= valorTarrafaAtual)
            {
                pila -= valorTarrafaAtual;
                AtualizarTextoSaldo();
                VerificacaoCompraConcluida();
                Debug.Log("compra");
            }
        }
        if (selecionado == molduraTarrafaHeroica & CompradoHeroica == false)
        {
            if (pila >= valorTarrafaAtual)
            {
                pila -= valorTarrafaAtual;
                AtualizarTextoSaldo();
                VerificacaoCompraConcluida();
                Debug.Log("compra");
            }
        }
                else if (pila <= valorTarrafaAtual)
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
        if (selecionado == molduraTarrafaIniciante) { disponivelIniciante.text = "Comprado"; CompradoIniciante = true; }
        else if (selecionado == molduraTarrafaMediana) { disponivelMediana.text = "Comprado"; CompradoMediana = true; }
        else if (selecionado == molduraTarrafaAvancada) { disponivelAvancada.text = "Comprado"; CompradoAvancada = true; }
        else if (selecionado == molduraTarrafaProfissional) { disponivelProfissional.text = "Comprado"; CompradoProfissional = true; }
        else if (selecionado == molduraTarrafaHeroica) { disponivelHeroica.text = "Comprado"; CompradoHeroica = true; }
    }
    void DesativarTodasMolduras()
    {
        molduraTarrafaIniciante.enabled = false;
        molduraTarrafaMediana.enabled = false;
        molduraTarrafaAvancada.enabled = false;
        molduraTarrafaProfissional.enabled = false;
        molduraTarrafaHeroica.enabled = false;
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

