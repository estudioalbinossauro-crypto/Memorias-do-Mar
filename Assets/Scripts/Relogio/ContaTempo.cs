using UnityEngine;
using System.Collections;
using TMPro;

public class ContaTempo : MonoBehaviour
{
    [SerializeField]private int segundos;
    [SerializeField]private int minutos;
    [SerializeField]private int duraçãoDias;
    [SerializeField]private int dias;
    [SerializeField]private string estacao;
    [SerializeField]private int ordemEstacao = 1;
    [SerializeField]public TextMeshProUGUI relogio; 
    [SerializeField]public TextMeshProUGUI calendario;
    [SerializeField]public TextMeshProUGUI contadorEstacao;

    void Start()
    {
        Estacoes();
        StartCoroutine(SomarSegundo());
    }
    void Update()
    {
        Estacoes();
        Debug.Log(estacao);
    }
    IEnumerator SomarSegundo()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            segundos++;

            if (segundos >= 60)
            {
                AumentaMinutos();
            }
            if(minutos >= duraçãoDias)
            {
                dias++;
                segundos = 0;
                minutos = 0;
            }
            AtualizarCalendarioUI();
            AtualizarRelogioUI();
        }
    }
    void AumentaMinutos()
    {
        segundos = 0;
        minutos++;
    }
    void AtualizarRelogioUI()
    {
        // Formata para 00:00 (D2 força dois dígitos)
        relogio.text = minutos.ToString("D2") + ":" + segundos.ToString("D2");
    }
    void AtualizarCalendarioUI()
    {
        // Formata para 00:00 (D2 força dois dígitos)
        calendario.text = "Dias : " + dias.ToString("D2");
    }
    void Estacoes()
    {
        contadorEstacao.text ="Estação / " + estacao;
        if(dias >= 10)
        {
            ordemEstacao++;
            dias = 0;
        }

        //Mudança de estações

        if(estacao == null || ordemEstacao == 1)
        {
            estacao = "Primavera";
        }
        else if(ordemEstacao == 2)
        {
            estacao = "Verao";
        }
        else if(ordemEstacao == 3)
        {
            estacao = "Outono";
        }
        else if(ordemEstacao == 4)
        {
            estacao = "Inverno";
        }
        if(ordemEstacao >= 5){ordemEstacao = 1;}
    }
}
