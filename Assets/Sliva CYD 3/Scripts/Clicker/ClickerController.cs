using UnityEngine;
using VContainer;

namespace SlivaCYD3.Clicker
{
    public class ClickerController : MonoBehaviour
    {
        [Inject] private ClickerModel model;
        
        public void OnClick()
        {
            model.RegisterClick();
        }
    }
}