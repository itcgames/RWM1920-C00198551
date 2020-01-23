using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopTheBalloon : MonoBehaviour
{
    private bool m_explod = false;
    private float m_popRange = 3.0f;
    private float m_popForce = 10.0f;

    private AudioSource m_popingSound;
    private Animator m_animation;

    // Start is called before the first frame update
    void Start()
    {
        m_popingSound = GetComponent<AudioSource>();
        m_animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_explod)
        {
            this.gameObject.AddComponent<CircleCollider2D>();
            this.gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
            this.gameObject.GetComponent<CircleCollider2D>().radius += m_popRange * (Time.deltaTime * 3);

        }
    }

    private void FixedUpdate()
    {
        if (m_explod)
        {
            if (this.gameObject.GetComponent<CircleCollider2D>().radius >= m_popRange)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("sharp"))
        {
            m_popingSound.Play();
            m_animation.SetBool("Popping", true);
            m_explod = true;
        }

        if (m_explod)
        {
            Vector2 targetPos = collision.gameObject.transform.position;
            Vector2 balloonPos = gameObject.transform.position;
            Vector2 blastForce = m_popForce * (targetPos - balloonPos);

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(blastForce);

        }

    }

}
