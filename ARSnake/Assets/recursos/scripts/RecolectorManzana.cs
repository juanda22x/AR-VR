using System;
using System.Collections;
using System.Collections.Generic;using UnityEngine;

public class RecolectorManzanas : MonoBehaviour
{
    private ContadorManzanas contadorManzanas;

    void Start()
    {
        contadorManzanas = GameObject.FindObjectOfType<ContadorManzanas>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
            contadorManzanas.IncrementarContador();
        }
    }
}

