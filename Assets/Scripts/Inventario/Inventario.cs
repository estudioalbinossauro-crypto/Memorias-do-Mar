using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    [Header("Configurações de UI")]
    public GameObject painelInventario;
    [SerializeField] private TextMeshProUGUI textoInventario;
    [SerializeField] private bool invAberto;

    
    public static Dictionary<string, int> peixesPescarlos = new Dictionary<string, int>()
    {
        { "Tainha", 0 },
        { "Bagre", 0 },
        { "Anchova", 0 },
        { "Baiacu", 0 },
        { "Lambari", 0 } 
    };

    void Start()
    {
        
        painelInventario.SetActive(false);
        invAberto = false;
    }

    void Update()
    {
        GerenciarInputInventario();
        
        
        if (invAberto)
        {
            GeraTextoInventario();
        }
    }

    void GerenciarInputInventario()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!invAberto)
            {
                AbrirInventario();
            }
            else
            {
                FecharInventario();
            }
        }
    }

    void AbrirInventario()
    {
        painelInventario.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        invAberto = true;
        Debug.Log("Inventário Aberto");
    }

    public void FecharInventario()
    {
        painelInventario.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        invAberto = false;
        Debug.Log("Inventário Fechado");
    }

    void GeraTextoInventario()
    {
        StringBuilder sb = new StringBuilder();
        int totalPeixes = 0;


        foreach (KeyValuePair<string, int> peixe in peixesPescarlos)
        {
            if (peixe.Value > 0)
            {
                sb.AppendLine($"{peixe.Value} {peixe.Key}(s) capturado(s)");
                totalPeixes += peixe.Value;
            }
        }


        if (totalPeixes == 0)
        {
            textoInventario.text = "Nenhum peixe no inventário.";
        }
        else
        {
            textoInventario.text = sb.ToString().TrimEnd();
        }
    }
}