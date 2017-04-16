//PlayerMovement.cs -- Samuel López Hernández
//Clase que controla los movimientos del personaje 
//principal en base a las animaciones.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : GameCharacter {

	[Header ("Player Movement")]
	public Transform lockedEnemy;

	public bool lookAtEnemy;



	public float comboTimer = 0;
	public bool continueCombo = false;

	// Update is called once per frame
	void Update () {
		bool isInAttack = isInAnimatorState (0, "Attacks.attack1") || isInAnimatorState (0, "Attacks.attack2") || isInAnimatorState (0, "Attacks.attack3");
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		float inputMagnitude = Mathf.Abs(h) + Mathf.Abs(v);
		isBlocking = animator.GetLayerWeight(1) > 0.95f;

		if (Input.GetButton("Defense")) {
			animator.SetLayerWeight (1, Mathf.Lerp (animator.GetLayerWeight (1), 1, Time.deltaTime * 5));
		} else {
			animator.SetLayerWeight (1, Mathf.Lerp (animator.GetLayerWeight (1), 0, Time.deltaTime * 5));

			//Atacar
			if (Input.GetButtonDown ("Attack")) {
				if (!isInAttack) {
					animator.SetTrigger ("attack");
				} 
				checkCombo ();
			}
		}

		if (Input.GetButtonDown ("Spell"))
			animator.SetTrigger ("spell");
		
		if (isInAttack) {
			AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo (0);

			float playbackTime = currentState.normalizedTime % 1;

			if (playbackTime < 0.5f)
				continueCombo = false;
		}

		comboTimer += Time.deltaTime;
	

		if (Input.GetButtonDown ("Kick"))
			animator.SetTrigger ("kick");


		if (Input.GetButtonDown ("LockEnemy")) {
			lockedEnemy = closestObject ("EnemyRoot").transform;

			if (lockedEnemy)
				lookAtEnemy = !lookAtEnemy;
			else
				lookAtEnemy = false;
		} 
			



		if (lookAtEnemy) {
			if (lockedEnemy) {
				if (lockedEnemy.tag == "Untagged") {
					lookAtEnemy = false;
					lockedEnemy = null;
				}
				if (!isInAnimatorState (0, "Attack")) {
					transform.LookAt(new Vector3(lockedEnemy.transform.position.x, transform.position.y, lockedEnemy.transform.position.z));
				}
			}

		} else {
			if (inputMagnitude > 0)
			{
				Vector3 moveDirection = new Vector3(h, 0, v);
				Vector3 relToCam = Camera.main.transform.TransformDirection(moveDirection);
				relToCam.y = 0;
				transform.rotation = Quaternion.LookRotation(relToCam);
			}
		}
			
		animator.SetFloat ("speedMagnitude", inputMagnitude);
		animator.SetFloat ("speedh", h);
		animator.SetFloat ("speedv", v);
		animator.SetBool ("lookAtEnemy", lookAtEnemy);

		animator.SetBool ("continueCombo", continueCombo);
	}

		
	void checkCombo () {
		continueCombo = true;
	/*	if (comboTimer <= 0.3f || comboTimer >= 1f ) {
			continueCombo = false;
		} else {
			continueCombo = true;
		}
	
		comboTimer = 0;*/
	}






		
}
