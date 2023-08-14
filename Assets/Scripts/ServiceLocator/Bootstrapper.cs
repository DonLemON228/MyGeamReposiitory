using System.Collections.Generic;
using UnityEngine;

    public class Bootstrapper: MonoBehaviour
    {
        [SerializeField] private List<SceneInfo> m_scenes;
        
        private void Awake()
        {
            var sceneLoadService = new SceneLoadService(m_scenes);
            var lvlSaveService = new LevelSaveService();

            ServiceLocator.Register<SceneLoadService>(sceneLoadService);
            ServiceLocator.Register<LevelSaveService>(lvlSaveService);
            
           var _lvlSaveService = ServiceLocator.Resolve<LevelSaveService>();
           _lvlSaveService.SaveLvlProgres(SceneEnums.Lvl1, true);

        DontDestroyOnLoad(this);
        }
    }