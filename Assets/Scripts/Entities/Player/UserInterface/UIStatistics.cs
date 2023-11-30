using Resources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Entities.Player.UserInterface
{
    public class UIStatistics : MonoBehaviour
    {
        [SerializeField] private Image HealthBar;
        [SerializeField] private Image DelusionBar;
        [SerializeField] private TextMeshProUGUI MoneyText;
        
        public void SetHealth(float health)
        {
            HealthBar.fillAmount = Mathf.Clamp(health / 100f, 0f, 1f);
        }
        
        public void SetDelusion(float delusion)
        {
            DelusionBar.fillAmount = Mathf.Clamp(delusion / 100f, 0f, 1f);
        }
        
        public void SetMoney(int money)
        {
            MoneyText.text = money.ToString();
        }
        
        public void Setup(float health, float delusion, int money)
        {
            SetHealth(health);
            SetDelusion(delusion);
            SetMoney(money);
        }
        
        public void SetResource(ResourceType resourceType, int amount)
        {
            switch (resourceType)
            {
                case ResourceType.Delusion:
                    SetDelusion(amount);
                    break;
                case ResourceType.Money:
                    SetMoney(amount);
                    break;
            }
        }
    }
}