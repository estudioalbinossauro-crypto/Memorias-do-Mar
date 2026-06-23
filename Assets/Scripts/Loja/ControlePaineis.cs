using UnityEngine;
public class ControlePaineis : MonoBehaviour
{
    [Header("compra")]
    [SerializeField] private GameObject PainelCompra;
    [SerializeField] private GameObject CatalogoCompraVaras;
    [SerializeField] GameObject CatalogoCompraTarrafas;
    [SerializeField] GameObject CatalogoCompraBarcos;
    [Header("venda")]
    [SerializeField] private GameObject PainelVenda;
    [SerializeField] private GameObject CatalogoVenda;
    [Header("Erros")]
    [SerializeField] GameObject erro;
    [SerializeField] GameObject SaldoInsuficiente;
    [SerializeField] GameObject Indisponivel;
    void Start()
    {
        CatalogoCompraTarrafas.SetActive(false);
    }
    private void destravaCamera()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    private void travaCamera()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void DesativarPainelVenda()
    {
        PainelVenda.SetActive(false);
    }
    public void DesativarPainelCompra()
    {
        PainelCompra.SetActive(false);
    }
    public void AtivarCatalgoCompra()
    {
        destravaCamera();
        CatalogoCompraVaras.SetActive(true);
        PainelCompra.SetActive(false);
    }
    public void AtivarCatalgoVenda()
    {
        CatalogoVenda.SetActive(true);
        PainelVenda.SetActive(false);
    }
    public void FecharCatalogoCompraTarrafas()
    {
        CatalogoCompraTarrafas.SetActive(false);
    }
    public void FecharCatalogoVenda()
    {
        CatalogoVenda.SetActive(false);
        travaCamera();
    }
    public void FecharErro()
    {
        erro.SetActive(false);
    }
    public void FecharSaldoInsuficiente()
    {
        SaldoInsuficiente.SetActive(false);
    }
    public void FecharIndisponivel()
    {
        Indisponivel.SetActive(false);
    }
    public void TrocarParaTarrafas()
    {
        destravaCamera();
        CatalogoCompraTarrafas.SetActive(true);
        CatalogoCompraVaras.SetActive(false);
        CatalogoCompraBarcos.SetActive(false);
    }
    public void TrocarParaVaras()
    {
        destravaCamera();
        CatalogoCompraTarrafas.SetActive(false);
        CatalogoCompraVaras.SetActive(true);
        CatalogoCompraBarcos.SetActive(false);
    }
    public void FecharCatalogoCompraVaras()
    {
        CatalogoCompraVaras.SetActive(false);
        travaCamera();
    }
    public void TrocarParaBarcos()
    {
        destravaCamera();
        CatalogoCompraBarcos.SetActive(true);
        CatalogoCompraTarrafas.SetActive(false);
        CatalogoCompraVaras.SetActive(false);
    }
    public void FecharCatalogoCompraBarcos()
    {
        travaCamera();
        CatalogoCompraBarcos.SetActive(false);
    }
}
