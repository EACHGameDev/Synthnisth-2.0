using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class MovingCharacter : MonoBehaviour {

	public Animator an;
	public int direction = 1;
	public float speed;
	public Rigidbody2D rb;//passar o prefab do objeto a qual este código vai ser anexado como parametro no inspector
	public Transform transform;

	public void Flip(){//esse bloco inverte o sprite e pode ser usado para mudar a direção do movimento (Pigeon)
		direction *= -1;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	virtual public void Move(float movX){//esse bloco inicialmente faz a movimentação do personagem apenas no eixo x recebendo a direção como parâmetro e invertendo o sprite quando essa é multiplicada por -1
		an.SetBool("Moving",true);
		if (movX > 0 && direction < 0 || movX < 0 && direction > 0) {
			Flip ();
		}
		rb.velocity = new Vector2 (movX * speed, rb.velocity.y);
	}

}
