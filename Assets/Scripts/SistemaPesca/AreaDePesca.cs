using System;
using Unity.VisualScripting;
using UnityEngine;

public class AreaDePesca : MonoBehaviour
{
    [SerializeField] GameObject botaoQuerPescar;
    [SerializeField] GameObject miniGamePesca;

    [SerializeField] Transform canvasTransform;
    bool MiniTaSpawnado, fishingAreaEnter = false;
    public static bool jaRandomizou = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fishingAreaEnter = true;
            botaoQuerPescar.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fishingAreaEnter = false;
            botaoQuerPescar.SetActive(false);
        }
    }

    void Update()
    {
        if (MiniTaSpawnado == true && GerenciadorPesca.peixeTaFisgado == false)
        {
            miniGamePesca.SetActive(false);
        }

        FishingReady();

    }

    public void FishingReady()
    {
        if (fishingAreaEnter == true)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                miniGamePesca.SetActive(true);
                GerenciadorPesca.peixeTaFisgado = true;
                MiniTaSpawnado = true;
                if (jaRandomizou == false)
                {
                    GerenciadorPesca.ePraRandomizar = true;
                    jaRandomizou = true;
                }

            }
        }
    }
}
