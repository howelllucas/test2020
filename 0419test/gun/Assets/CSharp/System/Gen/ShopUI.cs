using UnityEngine;
using UnityEngine.UI;

namespace EZ {

	public partial class ShopUI : BaseUi {

		[SerializeField]
		private RectTransform_Image_Container m_Viewport;
		public RectTransform_Image_Container Viewport { get { return m_Viewport; } }

		[SerializeField]
		private RectTransform_Container m_Content;
		public RectTransform_Container Content { get { return m_Content; } }

		[System.Serializable]
		public class RectTransform_Container {

			[SerializeField]
			private GameObject m_GameObject;
			public GameObject gameObject { get { return m_GameObject; } }

			[SerializeField]
			private RectTransform m_rectTransform;
			public RectTransform rectTransform { get { return m_rectTransform; } }

		}

		[System.Serializable]
		public class RectTransform_Image_Container {

			[SerializeField]
			private GameObject m_GameObject;
			public GameObject gameObject { get { return m_GameObject; } }

			[SerializeField]
			private RectTransform m_rectTransform;
			public RectTransform rectTransform { get { return m_rectTransform; } }

			[SerializeField]
			private Image m_image;
			public Image image { get { return m_image; } }

		}

	}

}