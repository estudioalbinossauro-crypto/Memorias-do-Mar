using UnityEngine;

public class AbreFechaLoja : MonoBehaviour
{
    bool estaNoBalcao = false;
    bool lojaAberta = false;
    [SerializeField] TravaCamera travaCamera;
    [SerializeField] GameObject loja;
    [SerializeField] GameObject botaoInteracao;
    [SerializeField] GameObject PainelCompras;
    [SerializeField] GameObject PainelVendas;
    [SerializeField] GameObject PresetComplaVendas;
    public static bool fecharPaineis = false;
    

    void Update()
    {
        AtualizarBotaoInteracao();
        LojaAbre();
        LojaFecha();
    }
    void AtualizarBotaoInteracao()
    {
        botaoInteracao.SetActive(estaNoBalcao && !lojaAberta);
    }
    void LojaAbre()
    {
        if (estaNoBalcao && !lojaAberta && Input.GetKeyDown(KeyCode.E))
        {
            lojaAberta = true;
            fecharPaineis = false;
            loja.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            travaCamera.enabled = false;
            PresetComplaVendas.SetActive(true);
        }
    }
    void LojaFecha()
    {
        if (lojaAberta && Input.GetKeyDown(KeyCode.Escape))
        {
            FecharLoja();
            fecharPaineis = true;
        }
    }
    void FecharLoja()
    {
        lojaAberta = false;
        loja.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        travaCamera.enabled = true;

        PainelCompras.SetActive(false);
        PainelVendas.SetActive(false);
        

    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collidiu com Trigger: " + other.gameObject.tag);
        if (other.gameObject.CompareTag("Balcao"))
        {
            estaNoBalcao = true;
        }
    }
    void OnTriggerExit(Collider other)    
    {
        if (other.gameObject.CompareTag("Balcao"))
        {
            estaNoBalcao = false;
            if (lojaAberta)
            {
                FecharLoja();
                fecharPaineis = true;
            }
        }
    }
}