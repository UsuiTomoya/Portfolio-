  /*
  Fullscreen GameView Custom
  
  Create a new folder in your "Assets" folder named "Editor" and place this script to there.
  "Switch Game to Fullscreen" and "Auto Fullscreen at Play Mode" will shown on Window menu.
  Shortcut key:
     Toggle fullscreen   (Windows) F11       (Mac) Command + Shift + F
     Run/Stop play mode  (Windows) Ctrl + P  (Mac) Command + P
   
  The explanation in Japanese is as follows.
  
  
  GameViewをフルスクリーン切り替えするスクリプト
  
  Assetsフォルダの中にEditorという名前のフォルダを作り、そこへこのスクリプトを配置してください。
  UnityのWindowメニュー内に「Switch Game to Fullscreen」と「Auto Fullscreen at Play Mode」という
  メニューが追加されます。プレイモード実行時に自動的にフルスクリーン表示にさせたければ、
  「Auto Fullscreen at Play Mode」を選択してチェックを入れてください。
  
  ショートカットキー：
    フルスクリーン/ウィンドウ切り替え   (Windows) F11       (Mac) Command + Shift + F
    プレイモードの実行・停止            (Windows) Ctrl + P  (Mac) Command + P
  */
  
  
  /*
  MIT License
  
  Copyright (c) 2022 Sunao Hashimoto
  
  Permission is hereby granted, free of charge, to any person obtaining a copy
  of this software and associated documentation files (the "Software"), to deal
  in the Software without restriction, including without limitation the rights
  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
  copies of the Software, and to permit persons to whom the Software is
  furnished to do so, subject to the following conditions:
  
  The above copyright notice and this permission notice shall be included in all
  copies or substantial portions of the Software.
  
  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
  SOFTWARE.
  
   
  This code was written by modifying Chillu's FullscreenGameView.cs,
  which is subject to the same license.
  https://gist.github.com/Chillu1/4c209308dc81104776718b1735c639f7
  Here is the original copyright notice:
  
  MIT License
  
  Copyright (c) 2021 Chillu
  
  Permission is hereby granted, free of charge, to any person obtaining a copy
  of this software and associated documentation files (the "Software"), to deal
  in the Software without restriction, including without limitation the rights
  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
  copies of the Software, and to permit persons to whom the Software is
  furnished to do so, subject to the following conditions:
  
  The above copyright notice and this permission notice shall be included in all
  copies or substantial portions of the Software.
  
  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
  SOFTWARE.
  */
  
  
  #if UNITY_EDITOR
  
  using System;
  using System.Reflection;
  using UnityEditor;
  using UnityEngine;
  
  [InitializeOnLoad]
  public static class FullscreenGameView
  {
      private static readonly Type gameViewType = Type.GetType("UnityEditor.GameView,UnityEditor");
  
      private static readonly PropertyInfo showToolbarProperty =
          gameViewType.GetProperty("showToolbar", BindingFlags.Instance | BindingFlags.NonPublic);
  
      private static readonly object falseObject = false; // Only box once. This is a matter of principle.
      private static EditorWindow _instance;
  
      private static readonly bool fullscreen = true;
  
      private static bool isFullscreenAllowed = false; // add
  
      static FullscreenGameView()
      {
          EditorApplication.playModeStateChanged -= ToggleFullScreen;
          if (!fullscreen)
              return;
          EditorApplication.playModeStateChanged += ToggleFullScreen;
      }
  
      // modified -----
      const string menuPathToggle = "Window/Switch Game to Fullscreen";
  #if UNITY_EDITOR_WIN
      [MenuItem(menuPathToggle + " _F11", priority = 1)]     // F11 for Windows
  #elif UNITY_EDITOR_OSX
      [MenuItem(menuPathToggle + " %#f", priority = 1)]      // Command + Shift + F for Mac
  #endif
      // modified -----
      public static void Toggle()
      {
          isFullscreenAllowed = true; // add
          ToggleFullScreen(PlayModeStateChange.EnteredPlayMode);
      }
  
      // add -----
      const string menuPathAuto = "Window/Auto Fullscreen at Play Mode";
      [MenuItem(menuPathAuto, priority = 1)]
      public static void ToggleAutoFullscreen()
      {
          bool flag = Menu.GetChecked(menuPathAuto);
          Menu.SetChecked(menuPathAuto, !flag);
      }
      // add -----
  
      public static void ToggleFullScreen(PlayModeStateChange playModeStateChange)
      {
          // add -----
          bool auto_flag = Menu.GetChecked(menuPathAuto);
          if (!auto_flag && !isFullscreenAllowed)
          {
              return;
          }
          // add -----
  
          if (playModeStateChange == PlayModeStateChange.EnteredEditMode || playModeStateChange == PlayModeStateChange.ExitingEditMode)
          {
              CloseGameWindow();
              return;
          }
  
          if (gameViewType == null)
          {
              Debug.LogError("GameView type not found.");
              return;
          }
  
          if (showToolbarProperty == null)
          {
              Debug.LogWarning("GameView.showToolbar property not found.");
          }
  
          switch (playModeStateChange)
          {
              case PlayModeStateChange.ExitingPlayMode:
                  return;
              case PlayModeStateChange.EnteredPlayMode: //Used to toggle
                  if (CloseGameWindow())
                      return;
                  break;
          }
  
          _instance = (EditorWindow)ScriptableObject.CreateInstance(gameViewType);
  
          showToolbarProperty?.SetValue(_instance, falseObject);
  
          var desktopResolution = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
          var fullscreenRect = new Rect(Vector2.zero, desktopResolution);
          _instance.ShowPopup();
          _instance.position = fullscreenRect;
          _instance.Focus();
      }
  
      private static bool CloseGameWindow()
      {
          if (_instance != null)
          {
              _instance.Close();
              _instance = null;
              return true;
          }
  
          return false;
      }
  }
  #endif