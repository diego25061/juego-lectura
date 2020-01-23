using Assets.Scripts.LevelLogics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts {
    public class CharacterController : MonoBehaviour {

        private bool CanInteract = true;

        public void ForbidInteraction() {
            CanInteract = false;
        }

        private void Update() {
            foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Began) {
                    Touch(touch.position);
                }
            }
            if (Input.GetMouseButtonDown(0))
                Touch(Input.mousePosition);
        }

        private void Touch(Vector2 vector) {
            var pos = Camera.main.ScreenToWorldPoint(vector);

            var ray = Camera.main.ScreenPointToRay(vector);
            var casts = Physics2D.RaycastAll(ray.origin, ray.direction);

            //bool foundInteractable = false;
            Interactable interactable = null;
            if (CanInteract) {
                foreach (var cast in casts) {

                    if (cast.transform != null && cast.transform.gameObject != null) {
                        Debug.Log("ray cast hit -> " + cast.transform.gameObject.name);

                        interactable = cast.transform.gameObject.GetComponent<Interactable>();
                        if (interactable != null) {
                            break;
                            //foundInteractable = true;
                            //Debug.Log("found interactable!");

                        }

                    }

                }


                if (interactable != null) {
                    var lvlLogic = FindObjectOfType<LevelLogic>();
                    lvlLogic.CharacterInteraction(this, interactable);


                    //LevelLogic._instance.CharacterInteraction(this, interactable);
                    //interactable.Interact(this);
                    /*
                    {
                        if (Vector2.Distance(interactable.transform.position, this.transform.position) <= interactable.interactDistance) {

                        } else {

                        }
                    }
                    */
                } else {


                    //Debug.Log("Touched pos :" + vector + " , converted -> " + pos);
                }
                var characterComp = GetComponent<Character>();
                if (characterComp != null) {
                    characterComp.SetTarget(pos);
                }
            }

        }
    }
}