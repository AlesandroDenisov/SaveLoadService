using HomoLudens.Core;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace HomoLudens.Services.SaveLoad
{
    [RequireComponent(typeof(Collider2D))]
    public class SaveTrigger : MonoBehaviour
    {
        private IAsyncSaveLoadService _asyncSaveLoadService;
    
        [Inject]
        private void Construct(IAsyncSaveLoadService asyncSaveLoadService)
        {
            _asyncSaveLoadService = asyncSaveLoadService;
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                _asyncSaveLoadService.SaveProgress();
            }
        }
    }
}