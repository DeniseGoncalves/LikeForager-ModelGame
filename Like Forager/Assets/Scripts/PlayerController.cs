using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;
    private Animator m_Animator;

    private Vector2 movementInput;
    private Vector2 mousePosition;

    private bool isLookLeft = true;
    private bool isWalk;

    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>(); //O Getcomponent só funciona se o Rigidbody estiver no mesmo inspector que o script 
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Pega a posição do mouse na tela e converte para o mundo do jogo
        if(mousePosition.x < transform.position.x && isLookLeft == false)
        {
            Flip(); //Se o mouse estiver à esquerda do personagem e ele não estiver olhando para a esquerda, chama a função Flip
        }
        if(mousePosition.x > transform.position.x && isLookLeft == true)
        {
            Flip(); //Se o mouse estiver à direita do personagem e ele estiver olhando para a esquerda, chama a função Flip
        }

        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        isWalk = movementInput.magnitude != 0; //Se o movimento for diferente de zero, isWalk será verdadeiro, caso contrário, falso

        m_Rigidbody.velocity = movementInput * movementSpeed; 

        m_Animator.SetBool("isWalk", isWalk);    
        
    }

    private void Flip()
    {
        isLookLeft = !isLookLeft; //Inverte o valor de isLookLeft
        float x = transform.localScale.x * -1; //Inverte a escala do personagem no eixo x
        transform.localScale = new Vector3(x, 1, 1); //Aplica a nova escala ao personagem
    }
}
