using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TableroMinigame : MonoBehaviour
{
    //public Collider2D redc, orangec, greenc;
    public GameObject orange, green;
    public Slider barra;
    public Text points;

    public int puntos = 0,pred,porange,pgreen;
    public int i;
    public bool subir=true;
    public InputAction stop;
    public Vector3 pivoteee;
    public float velocity;
    RayCastColor raya;


    //Imagenes y cambio fondo
    public GameObject good,meh,bad,background;
    public int distancia;

    //Listas
    public List<string> tops = new List<string> { "batman", "castillo", "loro" };
    public List<string> mids = new List<string> { "smile", "hoja", "culo" };
    public List<string> lows = new List<string> { "randomuno", "randomdos", "randomtres" };

    public string toprandom, midrandom,lowrandom;
    public GameObject XINXETA;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //LineMove();
        raya = FindObjectOfType<RayCastColor>();
        pivoteee = green.transform.position;
        RandomValues();
        StartCoroutine(Moving());
        stop.Enable();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stop.triggered)
        {
            print("El valor es " + raya.valorcolor);
            if (raya.valorcolor == 0)
            {

                bad.gameObject.SetActive(true);
                bad.transform.SetParent(background.transform);
                lows.Remove(lowrandom);
                puntos = puntos + pred;

            }
            else if (raya.valorcolor == 1)
            {
                meh.gameObject.SetActive(true);
                meh.transform.SetParent(background.transform);
                mids.Remove(midrandom);
                puntos = puntos + porange;
                print("No está mal");
            }
            else if (raya.valorcolor==2)
            {
                
                good.gameObject.SetActive(true);
                good.transform.SetParent(background.transform);
                tops.Remove(toprandom);
                puntos = puntos + pgreen;

            }
            points.text = puntos.ToString();
            StopAllCoroutines();
            stop.Disable();
            StartCoroutine(TimeOut());
        }
    }
    public void RandomValues()
    {
       
        XINXETA.SetActive(true);
        RectTransform olarg = orange.GetComponent<RectTransform>();
        BoxCollider2D ocol = orange.GetComponent<BoxCollider2D>();

        olarg.sizeDelta = new Vector2(Random.Range(150, 300), 58.3804f);
        ocol.size = olarg.sizeDelta;

        RectTransform glarg = green.GetComponent<RectTransform>();
        BoxCollider2D gcol = green.GetComponent<BoxCollider2D>();
        glarg.sizeDelta = new Vector2(Random.Range(5, 95), 58.3804f);
        gcol.size = glarg.sizeDelta;

        Vector3 cambio_green_orange = pivoteee + new Vector3(Random.Range(-300, 300), 0, 0);
        green.transform.position = cambio_green_orange;
        orange.transform.position = cambio_green_orange;

        //Chinchetas
        int indRandomone = Random.Range(0, tops.Count);
        int indRandomtwo = Random.Range(0, mids.Count);
        int indRandomthree = Random.Range(0, lows.Count);

        toprandom = tops[indRandomone];
        midrandom = mids[indRandomtwo];
        lowrandom = lows[indRandomthree];

        good = GameObject.Find(toprandom);
        meh = GameObject.Find(midrandom);
        bad = GameObject.Find(lowrandom);



        XINXETA.SetActive(false);
        


    }
    


    IEnumerator Moving()
    {
        
        for (i = 0; i < 100; i++)
        {
            barra.value = barra.value + 1f;
            //print("Sube");
            yield return new WaitForSeconds(velocity);
        }

        print("Acaba de subir");

        StartCoroutine(Movingdos());
        StopCoroutine(Moving());

    }
    IEnumerator Movingdos()
    {
        for (i = 0; i < 100; i++)
        {
            barra.value = barra.value - 1f;
            yield return new WaitForSeconds(velocity);
            //print("Baja");
        }
        print("Acaba de bajar");
        StartCoroutine(Moving());
        StopCoroutine(Movingdos());
        
    }
    IEnumerator TimeOut()
    {
       

        for (i = 0; i < 5; i++)
        { 
            print("Quedan "+i+" segundos");
            yield return new WaitForSeconds(1f);
        }
        background.transform.position = background.transform.position - new Vector3(distancia, 0, 0);
        print("TimeOut!");
        RandomValues();
        barra.value = 0;
        StartCoroutine(Moving());
        stop.Enable();
    }
}
