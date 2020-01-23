using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts {
    public class Character : MonoBehaviour {

        public float moveSpeed = 1 ;
        protected Vector2 target;

        public void SetTarget(Vector2 _target) {
            target = _target;

        }

        public void SetStop() {
            target = transform.position;
        }

        private void Start() {
            SetTarget(this.transform.position);
        }

        private void Update() {
            var rbody = GetComponent<Rigidbody2D>();
            if (rbody != null) {
                rbody.MovePosition(Vector2.MoveTowards(transform.position, target, Time.deltaTime * moveSpeed));
            }
        }
    }
}
