Namespace VO
    Public Class rptShippingInvoiceVer00
        '# Headers
        Inherits Common
        Property ID As String
        Property TransNumber As String
        Property TransDate As DateTime
        Property BPID As Integer
        Property BPCode As String
        Property BPName As String
        Property BPAddress As String
        Property SCID As String
        Property SCNumber As String
        Property PlatNumber As String
        Property Driver As String
        Property ReferencesNumber As String
        Property PPN As Decimal
        Property PPH As Decimal
        Property TotalQuantity As Decimal
        Property TotalWeight As Decimal

        '# Items
        Property ItemID As Integer
        Property ItemCode As String
        Property ItemCodeExternal As String
        Property ItemName As String
        Property ItemType As String
        Property ItemSpec As String
        Property ItemThick As Decimal
        Property ItemWidth As Decimal
        Property ItemLength As String
        Property Quantity As Decimal
        Property Weight As Decimal
        Property TotalWeightItem As Decimal
        Property UnitPrice As Decimal
        Property TotalPrice As Decimal
        Property ItemRemarks As String
    End Class
End Namespace