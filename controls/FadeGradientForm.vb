Option Explicit On
Option Strict On
Option Infer Off

Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Drawing

#Region " FadeGradientForm "

<DebuggerStepThrough()> _
Public Class FadeGradientForm
    Inherits System.Windows.Forms.Form

#Region " Variables "

    Private m_GradientBegin, m_GradientMiddle, m_GradientEnd As Drawing.Color
    Private m_GradientEnabled As Boolean
    Private m_GradientOrientation As GradientOrientation
    Private m_GradientPreset As GradientPresets

    Private m_OfficeColors As GradientColors

    Private m_UseFormFade As Boolean = True
    Private m_FormFadeDir As FadeDir
    Private m_FormHasFadedOut As Boolean

    Private WithEvents m_MdiClient As Windows.Forms.MdiClient

    Private WithEvents m_Timer As Timer

    Private Enum FadeDir
        FadeIn = 0I
        FadeOut = 1I
    End Enum

#Region " Events "

    Public Event GradientEnabledChanged As EventHandler
    Public Event GradientOrientationChanged As EventHandler
    Public Event GradientPresetChanged As EventHandler
    Public Event FadeEnabledChanged As EventHandler
    Public Event FadeSpeedChanged As EventHandler

#End Region

#End Region
#Region " Constructor, Dispose "

    Public Sub New()
        MyBase.New()
        MyBase.DoubleBuffered = True
        MyBase.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        m_Timer = New Timer With {.Interval = 30I}
        m_OfficeColors = New GradientColors
        m_GradientOrientation = GradientOrientation.Vertical
        m_GradientEnabled = False
        m_GradientPreset = GradientPresets.None
        Me.FadeSpeed = 10I
        Me.FadeEnabled = True
    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                m_Timer.Dispose()
            End If
        Finally
            m_Timer = Nothing
            MyBase.Dispose(disposing)
        End Try
    End Sub

#End Region
#Region " Form: OnFormClosing, OnLoad, OnPaint, OnResize, OnShown "

    Protected Overrides Sub OnFormClosing(ByVal e As System.Windows.Forms.FormClosingEventArgs)
        If m_UseFormFade AndAlso Not m_FormHasFadedOut AndAlso Not Me.DesignMode AndAlso Not Me.IsMdiChild Then
            m_FormFadeDir = FadeDir.FadeOut
            e.Cancel = True
            m_Timer.Start()
        End If
        MyBase.OnFormClosing(e)
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        Call MdiContainer()
        If m_UseFormFade AndAlso Not Me.DesignMode AndAlso Not Me.IsMdiChild Then
            m_FormFadeDir = FadeDir.FadeIn
            m_FormHasFadedOut = False
            Me.Opacity = 0.0R
        End If
    End Sub

    <DebuggerStepThrough()> _
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        HandlePaint(Me, e)
    End Sub

    Private Sub MdiClient_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles m_MdiClient.Paint
        HandlePaint(m_MdiClient, e)
    End Sub

    Private Sub HandlePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        If m_GradientEnabled Then

            Dim Wdth, Hght As Integer

            If sender.GetType Is GetType(MdiClient) Then
                Dim MDC As MdiClient = CType(sender, MdiClient)
                Hght = MDC.Height
                Wdth = MDC.Width
            Else
                Dim frm As Form = CType(sender, Form)
                Hght = frm.Height
                Wdth = frm.Width
            End If
            Select Case m_GradientOrientation
                Case GradientOrientation.Horizontal
                    If Wdth Mod 2 <> 0I Then Wdth -= 1I
                    If Wdth > 2I Then
                        Using b As New LinearGradientBrush(New Rectangle(0I, 0I, CInt(Wdth / 2I), Hght), m_GradientBegin, m_GradientMiddle, Drawing2D.LinearGradientMode.Horizontal)
                            e.Graphics.FillRectangle(b, New Rectangle(0I, 0I, CInt(Wdth / 2I), Hght))
                        End Using
                        Using b As New LinearGradientBrush(New Rectangle(CInt(Wdth / 2I) - 1I, 0I, Wdth, Hght), m_GradientMiddle, m_GradientEnd, Drawing2D.LinearGradientMode.Horizontal)
                            e.Graphics.FillRectangle(b, New Rectangle(CInt(Wdth / 2), 0I, Wdth, Hght))
                        End Using
                    End If
                Case GradientOrientation.Vertical
                    If Hght Mod 2 <> 0I Then Hght -= 1I
                    If Hght > 2I Then
                        Using b As New LinearGradientBrush(New Rectangle(0I, 0I, Wdth, CInt(Hght / 2I)), m_GradientBegin, m_GradientMiddle, Drawing2D.LinearGradientMode.Vertical)
                            e.Graphics.FillRectangle(b, New Rectangle(0I, 0I, Wdth, CInt(Hght / 2I)))
                        End Using
                        Using b As New LinearGradientBrush(New Rectangle(0I, CInt(Hght / 2I) - 1I, Wdth, Hght), m_GradientMiddle, m_GradientEnd, Drawing2D.LinearGradientMode.Vertical)
                            e.Graphics.FillRectangle(b, New Rectangle(0I, CInt(Hght / 2), Wdth, Hght))
                        End Using
                    End If
            End Select
        End If
    End Sub

    <DebuggerStepThrough()> _
    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)
        Me.Refresh()
    End Sub

    Protected Overrides Sub OnShown(ByVal e As System.EventArgs)
        If m_UseFormFade AndAlso Not Me.DesignMode Then
            m_Timer.Start()
        Else
            MyBase.OnShown(e)
        End If
    End Sub

