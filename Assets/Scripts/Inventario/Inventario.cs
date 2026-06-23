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

    // Dicionário estático: armazena o [Nome do Peixe] e a [Quantidade]
    // Outros scripts podem acessar isso diretamente!
    public static Dictionary<string, int> peixesPescardos = new Dictionary<string, int>()
    {
        { "Tainha", 0 },
        { "Bagre", 0 },
        { "Anchova", 0 },
        { "Baiacu", 0 },
        { "Lambari", 0 } // Para adicionar mais peixes, basta listar aqui!
    };

    void Start()
    {
        // Garante que o inventário comece fechado
        painelInventario.SetActive(false);
        invAberto = false;
    }

    void Update()
    {
        GerenciarInputInventario();
        
        // Otimização: Só atualiza o texto se o inventário de fato estiver aberto!
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

        // Passa por cada peixe registrado no dicionário
        foreach (KeyValuePair<string, int> peixe in peixesPescardos)
        {
            if (peixe.Value > 0)
            {
                sb.AppendLine($"{peixe.Value} {peixe.Key}(s) capturado(s)");
                totalPeixes += peixe.Value;
            }
        }

        // Se após varrer o dicionário nenhum peixe foi encontrado
        if (totalPeixes == 0)
            textoInventario.text = "Nenhum peixe no inventário.";
        else
            textoInventario.text = sb.ToString().TrimEnd();
    }
}