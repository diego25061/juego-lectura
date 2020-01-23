using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.LevelLogics {

    public class LevelLogic_1 : LevelLogic {

        private bool applePicked = false;
        private bool bucketPicked = false;
        private bool waterBucketPicked = false;
        public GameObject AppleItemImage;
        public GameObject BucketItemImage;
        public GameObject BucketItemFilledImage;
        public GameObject MenuItem;
        public Text guideText;
        public string textApplePicked = "¡Has conseguido una manzana! Las manzanas son ricas en antioxidantes, en vitaminas B, vitaminas C y fosforo. Son saludables y no necesitan ser peladas para ser consumidas. Intenta dandolas a la yegua";
        public string textHorseFed = "¡La yegua ha comido la manzana con gusto! Esta le ayudara a seguir con sus tareas diarias. Sin embargo, ahora necesita tomar agua para hidratarse. Busca agua para ella";

        enum LevelPhase { FIRST, SECOND_HORSE_FED_APPLE, THIRD_FEED_HORSE }
        LevelPhase currentPhase = LevelPhase.FIRST;

        private void Start() {
            AppleItemImage.SetActive(false);
            BucketItemImage.SetActive(false);
        }

        public void ApplePicked(CharacterController character) {
            //Debug.Log("PICKING APPLE!");
            applePicked = true;
            AppleItemImage.SetActive(true);

            character.GetComponent<Character>().SetStop();
        }

        private void SetText(string text) {
            guideText.text = text;
        }


        public void BucketPicked() {
            bucketPicked = true;
            BucketItemImage.SetActive(true);
        }

        public void FeedHorse() {
            AppleItemImage.SetActive(false);
        }


        public override void CharacterInteraction(CharacterController character, Interactable interactable) {
            if (interactable != null && character != null) {
                Debug.Log("INTERACTING!");

                if (interactable.identifier == "apple") {


                    if (Vector2.Distance(character.transform.position, interactable.transform.position) <= interactable.interactDistance
                        && currentPhase == LevelPhase.FIRST) {
                        ApplePicked(character);
                        Destroy(interactable.gameObject, 0.1f);
                        SetText(textApplePicked);
                    } else {
                        var shaker = interactable.GetComponent<ShakerEffect>();
                        if (shaker != null) {
                            shaker.Shake();
                        }
                    }

                } else if (interactable.identifier == "bucket") {
                    if (Vector2.Distance(character.transform.position, interactable.transform.position) <= interactable.interactDistance
                        && currentPhase == LevelPhase.SECOND_HORSE_FED_APPLE) {
                        BucketPicked();
                        Destroy(interactable.gameObject, 0.1f);
                    } else {
                        var shaker = interactable.GetComponent<ShakerEffect>();
                        if (shaker != null) {
                            shaker.Shake();
                        }
                    }
                } else if (interactable.identifier == "horse") {
                    if (Vector2.Distance(character.transform.position, interactable.transform.position) <= interactable.interactDistance) {

                        if (currentPhase == LevelPhase.FIRST && applePicked) {
                            SetText(textHorseFed);
                            AppleItemImage.SetActive(false);
                            currentPhase = LevelPhase.SECOND_HORSE_FED_APPLE;
                        } else if (currentPhase == LevelPhase.SECOND_HORSE_FED_APPLE && bucketPicked) {
                            SetText("El balde esta vacio. Debes llenarlo con agua antes de darselo a la yegua");
                        } else if (currentPhase == LevelPhase.SECOND_HORSE_FED_APPLE && waterBucketPicked && !bucketPicked) {
                            SetText("¡Buen trabajo! Has alimentado a la yegua. Ahora está lista para sus actividades diarias");
                            Invoke("OpenMenu", 1.5f);
                        }
                    }
                } else if (interactable.identifier == "water") {
                    if (Vector2.Distance(character.transform.position, interactable.transform.position) <= interactable.interactDistance) {
                        if (currentPhase == LevelPhase.SECOND_HORSE_FED_APPLE && bucketPicked) {
                            SetText("Has llenado el balde de agua. El agua de los pozos artificiales proviene del subsuelo y es naturalmente filtrada por rocas de diversos tamaños. Esta puede ser consumida sin problemas por personas y animales.");
                            waterBucketPicked = true;
                            bucketPicked = false;
                            BucketItemImage.SetActive(false);
                            BucketItemFilledImage.SetActive(true);

                        }
                    }

                }

            }
        }

        public void OpenMenu() {
            MenuItem.SetActive(true);
            FindObjectOfType<CharacterController>().ForbidInteraction();
        }

    }
}
