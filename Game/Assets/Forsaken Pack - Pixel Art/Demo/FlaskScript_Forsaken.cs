using UnityEngine;
using System.Collections;

public class FlaskScript_Forsaken : MonoBehaviour {

    [SerializeField] float xSpeed = 1.0f;
    [SerializeField] float ySpeed = 1.0f;
    [SerializeField] GameObject explosion;

    private Rigidbody2D body2d;

	// Use this for initialization
	void Start () {
        body2d = GetComponent<Rigidbody2D>();
        body2d.velocity = new Vector2(body2d.velocity.x, ySpeed);
    }
	
	// Update is called once per frame
	void Update () {
        body2d.velocity = new Vector2(xSpeed * transform.localScale.x, body2d.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(explosion)
        {
            GameObject newExplosion = Instantiate(explosion, gameObject.transform.position - new Vector3(0.0f, 0.01f, 0.0f), gameObject.transform.rotation) as GameObject;
            newExplosion.transform.localScale = transform.localScale;
        }

        Destroy(gameObject);
    }

}
