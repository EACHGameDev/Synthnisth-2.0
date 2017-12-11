using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword: MonoBehaviour {

	public CharacterBehaviours character;//passar o jogador como variável no inspector
	public bool striking = false;
	public KeyCode strike = KeyCode.D;//botão pra atacar

	void FixedUpdate(){
		if (Input.GetKeyDown (strike) && striking == false) {
			StartCoroutine (Strike ());
		}
	}

	IEnumerator Strike (){//esse bloco ativa o ataque do protagonista
		striking = true;
		character.an.SetBool ("Attacking", true);
		for (int i = 0; i < 10; i++) {
			character.rb.AddForce (new Vector2 (2000 * character.direction, 1.2f), ForceMode2D.Force);
			yield return new WaitForSecondsRealtime (0.015f);
		}
		striking = false;
	}
}
