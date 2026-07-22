using UnityEditor.VersionControl;
using UnityEngine;
using System.Collections.Generic;

public class VendaPeixes : MonoBehaviour
{

    private int precoTainha = 2, precoBagre = 1, precoAnchova = 3, precoLambari;

    void Start()
    {

    }


    void Update()
    {

    }

    public void BotaoVenderTudo()
    {
        foreach (KeyValuePair<string, int> peixe in Inventario.peixesPescarlos)
        {
            if (peixe.Key == "Tainha")
            {
                
            }
        }
    }
}
