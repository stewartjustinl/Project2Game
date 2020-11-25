using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{
    private GameObject player;
    public GameObject projectile;
    private Rigidbody enemyRb;

    private float primaryCD = 3.0f;
    private float range = 10.0f;
    private bool canShoot;
    public float projectileOffset;



    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player 2");
        StartCoroutine(PrimaryCountdownRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToShoot = (player.transform.position - transform.position).normalized;

        if (directionToShoot.magnitude < range && canShoot)
        {
            //Shoot at Player
            Instantiate(projectile, transform.position + directionToShoot * projectileOffset, 
                        Quaternion.LookRotation(directionToShoot));
            canShoot = false;
            StartCoroutine(PrimaryCountdownRoutine());
        }
    }

    IEnumerator PrimaryCountdownRoutine()
    {
        yield return new WaitForSeconds(primaryCD);
        canShoot = true;
    }
}
