using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
        
        private float _gun = 4f;
        void Start()
        {
            transform.position = new Vector3(3, 10, 0);
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.down * _gun * Time.deltaTime);
            vanish();
        }
        void vanish()
        {
            if (transform.position.y <= -10f)
            {
                float Randomx = Random.Range(-10f, 10f);
                transform.position = new Vector3(Randomx, 10f, 0);
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enemy collided with: " + other.name + " at time: " + Time.time);

        

        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                Destroy(this.gameObject);
                player.Damage();
            }

            
        }
        else if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);  
            Destroy(this.gameObject); 
        }
    }
}
