using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderInLayer : MonoBehaviour
{
    private SpriteRenderer m_SpriteRenderer;
    private float playerY;
    public float offSet;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if(m_SpriteRenderer == null)
        {
            return; //Se não houver SpriteRenderer, não faz nada
        }

        playerY = CoreGame._instance.playerController.positionY;

        if(transform.position.y <playerY - offSet)
        {
            m_SpriteRenderer.sortingLayerName = "PrimeiroPlano"; //Se o objeto estiver abaixo do jogador, muda a layer para "PrimeiroPlano"
        }
        else
        {
            m_SpriteRenderer.sortingLayerName = "SegundoPlano"; //Se o objeto estiver acima do jogador, muda a layer para "SegundoPlano"
        }
    }
}
