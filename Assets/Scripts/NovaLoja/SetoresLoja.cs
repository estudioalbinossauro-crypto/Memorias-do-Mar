using UnityEngine;

public class SetoresLoja : MonoBehaviour
{
    [Header("Painéis Principais")]
    [SerializeField] GameObject painelSetores;
    [SerializeField] GameObject SetorBarcos;
    [SerializeField] GameObject SetorVaras;
    [SerializeField] GameObject SetorTarrafas;

    void Update()
    {
        FecharPaineis();
    }
    void FecharPaineis()
    {
        if (AbreFechaLoja.fecharPaineis)
        {
            painelSetores.SetActive(false);
            SetorBarcos.SetActive(false);
            SetorVaras.SetActive(false);
            SetorTarrafas.SetActive(false);
        }
    }
    public void PressBarcos()
    {
        PrepararAbertura();
        SelecionarSetor("Barcos");
    }
    public void PressVaras()
    {
        PrepararAbertura();
        SelecionarSetor("Varas");
    }
    public void PressTarrafas()
    {
        PrepararAbertura();
        SelecionarSetor("Tarrafas");
    }
    public void Voltar()
    {
        SetorBarcos.SetActive(false);
        SetorVaras.SetActive(false);
        SetorTarrafas.SetActive(false);

        painelSetores.SetActive(true);
    }
    private void PrepararAbertura()
    {
        AbreFechaLoja.fecharPaineis = false; 
        
        painelSetores.SetActive(false);
    }
    void SelecionarSetor(string setor)
    {
        SetorBarcos.SetActive(setor == "Barcos");
        SetorVaras.SetActive(setor == "Varas");
        SetorTarrafas.SetActive(setor == "Tarrafas");
    }
}