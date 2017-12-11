using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MovingCharacter {

	public SpriteRenderer sr;
	public PolygonCollider2D pc;
	private bool isVisible = false;
	private int inAttack;//valor que controla as fases do ataque
	private float homeX, homeY, timer;//valores que definem, respectivamente, a posição x da patrulha, a posição y da patrulha e o tempo para o próximo ataque
	private Transform target;

	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();//pega manualmente o personagem como parâmetro
		homeX = transform.position.x;
		homeY = transform.position.y;
		speed = 12f;//define a velocidade do pombo
	}

	void FixedUpdate () {

		if (sr.isVisible == true && isVisible == false) {
			target.GetComponent<CharacterBehaviours> ().enemiesOnScreen.Add (this);
			isVisible = true;
		}else if (sr.isVisible == false && isVisible == true) {
			target.GetComponent<CharacterBehaviours> ().enemiesOnScreen.Remove(this);
			isVisible = false;
		}

		/*if (timer > 0) {//esse bloco reduz o timer
			timer --;
		}

		if (Vector3.Distance (target.position, transform.position) > 7 && timer <= 0 && inAttack == 0) {//esse bloco faz o pombo entrar em ataque
			homeX = transform.position.x;
			timer = 200;
			inAttack = 1;
			direction = (int)Mathf.Sign(target.position.x - transform.position.x);
		}


		if (inAttack >0 && inAttack < 30 && Mathf.Abs(target.position.y - transform.position.y) > 1) {//esse bloco controla o ataque do pombo no primeiros momentos do contador inAttack
			inAttack++;
			Move (Mathf.Sign (transform.position.y - target.position.y) * -4);
		} else if (inAttack >= 30 && inAttack < 60) {//esse bloco controla o ataque do pombo no últimos momentos do contador inAttack
			inAttack++;
			Move (0f);
		} else {//esse bloco controla a movimentação padrão do pombo fora do ataque
			Move (0f);
		}

		if (inAttack == 0 && Mathf.Abs(transform.position.y - homeY) >= 0.5f){//esse bloco faz o pombo voltar para a posição y de patrulha
			Move (Mathf.Sign (transform.position.y - homeY) * -4);
		}

		if (inAttack == 60) {//esse bloco zera o contador do ataque
			inAttack = 0;
		}*/
	}

	public override void Move(float movY){//esse bloco sobrescreve a função Move do MovingCharacter
		rb.velocity = new Vector2 (direction * speed, movY);
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.name == "Sword" && other.GetComponent<Sword>().striking == true) {
			TakingDamage ();
		}
	}

	public void TakingDamage(){
		target.GetComponent<CharacterBehaviours> ().jumps = 1;
		Destroy (gameObject);
	}

}
