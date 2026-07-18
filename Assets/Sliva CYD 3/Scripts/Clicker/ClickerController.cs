using UnityEngine;

namespace SlivaCYD3.Clicker
{
    public class ClickerController : MonoBehaviour
    {
        private ClickerModel model;
        
        public void Initialize(ClickerModel model)
        {
            this.model = model;
        }
        
        public void OnClick()
        {
            model.RegisterClick();
        }
    }
}