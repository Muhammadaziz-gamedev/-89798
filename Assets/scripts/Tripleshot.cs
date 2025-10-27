using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tripleshot : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    private Player _player;
    [SerializeField]
    private int powerupID;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -5.21)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
                if (player != null)
            {
                switch(powerupID)
                {
                    case 0:player.ActiveTripleShot(); 
                    break;
                    case 1:player.ActiveSpeedup();
                    break;
                    case 2: player.shield();
                    break;
                }
                }
            Destroy(this.gameObject);
        }
    }
}
