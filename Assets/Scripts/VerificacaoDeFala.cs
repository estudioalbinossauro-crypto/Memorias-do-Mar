using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VerificacaoDeFala : MonoBehaviour
{
    [Header("compra")]
    [SerializeField] private GameObject painelCompra;
    [SerializeField] private Button SimCompra, NaoCompra;
    [SerializeField] private bool painelCompraNaCena = false;
    [SerializeField] private GameObject catalogoCompra;
    [Header("venda")]
    [SerializeField] private GameObject painelVenda;
    [SerializeField] private Button SimVenda, NaoVenda;
    [SerializeField] private bool painelVendaNaCena = false;
    [SerializeField] private GameObject catalogoVenda;


    void Start()
    {
        painelCompra.SetActive(false); // começa desativado
        painelVenda.SetActive(false);
        catalogoCompra.SetActive(false);
        catalogoVenda.SetActive(false);

    }

    void Update()
    {

    }
    private void destravaCamera()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    private void travaCamera()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FalaCompra"))
        {
            painelCompra.SetActive(true);  // ativa
            painelCompraNaCena = true;
            destravaCamera();         
        }

        if (other.CompareTag("FalaVenda"))
        {
            painelVenda.SetActive(true);   // ativa
            painelVendaNaCena = true;
            destravaCamera();
          
        }
    }
    void OnTriggerExit (Collider other)
   {
        if (other.CompareTag("FalaCompra"))
        {
            painelCompra.SetActive(false);  // ativa
            painelCompraNaCena = false;
            travaCamera();

        }

        if (other.CompareTag("FalaVenda"))
        {
            painelVenda.SetActive(false);   // ativa
            painelVendaNaCena = false;
            travaCamera();
           
        }
   }
    

    
}
