﻿#pragma checksum "D:\FPTSEM3\ASM_SEM3_UWP\ASM_SEM3_UWP\navigation.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D74C8288FB764F16C798F55570665B99"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASM_SEM3_UWP
{
    partial class navigation : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_AdaptiveTrigger_MinWindowWidth(global::Windows.UI.Xaml.AdaptiveTrigger obj, global::System.Double value)
            {
                obj.MinWindowWidth = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class navigation_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            Inavigation_Bindings
        {
            private global::ASM_SEM3_UWP.navigation dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.AdaptiveTrigger obj9;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj9MinWindowWidthDisabled = false;

            public navigation_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 106 && columnNumber == 25)
                {
                    isobj9MinWindowWidthDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 9: // navigation.xaml line 105
                        this.obj9 = (global::Windows.UI.Xaml.AdaptiveTrigger)target;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // Inavigation_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::ASM_SEM3_UWP.navigation)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::ASM_SEM3_UWP.navigation obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_NavView(obj.NavView, phase);
                    }
                }
            }
            private void Update_NavView(global::Windows.UI.Xaml.Controls.NavigationView obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_NavView_CompactModeThresholdWidth(obj.CompactModeThresholdWidth, phase);
                    }
                }
            }
            private void Update_NavView_CompactModeThresholdWidth(global::System.Double obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // navigation.xaml line 105
                    if (!isobj9MinWindowWidthDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_AdaptiveTrigger_MinWindowWidth(this.obj9, obj);
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // navigation.xaml line 49
                {
                    this.NavView = (global::Windows.UI.Xaml.Controls.NavigationView)(target);
                    ((global::Windows.UI.Xaml.Controls.NavigationView)this.NavView).Loaded += this.NavView_Loaded;
                    ((global::Windows.UI.Xaml.Controls.NavigationView)this.NavView).ItemInvoked += this.NavView_ItemInvoked;
                    ((global::Windows.UI.Xaml.Controls.NavigationView)this.NavView).BackRequested += this.NavView_BackRequested;
                }
                break;
            case 3: // navigation.xaml line 69
                {
                    this.MainPagesHeader = (global::Windows.UI.Xaml.Controls.NavigationViewItemHeader)(target);
                }
                break;
            case 4: // navigation.xaml line 71
                {
                    this.infomation = (global::Windows.UI.Xaml.Controls.NavigationViewItem)(target);
                }
                break;
            case 5: // navigation.xaml line 73
                {
                    this.music2 = (global::Windows.UI.Xaml.Controls.NavigationViewItem)(target);
                }
                break;
            case 6: // navigation.xaml line 85
                {
                    this.Login2 = (global::Windows.UI.Xaml.Controls.NavigationViewItem)(target);
                }
                break;
            case 7: // navigation.xaml line 86
                {
                    this.LogOut = (global::Windows.UI.Xaml.Controls.NavigationViewItem)(target);
                }
                break;
            case 8: // navigation.xaml line 96
                {
                    this.ContentFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                    ((global::Windows.UI.Xaml.Controls.Frame)this.ContentFrame).NavigationFailed += this.ContentFrame_NavigationFailed;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // navigation.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    navigation_obj1_Bindings bindings = new navigation_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

