﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On



<Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
 Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0"),  _
 Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
Partial Friend NotInheritable Class Settings
    Inherits Global.System.Configuration.ApplicationSettingsBase
    
    Private Shared defaultInstance As Settings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New Settings()),Settings)
    
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
    
    Public Shared ReadOnly Property [Default]() As Settings
        Get
            
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
            Return defaultInstance
        End Get
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("0, 0")>  _
    Public Property location() As Global.System.Drawing.Point
        Get
            Return CType(Me("location"),Global.System.Drawing.Point)
        End Get
        Set
            Me("location") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("837, 549")>  _
    Public Property size() As Global.System.Drawing.Size
        Get
            Return CType(Me("size"),Global.System.Drawing.Size)
        End Get
        Set
            Me("size") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("about:blank")>  _
    Public Property Icon4URL() As String
        Get
            Return CType(Me("Icon4URL"),String)
        End Get
        Set
            Me("Icon4URL") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("about:blank")>  _
    Public Property Icon5URL() As String
        Get
            Return CType(Me("Icon5URL"),String)
        End Get
        Set
            Me("Icon5URL") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("about:blank")>  _
    Public Property Icon7URL() As String
        Get
            Return CType(Me("Icon7URL"),String)
        End Get
        Set
            Me("Icon7URL") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("about:blank")>  _
    Public Property Icon6URL() As String
        Get
            Return CType(Me("Icon6URL"),String)
        End Get
        Set
            Me("Icon6URL") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property Icon2Load() As Boolean
        Get
            Return CType(Me("Icon2Load"),Boolean)
        End Get
        Set
            Me("Icon2Load") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property LoadInstagram() As Boolean
        Get
            Return CType(Me("LoadInstagram"),Boolean)
        End Get
        Set
            Me("LoadInstagram") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property LoadFacebook() As Boolean
        Get
            Return CType(Me("LoadFacebook"),Boolean)
        End Get
        Set
            Me("LoadFacebook") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property LoadLife360() As Boolean
        Get
            Return CType(Me("LoadLife360"),Boolean)
        End Get
        Set
            Me("LoadLife360") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property LoadCalendar() As Boolean
        Get
            Return CType(Me("LoadCalendar"),Boolean)
        End Get
        Set
            Me("LoadCalendar") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property LoadGoogle() As Boolean
        Get
            Return CType(Me("LoadGoogle"),Boolean)
        End Get
        Set
            Me("LoadGoogle") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property Startup() As Boolean
        Get
            Return CType(Me("Startup"),Boolean)
        End Get
        Set
            Me("Startup") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("about:blank")>  _
    Public Property Icon1URL() As String
        Get
            Return CType(Me("Icon1URL"),String)
        End Get
        Set
            Me("Icon1URL") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("about:blank")>  _
    Public Property Icon2URL() As String
        Get
            Return CType(Me("Icon2URL"),String)
        End Get
        Set
            Me("Icon2URL") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("about:blank")>  _
    Public Property Icon3URL() As String
        Get
            Return CType(Me("Icon3URL"),String)
        End Get
        Set
            Me("Icon3URL") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Icon1")>  _
    Public Property Icon1Name() As String
        Get
            Return CType(Me("Icon1Name"),String)
        End Get
        Set
            Me("Icon1Name") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Icon2")>  _
    Public Property Icon2Name() As String
        Get
            Return CType(Me("Icon2Name"),String)
        End Get
        Set
            Me("Icon2Name") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Icon3")>  _
    Public Property Icon3Name() As String
        Get
            Return CType(Me("Icon3Name"),String)
        End Get
        Set
            Me("Icon3Name") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Icon4")>  _
    Public Property Icon4Name() As String
        Get
            Return CType(Me("Icon4Name"),String)
        End Get
        Set
            Me("Icon4Name") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Icon5")>  _
    Public Property Icon5Name() As String
        Get
            Return CType(Me("Icon5Name"),String)
        End Get
        Set
            Me("Icon5Name") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Icon6")>  _
    Public Property Icon6Name() As String
        Get
            Return CType(Me("Icon6Name"),String)
        End Get
        Set
            Me("Icon6Name") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Icon7")>  _
    Public Property Icon7Name() As String
        Get
            Return CType(Me("Icon7Name"),String)
        End Get
        Set
            Me("Icon7Name") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property Icon1Image() As String
        Get
            Return CType(Me("Icon1Image"),String)
        End Get
        Set
            Me("Icon1Image") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property Icon2Image() As String
        Get
            Return CType(Me("Icon2Image"),String)
        End Get
        Set
            Me("Icon2Image") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property Icon3Image() As String
        Get
            Return CType(Me("Icon3Image"),String)
        End Get
        Set
            Me("Icon3Image") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property Icon4Image() As String
        Get
            Return CType(Me("Icon4Image"),String)
        End Get
        Set
            Me("Icon4Image") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property Icon5Image() As String
        Get
            Return CType(Me("Icon5Image"),String)
        End Get
        Set
            Me("Icon5Image") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property Icon6Image() As String
        Get
            Return CType(Me("Icon6Image"),String)
        End Get
        Set
            Me("Icon6Image") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property Icon7Image() As String
        Get
            Return CType(Me("Icon7Image"),String)
        End Get
        Set
            Me("Icon7Image") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property Icon3Load() As Boolean
        Get
            Return CType(Me("Icon3Load"),Boolean)
        End Get
        Set
            Me("Icon3Load") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property Icon4Load() As Boolean
        Get
            Return CType(Me("Icon4Load"),Boolean)
        End Get
        Set
            Me("Icon4Load") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property Icon5Load() As Boolean
        Get
            Return CType(Me("Icon5Load"),Boolean)
        End Get
        Set
            Me("Icon5Load") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property Icon6Load() As Boolean
        Get
            Return CType(Me("Icon6Load"),Boolean)
        End Get
        Set
            Me("Icon6Load") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property Icon7Load() As Boolean
        Get
            Return CType(Me("Icon7Load"),Boolean)
        End Get
        Set
            Me("Icon7Load") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("DevExpress Dark Style")>  _
    Public Property SkinName() As String
        Get
            Return CType(Me("SkinName"),String)
        End Get
        Set
            Me("SkinName") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property RoundedCorners() As Boolean
        Get
            Return CType(Me("RoundedCorners"),Boolean)
        End Get
        Set
            Me("RoundedCorners") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property CustomUserAgent() As String
        Get
            Return CType(Me("CustomUserAgent"),String)
        End Get
        Set
            Me("CustomUserAgent") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property UseCustomUserAgent() As Boolean
        Get
            Return CType(Me("UseCustomUserAgent"),Boolean)
        End Get
        Set
            Me("UseCustomUserAgent") = value
        End Set
    End Property
End Class

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.Jumble_v2.Settings
            Get
                Return Global.Jumble_v2.Settings.Default
            End Get
        End Property
    End Module
End Namespace