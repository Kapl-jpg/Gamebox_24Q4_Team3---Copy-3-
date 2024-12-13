using UnityEngine;
using Zenject;

namespace Player
{
    public class TrypophobiaMirror : MonoBehaviour
    {
        [SerializeField] private float maxLookTimer;
        [SerializeField] private SkinnedMeshRenderer[] skins;
        private InputManager _inputManager;
        private float _lookTimer = 1f;
        
        [Inject]
        private void Construct(InputManager inputManager)
        {
            _inputManager = inputManager;
        }

        private void Start()
        {
            for (int i = 0; i < skins.Length; i++)
            {
                var materials = skins[i].materials;
                for (int j = 0; j < materials.Length; j++)
                {
                    var mat = new Material(skins[i].materials[j]);
                    skins[i].materials[j] = mat;
                }
            }
        }

        private void Update()
        {
            if (_inputManager.IsUsingMirror())
            {
                _lookTimer = Mathf.Clamp01(_lookTimer - Time.deltaTime / maxLookTimer);
                foreach (var skin in skins)
                {
                    var mats = skin.materials;
                    foreach (var mat in mats)
                    {
                        mat.SetFloat("_DissolveValue",_lookTimer);
                    }
                }
            }
        }
    }
}
