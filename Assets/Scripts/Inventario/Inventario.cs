using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public GameObject painelInventario;
    [SerializeField] TextMeshProUGUI textoInventario;
    [SerializeField] private bool invAberto;
    public static int numeroTainhas;
    public static int numeroBagres;

    void Start()
    {

    }
    void Update()
    {
        AbrirInventario();
        GeraTextoInventario();
    }
    void AbrirInventario()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            painelInventario.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            invAberto = true;
            Debug.Log("abriu");
        }
    }

    public void FecharInventario()
    {
        painelInventario.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        invAberto = false;
        Debug.Log("fechou");
    }

    void GeraTextoInventario()
    {
        if (numeroBagres == 0 && numeroTainhas == 0)
        {
            textoInventario.text = "Nenhum peixe no inventario";
        }
        else if (numeroBagres != 0 || numeroTainhas != 0)
        {
            textoInventario.text = numeroTainhas.ToString() + " : Tainhas Capturados /n " + numeroTainhas.ToString() + " : Tainhas Capturados";
        }
    }
    void PeixesPescados()
    {
        
    }
}