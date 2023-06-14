using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpColetavel : MonoBehaviour
{
   [SerializeField]
   private SpriteRenderer  spriteRenderer;

  [SerializeField]
   private float intervaloTempoAntesAutoDestruir;

   private float contagemTempoAntesAutoDestruir;
   private bool autodestruindo;

   [SerializeField]
   private float intervaloTempoEntrePiscadas;

   [SerializeField]
   private int quantidadeTotalPiscadas;

   [SerializeField]
    private float reducaoTempoEntrePiscadas;
   


   public  void Start() {
    this.autodestruindo = false;
    this.contagemTempoAntesAutoDestruir = 0;
    
   }

   public void Update() {
    if(!this.autodestruindo){
      
     this.contagemTempoAntesAutoDestruir += Time.deltaTime;
     if(this.contagemTempoAntesAutoDestruir >= this.intervaloTempoAntesAutoDestruir){
     IniciarAutoDestruicao();
     }
   }
    }

   public abstract EfeitoPowerUp EfeitoPowerUp {get;}

   public void Coletar(){
    Destroy(this.gameObject);
   }

   private void IniciarAutoDestruicao(){
   this.autodestruindo = true;
    StartCoroutine(Autodestruir());

   

   }

   private IEnumerator Autodestruir(){
    int contadorPiscadas = 0;
   do{
      

     this.spriteRenderer.enabled = !this.spriteRenderer.enabled;
// esperar um intervalo de tempo 

  yield return new WaitForSeconds(this.intervaloTempoEntrePiscadas);
  this.intervaloTempoEntrePiscadas -= contadorPiscadas * this.reducaoTempoEntrePiscadas;

    contadorPiscadas++;

   }while(contadorPiscadas < this.quantidadeTotalPiscadas);
   Destroy(this.gameObject);

 }

}



