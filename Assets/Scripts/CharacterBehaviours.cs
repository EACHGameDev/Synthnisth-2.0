using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public enum Power {powerUp1, invencibleRush, swordBomb};
public class CharacterBehaviours : MovingCharacter {
	
	public int jumps = 0;//valor que controla a quantidade de saltos realizada
	public List<Pigeon> enemiesOnScreen;
	public BoxCollider2D bc;//passar o character como parâmetro no inspector
	public Sword sword;
	private bool _invencibleRush, _swordBomb, _death;
	float jumpForce = 550f;
	KeyCode jump = KeyCode.S;//botão pra pular
	//Power effect;
	AudioManager ams;

	void Start () {
		an.SetBool ("Moving", false);
		an.SetBool ("OnFloor", false);
		an.SetBool ("Attacking", false);
		an.SetBool ("Dead", false);
		speed = 20f;
		//Liga o som
		ams= AudioManager.instance;

	}

	void FixedUpdate(){
		if (transform.position.y >= 200)
			rb.velocity = new Vector2 (0, rb.velocity.y * (-1));
		if (rb.velocity.y <= -20)
			rb.gravityScale = 0;
		if (Input.GetKeyDown (sword.strike) && _swordBomb == true) {
			foreach (Pigeon p in enemiesOnScreen){
				p.TakingDamage ();
			}
			_swordBomb = false;
		}
		Move (Input.GetAxis ("Horizontal"));//isso passa como parametros os eixos horizontais. É necessário mecher nos axis do Unity e retirar o "a" e o "d" como gatilhos secudarios de horizontals
		Jump ();
	}
	IEnumerator morte (){
		an.SetBool ("Dead", true);
		ams.playSound("die1");
		rb.velocity = new Vector2 (0, 0);
			rb.gravityScale = 0;
		yield return new WaitForSeconds (2.150f);
		an.SetBool ("Dead", false);
		SceneManager.LoadScene ("prototipo", LoadSceneMode.Single);
	}


	public void GameOver(){		
		StartCoroutine (morte ());
	}

	void Jump(){//esse código controla o pulo por um sistema dinâmico de contagem simples. O valor de jumps é zerado no código foot
		if(Input.GetKeyDown(jump) && jumps < 2){
			//rb.AddForce(new Vector2(rb.velocity.x, 0));
			ams.playSound("jump");
			rb.AddForce(new Vector2(rb.velocity.x, jumpForce));

			jumps++;
		}
	}

	IEnumerator InvencibleRush(){
		_invencibleRush = true;
		speed = 30;
		jumpForce = 750;
		sword.striking = true;
		yield return new WaitForSeconds (5);
		speed = 20;
		jumpForce = 550;
		sword.striking = false;
		_invencibleRush = false;
	}

	IEnumerator SwordBomb (){
		_swordBomb = true;
		yield return new WaitForSeconds (5);
		_swordBomb = false;
	}

	public void PowerUp (Power power){
		switch (power) {
		case Power.powerUp1:
			break;
		case Power.invencibleRush:
			if (_invencibleRush == false){
				StartCoroutine (InvencibleRush ());
			}
			break;
		case Power.swordBomb:
			if (_swordBomb == false) {
				StartCoroutine (SwordBomb ());
			}
			break;
		default:
			break;
		}
	}

	/*It was too glowing to be called a sword. 
	 * Magenta, shining, heavy, and far too 80's. 
	 * Indeed, it was a heap of raw motherfucking neon vapor-hazard.
    */
}
