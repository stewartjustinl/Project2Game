using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Player Model Rigidbody
    private Rigidbody playerRb;
    // User Input
    public float horizontalInput;
    public Vector3 horizontalDelta;
    public float verticalInput;
    public Vector3 verticalDelta;
    // Player Parameters
    public float speed = 10.0f;
    public float dashSpeed = 20f;
    public float dashCD;
    public float primaryCD;
    public bool canShoot;
    public bool canDash;
    public bool hasPowerup;
    public int health;
    public Vector3 projectileOffset;
    // Game Objects
    public GameObject projectilePrefab;
    public GameObject powerupIndicator;
    // Audio 
    private AudioSource playerAudio;
    public AudioClip pewPew;
    public AudioClip ouch;
    public AudioClip woosh;
    public AudioClip newItem;

    // Start is called before the first frame update
    void Start()
    {
        // Get the components we need later 
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        // Initialize Player State 
        hasPowerup = false;
        canDash = true;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Move Player based on User Input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        horizontalDelta = Camera.main.transform.right * horizontalInput * Time.deltaTime * speed;
        horizontalDelta.y = 0;
        verticalInput = Input.GetAxisRaw("Vertical");
        verticalDelta = Camera.main.transform.up * verticalInput * Time.deltaTime * speed;
        verticalDelta.y = 0;
        Vector3 totalDelta = (horizontalDelta + verticalDelta);
        totalDelta.Normalize();
        playerRb.AddForce(totalDelta * speed, ForceMode.Force);

        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            // Launch a projectile from the player
            Instantiate(projectilePrefab, (transform.position + projectileOffset), projectilePrefab.transform.rotation);
            playerAudio.PlayOneShot(pewPew);
            canShoot = false;
            StartCoroutine(PrimaryCountdownRoutine());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            // Moves the player quickly in the direction they were moving
            playerRb.AddForce(totalDelta * dashSpeed, ForceMode.Impulse);
            playerAudio.PlayOneShot(woosh);
            canDash = false;
            StartCoroutine(DashCountdownRoutine());
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
            Debug.Log("Player picked up " + other.gameObject);
            playerAudio.PlayOneShot(newItem);
        }

        if (other.CompareTag("Food"))
        {
            health += 1;
            Destroy(other.gameObject);
            Debug.Log("Player ate " + other.gameObject);
            playerAudio.PlayOneShot(newItem);
            PlayerStats.Instance.Heal(health); // adds to heart health
        }

        if (other.CompareTag("Projectile") || other.CompareTag("Enemy"))
        {
            health -= 1;
            // Don't destroy the object if it is an enemy
            if (other.CompareTag("Projectile"))
            {
                Destroy(other.gameObject);
            }
            Debug.Log("Player was hit by " + other.gameObject);
            playerAudio.PlayOneShot(ouch);
            PlayerStats.Instance.TakeDamage(1); // removed heart health
            if (health == 0)
            {
                SceneManager.LoadScene(1); 
            }
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    IEnumerator PrimaryCountdownRoutine()
    {
        float timeToWait = primaryCD;
        if (hasPowerup)
        {
            timeToWait /= 2;
        }
        yield return new WaitForSeconds(timeToWait);
        canShoot = true;
    }

    IEnumerator DashCountdownRoutine()
    {
        yield return new WaitForSeconds(dashCD);
        canDash = true; ;
    }
}
