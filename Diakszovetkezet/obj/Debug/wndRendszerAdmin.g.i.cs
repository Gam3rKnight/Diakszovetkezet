<<<<<<< HEAD
﻿#pragma checksum "..\..\wndRendszerAdmin.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A1DFED8B460354A9336C8EA0B0771F0B54435359"
=======
<<<<<<< HEAD
﻿#pragma checksum "..\..\wndRendszerAdmin.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "307075AB3780A9533ADBE6A94E6F3D9AD05CDBB5"
=======
﻿#pragma checksum "..\..\wndRendszerAdmin.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5DF80D9FB2C9BAA6E10F5279B8A77DBE795EF962"
>>>>>>> Béla
>>>>>>> master
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Diakszovetkezet;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Diakszovetkezet {
    
    
    /// <summary>
    /// wndRendszerAdmin
    /// </summary>
    public partial class wndRendszerAdmin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\wndRendszerAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tiMunkak;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\wndRendszerAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvMunkaLista;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\wndRendszerAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tiDiakok;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\wndRendszerAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tiMunkaDiak;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\wndRendszerAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.StatusBar sbAdatSav;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Diakszovetkezet;component/wndrendszeradmin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\wndRendszerAdmin.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 22 "..\..\wndRendszerAdmin.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tiMunkak = ((System.Windows.Controls.TabItem)(target));
            return;
            case 3:
            this.lvMunkaLista = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.tiDiakok = ((System.Windows.Controls.TabItem)(target));
            return;
            case 5:
            this.tiMunkaDiak = ((System.Windows.Controls.TabItem)(target));
            return;
            case 6:
            this.sbAdatSav = ((System.Windows.Controls.Primitives.StatusBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

