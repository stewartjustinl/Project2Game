using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float horizontalInput;
    public Vector3 horizontalDelta;
    public float verticalInput;
    public Vector3 verticalDelta;
    public float speed = 10.0f;
    public float dashSpeed = 20f; 
    public GameObject projectilePrefab;
    public Vector3 projectileOffset;
    public bool hasPowerup;
    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        hasPowerup = false; 
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        horizontalDelta = Camera.main.transform.right * horizontalInput * Time.deltaTime * speed;
        horizontalDelta.y = 0;
        verticalInput = Input.GetAxisRaw("Vertical");
        verticalDelta = Camera.main.transform.up * verticalInput * Time.deltaTime * speed;
        verticalDelta.y = 0;
        Vector3 totalDelta = (horizontalDelta + verticalDelta);
        totalDelta.Normalize();
        // transform.position = transform.position + (totalDelta * Time.deltaTime * speed);
        playerRb.AddForce(totalDelta * speed, ForceMode.Force);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Launch a projectile from the player
            Instantiate(projectilePrefab, (transform.position + projectileOffset), projectilePrefab.transform.rotation); 
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            playerRb.AddForce(totalDelta * dashSpeed, ForceMode.Impulse); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