#End Region
#Region " Properties: Orientation, GradientEnabled, GradientBegin, GradientMiddle, GradientEnd, GradientPreset "

    <Browsable(True), DefaultValue("Vertical"), Category("Gradient")> _
    Public Property Orientation() As GradientOrientation
        Get
            Return m_GradientOrientation
        End Get
        Set(ByVal value As GradientOrientation)
            If m_GradientOrientation <> value Then
                m_GradientOrientation = value
                Call OnGradientOrientationChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(True), Category("Gradient")> _
    Public Property GradientEnabled() As Boolean
        Get
            Return m_GradientEnabled
        End Get
        Set(ByVal value As Boolean)
            If m_GradientEnabled <> value Then
                m_GradientEnabled = value
                Call OnGradientEnabledChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    <Browsable(True), Category("Gradient")> _
    Public Property GradientBegin() As Color
        Get
            Return m_GradientBegin
        End Get
        Set(ByVal value As Color)
            If m_GradientBegin <> value Then
                m_GradientBegin = value
                m_GradientPreset = GradientPresets.Custom
                Me.Refresh()
            End If
        End Set
    End Property

    <Browsable(True), Category("Gradient")> _
    Public Property GradientMiddle() As Color
        Get
            Return m_GradientMiddle
        End Get
        Set(ByVal value As Color)
            If m_GradientMiddle <> value Then
                m_GradientMiddle = value
                m_GradientPreset = GradientPresets.Custom
                Me.Refresh()
            End If
        End Set
    End Property

    <Browsable(True), Category("Gradient")> _
    Public Property GradientEnd() As Color
        Get
            Return m_GradientEnd
        End Get
        Set(ByVal value As Color)
            If m_GradientEnd <> value Then
                m_GradientEnd = value
                m_GradientPreset = GradientPresets.Custom
                Me.Refresh()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue("None"), Category("Gradient")> _
    Public Property GradientPreset() As GradientPresets
        Get
            Return m_GradientPreset
        End Get
        Set(ByVal value As GradientPresets)
            If m_GradientPreset <> value Then
                m_GradientPreset = value
                Me.GradientEnabled = (value <> GradientPresets.None)
                Select Case value
                    Case GradientPresets.Office2003Blue
                        m_GradientBegin = m_OfficeColors.Office2003BlueGradientBegin
                        m_GradientMiddle = m_OfficeColors.Office2003BlueGradientMiddle
                        m_GradientEnd = m_OfficeColors.Office2003BlueGradientEnd
                    Case GradientPresets.Office2003Olive
                        m_GradientBegin = m_OfficeColors.Office2003OliveGradientBegin
                        m_GradientMiddle = m_OfficeColors.Office2003OliveGradientMiddle
                        m_GradientEnd = m_OfficeColors.Office2003OliveGradientEnd
                    Case GradientPresets.Office2003Silver
                        m_GradientBegin = m_OfficeColors.Office2003SilverGradientBegin
                        m_GradientMiddle = m_OfficeColors.Office2003SilverGradientMiddle
                        m_GradientEnd = m_OfficeColors.Office2003SilverGradientEnd
                    Case GradientPresets.Office2007
                        m_GradientBegin = m_OfficeColors.Office2007GradientBegin
                        m_GradientMiddle = m_OfficeColors.Office2007GradientMiddle
                        m_GradientEnd = m_OfficeColors.Office2007GradientEnd
                    Case GradientPresets.OfficeClassic
                        m_GradientBegin = m_OfficeColors.OfficeClassicGradientBegin
                        m_GradientMiddle = m_OfficeColors.OfficeClassicGradientMiddle
                        m_GradientEnd = m_OfficeColors.OfficeClassicGradientEnd
                    Case GradientPresets.OfficeXP
                        m_GradientBegin = m_OfficeColors.OfficeXPGradientBegin
                        m_GradientMiddle = m_OfficeColors.OfficeXPGradientMiddle
                        m_GradientEnd = m_OfficeColors.OfficeXPGradientEnd
                    Case GradientPresets.None
                        m_GradientBegin = SystemColors.Control
                        m_GradientMiddle = SystemColors.Control
                        m_GradientEnd = SystemColors.Control
                End Select
                Me.Refresh()
                Call OnGradientPresetChanged(EventArgs.Empty)
            End If
        End Set
    End Property

