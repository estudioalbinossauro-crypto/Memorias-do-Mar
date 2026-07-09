using Unity.Mathematics;
using UnityEngine;

public class Compras : MonoBehaviour
{
    [SerializeField] private GameObject painelCompras;
    [SerializeField] private GameObject painelVendas;
    [SerializeField] private GameObject painelLoja;
    private string painelAtual;

    void Update()
    {
        FecharPaineis();
    }
    void FecharPaineis()
    {
        if (AbreFechaLoja.fecharPaineis)
        {
            painelCompras.SetActive(false);
            painelVendas.SetActive(false);
            painelLoja.SetActive(false);
        }
    }
    public void PressCompras()
    {
        painelCompras.SetActive(true);
        painelVendas.SetActive(false);
        painelLoja.SetActive(false);

        painelAtual = "painelCompras";
    }
    public void PressVendas()
    {
        painelCompras.SetActive(false);
        painelVendas.SetActive(true);
        painelLoja.SetActive(false);

        painelAtual = "painelVendas";
    }
    public void Voltar()
    {
        switch (painelAtual)
        {
            case "painelCompras":
                painelCompras.SetActive(false);
                painelLoja.SetActive(true);
                painelAtual = null;
                break;

            case "painelVendas":
                painelVendas.SetActive(false);
                painelLoja.SetActive(true);
                painelAtual = null;
                break;

            default:
                painelVendas.SetActive(false);
                painelCompras.SetActive(false);
                painelLoja.SetActive(false);
                break;
        }
    }
}