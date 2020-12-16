using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
 

public class TocarAnimalesMontana : MonoBehaviour {

	//El AnimatorController de la transición entre escenas.
	[Header("Animator Fade.")]
	public Animator FadeAnimator;
	
	//Variable int que controla los Arreglos.
	[Header("Index General.")]
	public int IndexG;

	//El AudioSource y los AudioClips de los Animales.
	[Header("AudioSource y AudioClips de Animales.")]
	public AudioSource AS_Animales;
	public bool[] PrimerSonido;												
	public AudioClip[] AC_AnimalesVoz;
	public AudioClip[] AC_AnimalesEfecto;
		
	//Arreglo de AnimatorControllers de cada Animal.
	[Header("Lista de controladores para cada animación.")]
	public Animator[] ACL_Animales;


//*****************************************************************
//*********************  FUNCIONES  NIVEL  ************************
//***************************************************************** 

	//Activa la animacion y el audio del animal que se ha tocado.
	public void TocarAnimal(int x){
		IndexG = x;

		if(PrimerSonido[IndexG] == false){
			AS_Animales.clip = AC_AnimalesVoz[IndexG];
			PrimerSonido[IndexG] = true;
		}else{
			ACL_Animales[IndexG].SetTrigger("accion");
			AS_Animales.clip = AC_AnimalesEfecto[IndexG];
		}

		AS_Animales.Play();
	}
	
//*****************************************************************
}