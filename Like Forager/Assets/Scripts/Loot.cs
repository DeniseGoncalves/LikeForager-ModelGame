using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public Item item;
    private float startYPosition;
    private Rigidbody2D m_Rigidbody;
    private bool isActive;
    public Collider2D col;

    // Update is called once per frame
    void Update()
    {
        if(isActive == true && transform.position.y < startYPosition - (Random.Range(0.2f, 0.6f)))
        {
            m_Rigidbody.gravityScale = 0;
            m_Rigidbody.velocity = Vector2.zero;
            col.enabled = true;
            isActive = false;
        }
    }

    void Active (int dir)
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        col.enabled = false; // Desativa o colisor para evitar colisões enquanto o loot está sendo lançado

        startYPosition = transform.position.y;
        m_Rigidbody.gravityScale = 1.8f;
        m_Rigidbody.AddForce(Vector2.up * 250 + Vector2.right * (Random.Range(20, 35) * dir)); // Adiciona uma força para cima e para os lados, com uma direção aleatória
        isActive = true;
    }
}
