using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements;

namespace  JugglingFelix
{
    public class Controller : MonoBehaviour
    {
        private float MoveSpeed = 10f;

        private int Direction;
        
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            switch (transform.position.x)
            {
                // Fix wall intersecting and early out
                case < -2.45f:
                    transform.position = new Vector3(-2.45f, -2.29f);
                    return;
                case > 0.86f:
                    transform.position = new Vector3(0.86f, -2.29f);
                    return;
            }
            
            // Reset move direction if no key down, early out because we don't move the character
            if (!Input.anyKey) 
            {
                Direction = 0;
                return;
            }

            // Update direction and position
            if (Input.GetKeyDown(KeyCode.A))
            {
                Direction = -1;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Direction = 1;
            }
            
            
            float newDirX = MoveSpeed * Direction;

            transform.position += new Vector3(newDirX, 0f) * Time.deltaTime;
        }
    }
}
