using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private GameObject _blob;

    //SpawnPoints for Porjectiles
    [SerializeField] private GameObject _projectileSpawn01;
    [SerializeField] private GameObject _projectileSpawn02;
    [SerializeField] private GameObject _projectileSpawn03;
    [SerializeField] private GameObject _projectileSpawn04;

    //SpawnPoint for Blob
    [SerializeField] private GameObject _blobSpawnPoint;

    //Boss Movement
    [Range(0, 1)] private int _movement;

    [SerializeField] private float _battleSpeed = 3;

    private bool _bossIsActive;
    void Start()
    {
        //Temporary tru bool
        _bossIsActive = true;

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

    }

    IEnumerator BossFightRoutine()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(_projectile, _projectileSpawn01.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(1f);
        Instantiate(_projectile, _projectileSpawn02.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(1f);
        Instantiate(_projectile, _projectileSpawn03.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(1f);
        Instantiate(_projectile, _projectileSpawn04.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(3f);
        Instantiate(_blob, _blobSpawnPoint.transform.position, Quaternion.identity);
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
}
