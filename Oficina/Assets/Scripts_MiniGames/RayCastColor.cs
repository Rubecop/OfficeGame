using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastColor : MonoBehaviour
{
    public string colo;
    public int rango;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * rango, Color.green);
        if (Physics.Raycast(ray,out hit))
        {
                print("golpea");

            Image image = hit.collider.GetComponent<Image>();
            colo = image.gameObject.name;
            print(image.gameObject.name);
            
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);
        colo= collision.gameObject.name;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == ("Orange"))
        {
            colo = "Red";
            print("Red");
        }
    }
    
        
    
}
