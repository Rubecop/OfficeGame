using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorEnergia : MonoBehaviour
{
    public SO energyCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        energyCounter.count -= Time.deltaTime;
    }
}
