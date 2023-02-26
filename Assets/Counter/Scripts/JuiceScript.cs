using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceScript : MonoBehaviour
{
    public Rigidbody juiceRb;

    void Start()
    {
        juiceRb = GetComponent<Rigidbody>();
    }

    void Update()
    {    
        juiceRb.AddForce(Vector3.back * 4);
    }

    

}
