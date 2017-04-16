using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_SpellManager : MonoBehaviour {

	public CS_Spell spell;
	

	void castSpell () {
		switch (spell.spellType) {
		case CS_Spell.SPELL_TYPE.self:
			GetComponent <Animator> ().SetFloat ("spellSelector", 0);
			break;
		case CS_Spell.SPELL_TYPE.area:
			GetComponent <Animator> ().SetFloat ("spellSelector", 1);
			break;
		}
	}


	void castSpellArea () {
		RaycastHit hit;

		if (Physics.SphereCast(transform.position, 5f, transform.forward, out hit, 10, LayerMask.NameToLayer("GameCharacter")))
		{
			Debug.Log (hit.collider.name);
		}
	}
}
