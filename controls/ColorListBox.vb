Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class ColorListBox
    Inherits ListBox

#Region " Constructor "

    Public Sub New()
        Me.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        _Items = New ColorListBoxItemCollection(Me)

        _ShowImages = True
        _TextAlign = ContentAlignment.MiddleLeft
    End Sub

#End Region

#Region " Properties "

    Private _Items As ColorListBoxItemCollection
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Overloads ReadOnly Property Items() As ColorListBoxItemCollection
        Get
            Return _Items
        End Get
    End Property

    'The original items that the user will never see.
    Private ReadOnly Property baseItems() As ObjectCollection
        Get
            Return MyBase.Items
        End Get
    End Property

    Public Overloads Property SelectedItem() As ColorListBoxItem
        Get
            Return DirectCast(MyBase.SelectedItem, ColorListBoxItem)
        End Get
        Set(ByVal value As ColorListBoxItem)
            MyBase.SelectedItem = value
        End Set
    End Property

    Public Overloads ReadOnly Property SelectedItems() As ColorListBoxSelectedItemCollection
        Get
            Dim items As New ColorListBoxSelectedItemCollection()
            For Each item As Object In MyBase.SelectedItems
                items.Add(DirectCast(item, ColorListBoxItem))
            Next
            Return items
        End Get
    End Property

    Private _ShowImages As Boolean
    <DefaultValue(True)> _
    Public Property ShowImages() As Boolean
        Get
            Return _ShowImages
        End Get
        Set(ByVal value As Boolean)
            If _ShowImages <> value Then
                _ShowImages = value
                Me.Invalidate()
            End If
        End Set
    End Property

    Private _TextAlign As ContentAlignment
    <DefaultValue(ContentAlignment.MiddleLeft)> _
    Public Property TextAlign() As ContentAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As ContentAlignment)
            If _TextAlign <> value Then
                _TextAlign = value
                Me.Invalidate()
            End If
        End Set
    End Property

#End Region

#Region " Methods "

    Protected Overrides Sub OnDrawItem(ByVal e As System.Windows.Forms.DrawItemEventArgs)
        MyBase.OnDrawItem(e)

        'Draw original background and selection.
        'You can remove this and draw your own background if you want.
        e.DrawBackground()
        e.DrawFocusRectangle()

        If e.Index >= 0 AndAlso e.Index < Me.Items.Count Then
            Dim item As ColorListBoxItem = Me.Items(e.Index)
            If item IsNot Nothing Then
                e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                If Me.ShowImages _
                AndAlso item.Image IsNot Nothing Then
                    'Draw the image
                    e.Graphics.DrawImage(item.Image, _
                                         e.Bounds.X, _
                                         e.Bounds.Y, _
                                         Me.ItemHeight, _
                                         Me.ItemHeight)
                End If
            End If

            'Draw the item text
            DrawItemText(e, item)
        End If
    End Sub

    Private Sub DrawItemText(ByVal e As System.Windows.Forms.DrawItemEventArgs, ByVal item As ColorListBoxItem)
        Dim x, y As Single
        Dim textSize As SizeF = e.Graphics.MeasureString(item.Text, Me.Font)
        Dim w As Single = textSize.Width
        Dim h As Single = textSize.Height
        Dim bounds As Rectangle = e.Bounds

        'If we are showing images, make some room for them and adjust the bounds width.
        If Me.ShowImages Then
            bounds.X += Me.ItemHeight
            bounds.Width -= Me.ItemHeight
        End If

        'Depending on which TextAlign is chosen, determine the x and y position of the text.
        Select Case Me.TextAlign
            Case ContentAlignment.BottomCenter
                x = bounds.X + (bounds.Width - w) / 2
                y = bounds.Y + bounds.Height - h
            Case ContentAlignment.BottomLeft
                x = bounds.X
                y = bounds.Y + bounds.Height - h
            Case ContentAlignment.BottomRight
                x = bounds.X + bounds.Width - w
                y = bounds.Y + bounds.Height - h
            Case ContentAlignment.MiddleCenter
                x = bounds.X + (bounds.Width - w) / 2
                y = bounds.Y + (bounds.Height - h) / 2
            Case ContentAlignment.MiddleLeft
                x = bounds.X
                y = bounds.Y + (bounds.Height - h) / 2
            Case ContentAlignment.MiddleRight
                x = bounds.X + bounds.Width - w
                y = bounds.Y + (bounds.Height - h) / 2
            Case ContentAlignment.TopCenter
                x = bounds.X + (bounds.Width - w) / 2
                y = bounds.Y
            Case ContentAlignment.TopLeft
                x = bounds.X
                y = bounds.Y
            Case ContentAlignment.TopRight
                x = bounds.X + bounds.Width - w
                y = bounds.Y
        End Select

        'Finally draw the text.
        e.Graphics.DrawString(item.Text, Me.Font, New SolidBrush(item.Color), x, y)
    End Sub

