using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

namespace AirFramework.Editor
{
    
    public class FrameworkEditor : OdinMenuEditorWindow
    {
        [SerializeField]
        RuntimeConfig config_runtime;

        [SerializeField]
        EditorConfig config_editor;

        [MenuItem("Framework/Open")]
        public static void Open()
        {
            if (Application.isPlaying)
            {
                "It is not allowed to open the frame panel at runtime, but you can run it after opening the panel, but this may cause unexpected errors".E();
                return;
            }

            var window = GetWindow<FrameworkEditor>();
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 600);
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree(supportsMultiSelect: false);
            tree.Add("关于", new About(),EditorIcons.Info);
            tree.Add("日志管理",new LogSettings(config_runtime),EditorIcons.SettingsCog);
            tree.Add("UI代码生成", new MVVMCodeGenerate(),EditorIcons.Flag);
            return tree;
        }



        private static RuntimeConfig instance_Config = null;
        public static RuntimeConfig RuntimeGetRuntimeConfig()
        {

            if (instance_Config == null)
            {
                instance_Config  = Resources.Load<RuntimeConfig>("RuntimeInfo");
            }
            return instance_Config;
        }
       
    }
}
