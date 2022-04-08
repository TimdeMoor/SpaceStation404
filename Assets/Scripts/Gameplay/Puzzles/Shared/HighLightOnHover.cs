using UnityEngine;

namespace Gameplay.Puzzles.Shared
{
    public class HighLightOnHover : MonoBehaviour
    {
        [SerializeField] private Color color;
        [SerializeField] private float outlineWidth = 1f;

        private Outline _outline;
        void Start()
        {
            _outline = gameObject.AddComponent<Outline>();
            _outline.OutlineColor = color;
            _outline.OutlineWidth = outlineWidth;
            _outline.OutlineMode = Outline.Mode.OutlineVisible;
            _outline.enabled = false;
        }

        void OnMouseEnter()
        {
            _outline.enabled = true;
        }

        void OnMouseExit()
        {
            _outline.enabled = false;
        }
    }
}
