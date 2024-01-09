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

    public int opcion = 1;
    public int i;
    public bool subir=true;
    public InputAction stop;
    public Vector3 pivoteee;
    public float velocity;
    RayCastColor raya;

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
            StopAllCoroutines();
            stop.Disable();
            StartCoroutine(TimeOut());
        }
    }
    public void RandomValues()
    {
        RectTransform olarg = orange.GetComponent<RectTransform>();
        BoxCollider2D ocol = orange.GetComponent<BoxCollider2D>();
        
        olarg.sizeDelta = new Vector2(Random.Range(150, 300), 58.3804f);
        ocol.size = olarg.sizeDelta;

        RectTransform glarg = green.GetComponent<RectTransform>();
        BoxCollider2D gcol = green.GetComponent<BoxCollider2D>();
        glarg.sizeDelta = new Vector2(Random.Range(5, 95), 58.3804f);
        gcol.size = glarg.sizeDelta;

        Vector3 cambio_green_orange = pivoteee + new Vector3(Random.Range(-300,300),0, 0);
        green.transform.position = cambio_green_orange;
        orange.transform.position = cambio_green_orange;

    }
    /*
    void LineMove()
    {
        
        

        switch (opcion)
        {
            case 1:
                for ( i = 0; i < 100; i++)
                {
                    barra.value=barra.value+0.1f;
                    print("Cuenta");
                }
                
                
                break;

            case 2:
                for ( i = 100; i > 0; i--)
                {
                    barra.value = i;
                }
                
                break;

        }
    }*/

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

        /*
        switch (opcion)
        {
            case 1:
                for (i = 0; i < 100; i++)
                {
                    barra.value = barra.value + 1f;
                    print("Sube");
                    yield return new WaitForSeconds(0.1f);
                }
                print("Acaba de subir");
                opcion = 2;
                break;
            case 2:
                for (i = 0; i < 100; i++)
                {
                    barra.value = barra.value - 0.1f;
                    yield return new WaitForSeconds(0.1f);
                    print("Baja");
                }
                opcion = 1;
                break;
        
        }
        */




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
        if (raya.colo == "Red")
        {
            print("Cagaste");
        }
        else if (raya.colo == "Orange")
        {
            print("No está mal");
        }else if (raya.colo == "Green")
        {
            print("BOOOOOOOOOOOOOOOOOmba");
        }

            for (i = 0; i < 5; i++)
        { 
            print("Quedan "+i+" segundos");
            yield return new WaitForSeconds(1f);
        }
        print("TimeOut!");
        RandomValues();
        barra.value = 0;
        StartCoroutine(Moving());
        stop.Enable();
    }
}
