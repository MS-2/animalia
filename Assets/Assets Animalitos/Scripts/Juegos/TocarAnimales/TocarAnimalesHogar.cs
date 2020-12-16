using UnityEngine;
using System.Collections.Generic;


public class TocarAnimalesHogar : MonoBehaviour {

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

	//Arreglo de Animators para Elementos Interactuables.
	[Header("Lista de Animators para Elementos Interactuables.")]
	public Animator rex;
	public Animator patito;

	
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




	public void juguete1(){
		rex.SetTrigger("accion");
	}	

	public void juguete2(){
		patito.SetTrigger("accion");
	}

	
	
//************************************************************************




}
