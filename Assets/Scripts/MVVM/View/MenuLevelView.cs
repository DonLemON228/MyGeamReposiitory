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
            m_sceneLoadService = ServiceLocator.Resolve<SceneLoadService>();
            m_lvlSaveService = ServiceLocator.Resolve<LevelSaveService>();

            if (m_lvlSaveService.GetLvlProgres(m_sceneEnum) == false)
                BlockLevel(true);
            else
                BlockLevel(false);


            m_startButton.onClick.AddListener(OpenLevel);
        }

        public void OpenLevel()
        {
            m_sceneLoadService.LoadScene(m_sceneEnum);
        }

        public void BlockLevel(bool _isBlocking)
        {
            m_blockingObject.SetActive(_isBlocking);
        }
    }
}