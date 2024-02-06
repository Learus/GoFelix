using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JugglingFelix
{
    public class Ball : MonoBehaviour
    {
        private float Speed = 10f;
        private Vector2 Direction;
        private float RotateSpeed = 300f;
        
        // Start is called before the first frame update
        void Start()
        {
            float xVelocity = 1f;
            float yVelocity = Random.Range(0.5f, 1f);

            if (Random.Range(0f, 1f) < 0.5f)
            {
                yVelocity *= -1f;
            }

            Direction = new Vector2(xVelocity, yVelocity).normalized;
        }

        // Update is called once per frame
        void Update()
        {
            var transf = transform;
            transf.position += new Vector3(Direction.x, Direction.y) * (Speed * Time.deltaTime);
            transf.Rotate(new Vector3(0f,0f, 1f), RotateSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            switch (other.gameObject.name)
            {
                case "Wall":
                    Direction.x *= -1;
                    break;
                case ("Paddle" or "Top"):
                    Direction.y *= -1;
                    break;
            }
        }
    }
}
