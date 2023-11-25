using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Entities.Player.UserInterface
{
    public class Drops : MonoBehaviour
    {
        // TODO: Make major refactor of this class
        
        [SerializeField] private int MinDelusion;
        [SerializeField] private int MaxDelusion;
        [SerializeField] private int MinMoney;
        [SerializeField] private int MaxMoney;
    
        [SerializeField] private float MinLight;
        [SerializeField] private float MaxLight;
    
        [SerializeField] private int delusian;
        [SerializeField] private int money;

        public TextMeshProUGUI text;

        private void FixedUpdate()
        {
            text.text = money.ToString();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Delusian")
            {
                int random = Random.Range(MinDelusion, MaxDelusion);
                delusian += random;
                Destroy(other.gameObject);
            }

            if (other.gameObject.tag == "Light")
            {
                float random = Random.Range(MinLight, MaxLight);
                //Heal.health += random;
                Destroy(other.gameObject);
            }

            if (other.gameObject.tag == "Money")
            {
                int random = Random.Range(MinMoney, MaxMoney);
                money += random;
                Destroy(other.gameObject);
            }
        }
    }
}