#End Region
#Region " Properties: FadeEnabled, FadeSpeed "

    <DefaultValue(True), Description("Toggles whether the form fades in/out when opening/closing."), Category("FadeEffects")> _
    Public Property FadeEnabled() As Boolean
        Get
            Return m_UseFormFade
        End Get
        Set(ByVal value As Boolean)
            If Not Me.IsMdiChild Then
                If m_UseFormFade <> value Then
                    m_UseFormFade = value
                    Call OnFadeEnabledChanged(EventArgs.Empty)
                End If
            Else
                m_UseFormFade = False
                Throw New ArgumentException("An MDI child cannot use the fade feature")
            End If
        End Set
    End Property

    <DefaultValue(30I), Description("The speed in miliseconds the form fades in/out when opening/closing."), Category("FadeEffects")> _
    Public Property FadeSpeed() As Integer
        Get
            Return CInt(m_Timer.Interval)
        End Get
        Set(ByVal value As Integer)
            If value >= 10I Then
                If m_Timer.Interval <> value Then
                    m_Timer.Interval = value
                    Call OnFadeSpeedChanged(EventArgs.Empty)
                End If
            Else
                Throw New ArgumentException("A value less than 10 was passed in", "FadeSpeed")
            End If
        End Set
    End Property
#End Region
#Region " Shadows: IsMdiContainer "

    Public Shadows Property IsMdiContainer() As Boolean
        Get
            Return MyBase.IsMdiContainer
        End Get
        Set(ByVal value As Boolean)
            MyBase.IsMdiContainer = value
            Call MdiContainer()
        End Set
    End Property

#End Region
#Region " EventHandlers: OnGradientEnabledChanged, OnGradientOrientationChanged, OnGradientPresetChanged "

    Protected Sub OnGradientEnabledChanged(ByVal e As System.EventArgs)
        RaiseEvent GradientEnabledChanged(Me, e)
        Me.Refresh()
    End Sub

    Protected Sub OnGradientOrientationChanged(ByVal e As System.EventArgs)
        RaiseEvent GradientOrientationChanged(Me, e)
        Me.Refresh()
    End Sub

    Protected Sub OnGradientPresetChanged(ByVal e As System.EventArgs)
        RaiseEvent GradientPresetChanged(Me, e)
        Me.Refresh()
    End Sub

#End Region
#Region " EventHandlers: OnFadeEnabledChanged, OnFadeSpeedChanged "

    Protected Sub OnFadeEnabledChanged(ByVal e As System.EventArgs)
        RaiseEvent FadeEnabledChanged(Me, e)
    End Sub

    Protected Sub OnFadeSpeedChanged(ByVal e As System.EventArgs)
        RaiseEvent FadeSpeedChanged(Me, e)
    End Sub

#End Region
#Region " Timer_Tick "

    <DebuggerStepThrough()> _
    Private Sub FormFadeTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_Timer.Tick
        Select Case m_FormFadeDir
            Case FadeDir.FadeIn
                Me.Opacity += 0.05R
            Case Else
                Me.Opacity -= 0.05R
        End Select
        If Me.Opacity <= 0.0R OrElse Me.Opacity >= 1.0R Then
            m_Timer.Stop()
            If m_FormFadeDir = FadeDir.FadeIn Then
                m_FormFadeDir = FadeDir.FadeOut
                m_FormHasFadedOut = False
                MyBase.OnShown(e)
            Else
                m_FormHasFadedOut = True
                Me.Close()
            End If
        End If
    End Sub

