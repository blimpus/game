using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformFall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame


    void Fall() {
        rb2d.isKinematic = false;
    }

    public float fallDelay;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            Invoke("Fall", fallDelay);

        }
    }
}
