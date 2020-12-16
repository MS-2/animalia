using UnityEngine.SceneManagement;
using UnityEngine;

public class ControlLogo : MonoBehaviour {

	//El Logo y el tiempo para salir de la escena.
	[Header("GameObject Logos y Contador.")]
	//public GameObject LogoCodingIdeas;
	public float CargarMenu;


/*//	void Start(){
		LogoCodingIdeas.SetActive(true);
	}
/*/
	void Update(){
		
		if(CargarMenu > 0f){
			CargarMenu -= Time.deltaTime;
		}else{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			
		}

	}
}