#End Region
#Region " GradientColors "

    <DebuggerStepThrough()> _
    Private Class GradientColors

        Public Sub New()

        End Sub

        Public ReadOnly Property Office2007GradientBegin() As Color
            Get
                Return Color.FromArgb(227I, 239I, 255I)
            End Get
        End Property

        Public ReadOnly Property Office2007GradientMiddle() As Color
            Get
                Return Color.FromArgb(218I, 234I, 255I)
            End Get
        End Property

        Public ReadOnly Property Office2007GradientEnd() As Color
            Get
                Return Color.FromArgb(177I, 211I, 255I)
            End Get
        End Property

        Public ReadOnly Property Office2003BlueGradientBegin() As Color
            Get
                Return Color.FromArgb(225I, 237I, 255I) 'Color.FromArgb(227I, 239I, 255I)
            End Get
        End Property

        Public ReadOnly Property Office2003BlueGradientMiddle() As Color
            Get
                Return Color.FromArgb(203I, 225I, 252I) 'Color.FromArgb(203I, 225I, 252I)
            End Get
        End Property

        Public ReadOnly Property Office2003BlueGradientEnd() As Color
            Get
                Return Color.FromArgb(123I, 164I, 215I) 'Color.FromArgb(123I, 164I, 224I)
            End Get
        End Property

        Public ReadOnly Property Office2003SilverGradientBegin() As Color
            Get
                Return Color.FromArgb(249I, 249I, 255I)
            End Get
        End Property

        Public ReadOnly Property Office2003SilverGradientMiddle() As Color
            Get
                Return Color.FromArgb(225I, 226I, 236I)
            End Get
        End Property

        Public ReadOnly Property Office2003SilverGradientEnd() As Color
            Get
                Return Color.FromArgb(147I, 145I, 176I)
            End Get
        End Property

        Public ReadOnly Property Office2003OliveGradientBegin() As Color
            Get
                Return Color.FromArgb(255I, 255I, 237I)
            End Get
        End Property

        Public ReadOnly Property Office2003OliveGradientMiddle() As Color
            Get
                Return Color.FromArgb(206I, 220I, 167I)
            End Get
        End Property

        Public ReadOnly Property Office2003OliveGradientEnd() As Color
            Get
                Return Color.FromArgb(181I, 196I, 143I)
            End Get
        End Property

        Public ReadOnly Property OfficeXPGradientBegin() As Color
            Get
                Return Color.FromArgb(252I, 252I, 252I)
            End Get
        End Property

        Public ReadOnly Property OfficeXPGradientMiddle() As Color
            Get
                Return Color.FromArgb(245I, 244I, 246I)
            End Get
        End Property

        Public ReadOnly Property OfficeXPGradientEnd() As Color
            Get
                Return Color.FromArgb(235I, 233I, 237I)
            End Get
        End Property

        Public ReadOnly Property OfficeClassicGradientBegin() As Color
            Get
                Return Color.FromArgb(245I, 244I, 242I)
            End Get
        End Property

        Public ReadOnly Property OfficeClassicGradientMiddle() As Color
            Get
                Return Color.FromArgb(234I, 232I, 228I)
            End Get
        End Property

        Public ReadOnly Property OfficeClassicGradientEnd() As Color
            Get
                Return Color.FromArgb(212I, 208I, 200I)
            End Get
        End Property

    End Class

#End Region
#Region " MdiContainer "

    Private Sub MdiContainer()
        If MyBase.IsMdiContainer Then
            For Each ctl As Control In Me.Controls
                If TypeOf ctl Is MdiClient Then
                    m_MdiClient = DirectCast(ctl, MdiClient)
                    Dim t As Type = GetType(MdiClient)
                    Dim method As MethodInfo = t.GetMethod("SetStyle", BindingFlags.Instance Or BindingFlags.NonPublic)
                    method.Invoke(m_MdiClient, New Object() {ControlStyles.AllPaintingInWmPaint, True})
                    method.Invoke(m_MdiClient, New Object() {ControlStyles.ResizeRedraw, True})
                    method.Invoke(m_MdiClient, New Object() {ControlStyles.UserPaint, True})
                    method.Invoke(m_MdiClient, New Object() {ControlStyles.DoubleBuffer, True})
                End If
            Next ctl
        Else
            m_MdiClient = Nothing
        End If
    End Sub

#End Region

End Class

#End Region
#Region " GradientOrientation "

Public Enum GradientOrientation
    Horizontal = 0I
    Vertical = 1I
End Enum

#End Region
#Region " GradientPresets "

Public Enum GradientPresets
    Custom = 0I
    None = 1I
    Office2007 = 2I
    Office2003Blue = 3I
    Office2003Silver = 4I
    Office2003Olive = 5I
    OfficeXP = 6I
    OfficeClassic = 7I
End Enum

#End Region