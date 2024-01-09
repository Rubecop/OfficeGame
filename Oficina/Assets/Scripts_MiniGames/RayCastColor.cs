using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastColor : MonoBehaviour
{
    public string colo;
    public int rango;
    public int valorcolor=0;
    // Start is called before the first frame update
    void Start()
    {
        //colo = "Red";
        //valorcolor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);
        if (collision.name == "Orange")
        {
            valorcolor = 1;
            print(valorcolor);
        }else if (collision.name == "Green")
        {
            valorcolor = 2;
            print(valorcolor);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == ("Green"))
        {
            valorcolor = 1;
            print(valorcolor);
        }
        if (collision.gameObject.name == ("Orange")&&colo!="Green")
        {
            valorcolor = 0;
            print(valorcolor);
            print("Red");
        }
    }
    
        
    
}
