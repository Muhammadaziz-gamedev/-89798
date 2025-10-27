using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8f;
    [SerializeField]

    void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        if(transform.position.y > 10f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
    }


}




