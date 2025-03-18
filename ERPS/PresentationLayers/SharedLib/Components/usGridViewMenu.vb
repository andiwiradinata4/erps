Imports DevExpress.XtraGrid.Views.Grid
Public Class usGridViewMenu : Inherits DevExpress.XtraGrid.Menu.GridViewMenu
    Private _toolbar As ToolBar
    Private _toolbarEvent As ToolBarButtonClickEventHandler

    Public Sub New(view As GridView, ByRef toolbar As ToolBar, toolbarEvent As ToolBarButtonClickEventHandler)
        MyBase.New(view)
        Dim il As ImageList = toolbar.ImageList
        _toolbar = toolbar
        _toolbarEvent = toolbarEvent
        For Each tb As ToolBarButton In toolbar.Buttons
            If tb.Text = "Refresh" Or tb.Text = "Exit" Or tb.Tag = Nothing Or tb.Visible = False Or tb.Style = ToolBarButtonStyle.Separator Then Continue For
            Dim dxMenuItem As New DevExpress.Utils.Menu.DXMenuItem(tb.Text) With
                {
                    .Image = il.Images.Item(tb.ImageIndex),
                    .Tag = tb
                }
            AddHandler dxMenuItem.Click, AddressOf GridViewMenu_Handler
            Me.Items.Add(dxMenuItem)
        Next

        AddHandler view.PopupMenuShowing, AddressOf grdView_PopupMenuShowing
    End Sub

    Private Sub GridViewMenu_Handler(sender As Object, e As EventArgs)
        _toolbarEvent(_toolbar, New ToolBarButtonClickEventArgs(sender.Tag))
    End Sub

    Private Sub grdView_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
        For Each dxMenu As DevExpress.Utils.Menu.DXMenuItem In Me.Items
            dxMenu.Visible = _toolbar.Buttons.Item(dxMenu.Tag.name).Visible
            dxMenu.Enabled = View.RowCount > 0
        Next

        If e.HitInfo.InRow Then
            e.Menu = Me
            e.Allow = True
        End If
    End Sub

End Class
