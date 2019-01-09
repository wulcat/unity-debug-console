
using UnityEngine;
using UnityEngine.UI ;

namespace Wulcat.Support {
	#region Enums
		public enum Species {
			Debug , Warning , Error
		}
	#endregion


	public class Support : MonoBehaviour {
		#region Variables
			public static GameObject _textObject ;
			public static Transform _transform ;
		#endregion

		#region MonoBehaviour Functions
			private void Awake() {
				_textObject = transform.GetChild(0).gameObject ;
				_transform = transform ;
			}
		#endregion

		#region Functions
			#region Log Overloads
				public static void Log(string message) {
					var clone = GameObject.Instantiate(_textObject).transform ;
					clone.SetParent(_transform) ;
					clone.GetComponent<Text>().text = message ;
					clone.gameObject.SetActive(true) ;
				}
				public static void Log(Species type , string message) {
					var clone = GameObject.Instantiate(_textObject).transform ;
					clone.SetParent(_transform) ;
					clone.gameObject.SetActive(true) ;

					var textRef = clone.GetComponent<Text>() ;
					textRef.text = message ;

					switch(type) {
						case Species.Debug :
							textRef.color = Color.green ;
							break ;
						case Species.Warning :
							textRef.color = Color.yellow ;
							break ;
						case Species.Error :
							textRef.color = Color.red ;
							break ;
						default :
							break ;
					}
				}
			#endregion
		#endregion
	}
}
