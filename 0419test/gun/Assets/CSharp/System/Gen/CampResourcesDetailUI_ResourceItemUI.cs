using UnityEngine;
using UnityEngine.UI;

namespace EZ {

	public partial class CampResourcesDetailUI_ResourceItemUI : MonoBehaviour {

		[SerializeField]
		private RectTransform_Text_Container m_IName;
		public RectTransform_Text_Container IName { get { return m_IName; } }

		[SerializeField]
		private RectTransform_Image_Container m_Materials;
		public RectTransform_Image_Container Materials { get { return m_Materials; } }

		[SerializeField]
		private RectTransform_Image_Container m_Progress;
		public RectTransform_Image_Container Progress { get { return m_Progress; } }

		[SerializeField]
		private RectTransform_Text_Container m_Amount;
		public RectTransform_Text_Container Amount { get { return m_Amount; } }

		[SerializeField]
		private RectTransform_Text_Container m_ConsumeADayAmount;
		public RectTransform_Text_Container ConsumeADayAmount { get { return m_ConsumeADayAmount; } }

		[SerializeField]
		private RectTransform_Text_Container m_MaintainedDaysAmount;
		public RectTransform_Text_Container MaintainedDaysAmount { get { return m_MaintainedDaysAmount; } }

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

		[System.Serializable]
		public class RectTransform_Text_Container {

			[SerializeField]
			private GameObject m_GameObject;
			public GameObject gameObject { get { return m_GameObject; } }

			[SerializeField]
			private RectTransform m_rectTransform;
			public RectTransform rectTransform { get { return m_rectTransform; } }

			[SerializeField]
			private Text m_text;
			public Text text { get { return m_text; } }

		}

	}

}
