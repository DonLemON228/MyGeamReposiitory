using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MVVM.View
{
    public class MenuLevelView : MonoBehaviour
    {
        [SerializeField] private SceneEnums m_sceneEnum;
        [SerializeField] private Button m_startButton;
        [SerializeField] private GameObject m_blockingObject;

        private bool m_isAvailable;
        private SceneLoadService m_sceneLoadService;
        private LevelSaveService m_lvlSaveService;

        private void Start()
        {
            m_sceneLoadService = ServiceLocator.Resolve<SceneLoadService>(); //Приходит null в билде
            m_lvlSaveService = ServiceLocator.Resolve<LevelSaveService>(); //Приходит null в билде

            if (m_lvlSaveService.GetLvlProgres(m_sceneEnum) == false)
                BlockLevel(true);
            else
                BlockLevel(false);


            m_startButton.onClick.AddListener(OpenLevel);
        }

        public void OpenLevel()
        {
            Debug.Log($"SceneEnum - {m_sceneEnum}");
            Debug.Log($"SceneLoadService - {m_sceneLoadService}");
            Debug.Log($"LvlSaveService - {m_lvlSaveService}");
            m_sceneLoadService.LoadScene(m_sceneEnum);
        }

        public void BlockLevel(bool _isBlocking)
        {
            m_blockingObject.SetActive(_isBlocking);
        }
    }
}