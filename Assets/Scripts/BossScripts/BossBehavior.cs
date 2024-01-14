using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private GameObject _blob;

    [SerializeField] private GameObject _waveAttack01;
    [SerializeField] private GameObject _waveAttack02;

    //SpawnPoints for Porjectiles
    [SerializeField] private GameObject _projectileSpawn01;
    [SerializeField] private GameObject _projectileSpawn02;
    [SerializeField] private GameObject _projectileSpawn03;
    [SerializeField] private GameObject _projectileSpawn04;

    //Spawn Points for Wave Attack
    [SerializeField] private GameObject _waveSpawn01;
    [SerializeField] private GameObject _waveSpawn02;

    //SpawnPoint for Blob
    [SerializeField] private GameObject _blobSpawnPoint;

    //Boss Movement
    [Range(0, 1)] private int _movement;
    [SerializeField] private float _battleSpeed = 3;

    //Boss Health
    [SerializeField] private int _health = 150;

    //Audio
    [SerializeField] private AudioSource _waveAttack;
    [SerializeField] private AudioSource _projectileAttackSFX;
    [SerializeField] private AudioSource _blobSFX;

    public UIManager uiManager;

    private bool _bossIsActive;
    void Start()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        if (uiManager == null)
        {
            Debug.Log("UI Manager is NULL");
        }
        //Temporary tru bool
        _bossIsActive = true;

        _waveAttack = GameObject.Find("BossWaveAttackSFX").GetComponent<AudioSource>();
        _projectileAttackSFX = GameObject.Find("BossProjectileSFX").GetComponent<AudioSource>();
        _blobSFX = GameObject.Find("BossBlobSFX").GetComponent<AudioSource>();

        _movement = 0;
        StartCoroutine(BossFightRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (_bossIsActive == true)
        {
            CasualMovement();
        }
        if (_health==0)
        {
            BossHasDied();
        }


    }

    IEnumerator BossFightRoutine()
    {
        
        while (_bossIsActive == true)
        {

            yield return new WaitForSeconds(1f);
            Instantiate(_projectile, _projectileSpawn01.transform.position, Quaternion.identity);
            _projectileAttackSFX.Play();

            yield return new WaitForSeconds(1f);
            Instantiate(_projectile, _projectileSpawn02.transform.position, Quaternion.identity);
            _projectileAttackSFX.Play();

            yield return new WaitForSeconds(1f);
            Instantiate(_projectile, _projectileSpawn03.transform.position, Quaternion.identity);
            _projectileAttackSFX.Play();

            yield return new WaitForSeconds(1f);
            Instantiate(_projectile, _projectileSpawn04.transform.position, Quaternion.identity);
            _projectileAttackSFX.Play();

            yield return new WaitForSeconds(3f);
            Instantiate(_blob, _blobSpawnPoint.transform.position, Quaternion.identity);
            _blobSFX.Play();

            yield return new WaitForSeconds(1f);
            Instantiate(_projectile, _projectileSpawn01.transform.position, Quaternion.identity);
            _projectileAttackSFX.Play();

            yield return new WaitForSeconds(1f);
            Instantiate(_projectile, _projectileSpawn02.transform.position, Quaternion.identity);
            _projectileAttackSFX.Play();

            yield return new WaitForSeconds(1f);
            Instantiate(_projectile, _projectileSpawn03.transform.position, Quaternion.identity);
            _projectileAttackSFX.Play();

            yield return new WaitForSeconds(1f);
            Instantiate(_projectile, _projectileSpawn04.transform.position, Quaternion.identity);
            _projectileAttackSFX.Play();

            yield return new WaitForSeconds(3f);
            Instantiate(_waveAttack01, _waveSpawn01.transform.position, Quaternion.identity);
            _waveAttack.Play();

            yield return new WaitForSeconds(1.5f);
            Instantiate(_waveAttack02, _waveSpawn02.transform.position, Quaternion.identity);
            _waveAttack.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("entering damage");
        if (other.tag=="Projectile")
        {
            Damage();
        }
    }
    
    private void CasualMovement()
    {
        if (transform.position.x <= 4.5f)
        {
            _movement = 1;
        }

        if (transform.position.x >= 10.5)
        {
            _movement = 0;
        }

        switch (_movement)
        {
            case 0:
                MoveLeft();
                break;

            case 1:
                MoveRight();
                break;

            default:
                break;
        }

    }

    private void MoveLeft()
    {
        transform.Translate(Vector3.left * _battleSpeed * Time.deltaTime);
    }

    private void MoveRight()
    {
        transform.Translate(Vector3.right * _battleSpeed * Time.deltaTime);
    }

    public void Damage()
    {
        _health -= 6;
        uiManager.UpdateBossHealth(_health);
    }

    public void BossHasDied()
    {
        _bossIsActive = false;
        StopCoroutine(BossFightRoutine());
        Debug.Log("Boss is Dead");
        Destroy(gameObject);
        
        SceneManager.LoadScene("Outro Scene", LoadSceneMode.Single);
        
    }
}
