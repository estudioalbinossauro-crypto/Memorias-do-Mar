using UnityEngine;

public class TamanhoAreaVerde : MonoBehaviour
{
    [SerializeField] private GameObject barraVerde;
   

    private RectTransform rt;
    private BoxCollider bC;

    void Start()
    {
        rt = barraVerde.GetComponent<RectTransform>();
        bC = barraVerde.GetComponent<BoxCollider>();
    }

    void Update()
    {
        //if (GerenciadorPesca.quantidadeDeFisgadas == 1)
        //{
        //    rt.sizeDelta = new Vector2(100f, 100f);
        //    bC.size = new Vector2(100f, 150f);
        //}
        //else if (GerenciadorPesca.quantidadeDeFisgadas == 2)
        //{
        //    rt.sizeDelta = new Vector2(70f, 100f);
        //    bC.size = new Vector2(70f, 150f);
        //}
       // else if (GerenciadorPesca.quantidadeDeFisgadas == 3)
        //{
        //    rt.sizeDelta = new Vector2(30f, 100f);
        //    bC.size = new Vector2(30f, 150f);
        //}
        
    }
}
