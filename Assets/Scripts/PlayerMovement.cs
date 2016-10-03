using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    internal static bool IsDead;
    private float Scale;
    public float JumpVel;
    private float XPosition;
    public AudioClip BananaSound;
    private bool GunShotPlayed = false;
    public MenuStateManager msm;
	public static int numTimesPlayed = 0;

    void Start ()
    {
        IsDead = false;
        Scale = transform.localScale.x;
        XPosition = transform.position.x;
	}

	void Update ()
    {
        //if (Input.anyKeyDown) Jump();


        transform.Translate(Input.acceleration.x, 0, 0);

        if (transform.position.x < XPosition)
        {
            transform.localScale = new Vector3(Scale, transform.localScale.y, 1);
        }
        else
        {
            transform.localScale = new Vector3(-Scale, transform.localScale.y, 1);
        }
        if (IsDead)
        {
            PlayerDeath();
        }
    }
 
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Platform") 
        {
            Jump();
        }
        else if (collider.gameObject.tag == "Ground")
        {
            Jump();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Banana")
        {
            Score.score += 20;
            AudioSource.PlayClipAtPoint(BananaSound, transform.position);
			Vector3 posBan = collider.transform.position;
			posBan.y += 16.3f;
			collider.transform.position = posBan;
        }

		if (collider.tag == "Kid") {
			PlayerDeath ();
			Destroy (collider);
		}
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * JumpVel, ForceMode2D.Impulse);

    }

    void PlayerDeath()
    {
        if (!GunShotPlayed)
        {
            IsDead = true;
            GetComponent<Rigidbody2D>().isKinematic = true;
            numTimesPlayed++;
            GunShotPlayed = true;
        }
		msm.LoadScene("GameOver");
    }
		
}
