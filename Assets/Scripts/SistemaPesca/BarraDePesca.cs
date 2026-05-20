using UnityEngine;

public class BarraDePesca : MonoBehaviour
{
[Header("Movimento da BarraAzul")]    
[SerializeField] private GameObject barraAzul;
[SerializeField] public static float velocidadeDeMovimento = 300f;

[Header("Caminho da BarraAzul")]
[SerializeField] private Transform[] pontosDoCaminho;
private int pontoAtual;



    void Start()
    {
        pontoAtual = 0;
        barraAzul.transform.position = pontosDoCaminho[pontoAtual].position;
    }

    void Update()
    {
        MovimentarBarraAzul();
    }

    private void MovimentarBarraAzul()
    {
        barraAzul.transform.position = Vector2.MoveTowards(barraAzul.transform.position, pontosDoCaminho[pontoAtual].position, velocidadeDeMovimento * Time.deltaTime);

        if(barraAzul.transform.position == pontosDoCaminho[pontoAtual].position)
        {
            pontoAtual += 1;
            if(pontoAtual >= pontosDoCaminho.Length)
            {
                pontoAtual = 0;
            }
        }
    }
}
