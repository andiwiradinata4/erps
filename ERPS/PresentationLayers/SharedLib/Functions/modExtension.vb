Imports System.Runtime.CompilerServices

Module modExtension

    <Extension()>
    Public Sub AddGridViewMenu(view As DevExpress.XtraGrid.Views.Grid.GridView, ByRef toolbar As ToolBar, toolbarEvent As ToolBarButtonClickEventHandler)
        Dim grdViewMenu As New usGridViewMenu(view, toolbar, toolbarEvent)
    End Sub



End Module
