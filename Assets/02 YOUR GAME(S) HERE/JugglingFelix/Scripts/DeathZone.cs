using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace JugglingFelix
{
    public class DeathZone : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Collides as it should
            
            if (other.gameObject.name == "Ball")
            {
                // Lose game
                GoFelixManager.Instance.win = false;

                Debug.Log($"Manager win status: {GoFelixManager.Instance.win}");
                
                Destroy(other.gameObject);
            }
        }
    }
}
