using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {

	public CharacterBehaviours character;//passar o character como parametro no inspector

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "PowerBox") {//esse bloco destroy o powerblock e pega o poder contido nela
			Destroy (other.gameObject);
			PowerBlock _power = other.gameObject.GetComponent<PowerBlock> ();
			character.PowerUp(_power.power);
		}else if (other.gameObject.tag == "Insta Kill") //esse bloco recarrega a fase caso o protagonista encoste em algum objeto que o mate instantaneamente
			character.GameOver ();
	}
}
