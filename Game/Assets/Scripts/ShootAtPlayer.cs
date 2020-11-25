using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{
    [SerializeField]
    Transform playerPosition;
    
    public GameObject projectile;
    public GameObject player;
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
        playerPosition = GameObject.FindGameObjectWithTag ("Player").transform;
        StartCoroutine(PrimaryCountdownRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToShoot = (player.transform.position - transform.position).normalized;

        if (directionToShoot.magnitude < range && canShoot)
        {
            if(RaycastSightCheck()){
                //Shoot at Player
                Instantiate(projectile, transform.position + directionToShoot * projectileOffset, 
                            Quaternion.LookRotation(directionToShoot));
                canShoot = false;
                StartCoroutine(PrimaryCountdownRoutine());
            }
        }
    }

    IEnumerator PrimaryCountdownRoutine()
    {
        yield return new WaitForSeconds(primaryCD);
        canShoot = true;
    }

    bool RaycastSightCheck()
    {
        RaycastHit hit;
        if (playerPosition != null)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 500)) {
                if ((hit.collider.gameObject != null) && (hit.collider.gameObject.tag == "Player")) {
                    Debug.Log("Player spotted for shoot check");
                    return true;
                }
                else {
                    Debug.Log("View obstructed by "+ hit.collider.name);
                    return false;
                }
            }
            else {
                Debug.Log("Raycast didnt hit anything");
                return false;
            }
        }
        Debug.Log("Player position is null");
        return false;
    }
}
