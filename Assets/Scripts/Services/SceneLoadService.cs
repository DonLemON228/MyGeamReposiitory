using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine.SceneManagement;

    public class SceneLoadService
    {
        private List<SceneInfo> m_scenes;

        public SceneLoadService(List<SceneInfo> _list)
        {
            m_scenes = _list;
        }
        
        public void LoadScene(SceneEnums _scene)
        {
            var loadingScene = m_scenes.FirstOrDefault(x => x.sceneEnum == _scene);
            
           if (loadingScene != null)
                SceneManager.LoadScene(loadingScene.scene.name);
        }
    }

    [Serializable]
    public class SceneInfo
    {
        public SceneEnums sceneEnum;
        public SceneAsset scene;
    }