#End Region

#Region " Nested classes "

    'A collection of ColorListBoxItems
    Public Class ColorListBoxItemCollection
        Inherits System.Collections.ObjectModel.Collection(Of ColorListBoxItem)

#Region " Fields "

        'Keep a reference to the ColorListBox so we can update its baseItems list
        Private _listBox As ColorListBox

#End Region

#Region " Constructor "

        Public Sub New(ByVal listBox As ColorListBox)
            _listBox = listBox
        End Sub

#End Region

#Region " Methods "

        Public Overloads Function Add(ByVal text As String) As ColorListBoxItem
            Return Me.Add(text, Color.Black, Nothing)
        End Function

        Public Overloads Function Add(ByVal text As String, ByVal color As Color) As ColorListBoxItem
            Return Me.Add(text, color, Nothing)
        End Function

        Public Overloads Function Add(ByVal text As String, ByVal color As Color, ByVal img As Image) As ColorListBoxItem
            Dim item As New ColorListBoxItem(text, color, img)
            Me.InsertItem(Me.Items.Count, item)
            Return item
        End Function

        Protected Overrides Sub ClearItems()
            MyBase.ClearItems()
            _listBox.baseItems.Clear()
        End Sub

        Protected Overrides Sub InsertItem(ByVal index As Integer, ByVal item As ColorListBoxItem)
            MyBase.InsertItem(index, item)
            _listBox.baseItems.Insert(index, item)
        End Sub

        Protected Overrides Sub RemoveItem(ByVal index As Integer)
            MyBase.RemoveItem(index)
            _listBox.baseItems.RemoveAt(index)
        End Sub

        Protected Overrides Sub SetItem(ByVal index As Integer, ByVal item As ColorListBoxItem)
            MyBase.SetItem(index, item)
            _listBox.baseItems(index) = item
        End Sub

        Public Sub AddRange(ByVal items As IEnumerable(Of ColorListBoxItem))
            For Each item As ColorListBoxItem In items
                Me.InsertItem(Me.Items.Count, item)
            Next
        End Sub

#End Region

    End Class

    'A collection containing the selected items
    Public Class ColorListBoxSelectedItemCollection
        Inherits System.Collections.ObjectModel.Collection(Of ColorListBoxItem)
    End Class

#End Region

End Class

'An item that is added to the ColorListBox
Public Class ColorListBoxItem

#Region " Constructors "

    Public Sub New()
        Me.New("New item", Color.Black, Nothing)
    End Sub

    Public Sub New(ByVal text As String)
        Me.New(text, Color.Black, Nothing)
    End Sub

    Public Sub New(ByVal text As String, ByVal color As Color)
        Me.New(text, color, Nothing)
    End Sub

    Public Sub New(ByVal text As String, ByVal color As Color, ByVal img As Image)
        Me.Text = text
        Me.Color = color
        Me.Image = img
    End Sub

#End Region

#Region " Properties "

    Private _Text As String
    Public Property Text() As String
        Get
            Return _Text
        End Get
        Set(ByVal value As String)
            _Text = value
        End Set
    End Property

    Private _Color As Color
    Public Property Color() As Color
        Get
            Return _Color
        End Get
        Set(ByVal value As Color)
            _Color = value
        End Set
    End Property

    Private _Image As Image
    Public Property Image() As Image
        Get
            Return _Image
        End Get
        Set(ByVal value As Image)
            _Image = value
        End Set
    End Property

#End Region

End Class
