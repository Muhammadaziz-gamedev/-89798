using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float _speed = 3.5f;
    public float _speedmultiplier = 2;

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleshotPrefab;

    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;

    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private bool _istripleShotActive = false;
    private Spawnmanager _spawnManager;
    [SerializeField]
    private GameObject _Shield;
    private bool _speedpowerup = false;
    [SerializeField]
    private bool _Shields = false;
    [SerializeField]
    private GameObject Shieldvisual ;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawnmanager").GetComponent<Spawnmanager>();

        if (_spawnManager == null)
        {
            Debug.LogError("SpawnManager is NULL.");
        }
    }

    void Update()
    {
        HandleMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            Shoot();
        }
    }

    void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
        float clampedY = Mathf.Clamp(transform.position.y, -3.95f, 5.75f);
        transform.position = new Vector3(transform.position.x, clampedY, 0);

        if (this.gameObject.transform.position.x < -11.1f)
        {
            transform.position = new Vector3
            (11.05f, transform.position.y, 0);
        }
        else if (this.gameObject.transform.position.x > 11.05f)
        {
            transform.position = new Vector3(-11.1f, transform.position.y, 0);
        }
    }

    void Shoot()
    {
        _canFire = Time.time + _fireRate;
        Vector3 spawnPos = transform.position;
        if (_istripleShotActive == true)
        {
            Debug.Log("Everything working");
        }
        if (_istripleShotActive == true)
        {
            Instantiate(_tripleshotPrefab, spawnPos, Quaternion.identity);
        }
        else {
            Instantiate(_laserPrefab, spawnPos, Quaternion.identity);
        }
    }

    public void Damage()
    {
        if (_Shields == true)
        {
            _Shields = false;
            Shieldvisual.SetActive(false);
            return;
        }
        else
        {
            _lives -= 1;

            if (_lives < 1)
            {
                _spawnManager.OnPlayerDeath();
                Destroy(this.gameObject);
            }
        }
    }
    public void ActiveTripleShot()
    {
        _istripleShotActive = true;
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _istripleShotActive = false;
    }
    public void ActiveSpeedup()
    {
        _speedpowerup = true;
        _speed *= _speedmultiplier;
        StartCoroutine(SpawnRoutinespeed());
    }

    IEnumerator SpawnRoutinespeed()
    {
        yield return new WaitForSeconds(5.0f);
        _speed /= _speedmultiplier;
        _speedpowerup = false;
    }
    public void shield()
    {
        _Shields = true;
        Shieldvisual.SetActive(true);
    }
}


