using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityEditor.UI
{


    [CustomEditor(typeof(UIBehaviour), true)]
    [CanEditMultipleObjects]
    public class UIBehaviourEditor : Editor
    {
        public void OnSceneGUI()
        {
            if (Selection.objects.Length > 1) return;

            UIBehaviour baseRect = target as UIBehaviour;

            Event e = Event.current;
            int id = GUIUtility.GetControlID(FocusType.Passive);
            EventType type = e.GetTypeForControl(id);




            if (type == EventType.MouseUp)
            {
                if (e.button == 1)
                {
                    MenuOptions.ShowAddMenu(baseRect.gameObject);
                    e.Use();
                }
            }
        }

    }
}
