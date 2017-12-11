using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour {//esse código deve ser fixado num objeto vazio que representaria os pés do protagonista, tendo um collider com valores 0 e -3.75 de offset e 0.9 e 0.25 de size

	public CharacterBehaviours character;//passar o jogador como variável no inspetor
	public Rigidbody2D rb;//passar o jogador como variável no inspector

	void OnCollisionEnter2D(Collision2D other){//esse bloco faz a mesma coisa que o superior, apenas foi adicionado para deixar o gameplay mais flúido
		if (other.gameObject.tag == "Ground") {
			character.jumps = 0;
			character.rb.gravityScale = 2;
		}
	}

}
