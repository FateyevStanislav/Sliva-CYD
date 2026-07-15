using System;
using UnityEngine;

namespace SlivaCYD3.Clicker
{
    public class ClickerEntryPoint : MonoBehaviour
    {
        [SerializeField] private ClickerController controller;
        [SerializeField] private ClickerView view;
        
        private void Awake()
        {
            if (controller == null)
                throw new NullReferenceException("Clicker controller not set");
            
            if (view == null)
                throw new NullReferenceException("Clicker view not set");
            
            var model = new ClickerModel();
            controller.Initialize(model, view);
        }
    }
}