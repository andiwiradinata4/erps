Namespace VO
    Public Class BusinessPartner
        Inherits Common
        Property ID As Integer
        Property Code As String
        Property Name As String
        Property Address As String
        Property PICName As String
        Property PICPhoneNumber As String
        Property APBalance As Decimal
        Property ARBalance As Decimal
        Property StatusID As Integer
        Property Remarks As String
        Property JournalIDForAPBalance As String
        Property JournalIDForARBalance As String
        Property Initial As String
        Property CoAIDofStock As Integer
        Property CoACodeofStock As String
        Property CoANameofStock As String
        Property NPWP As String
        Property PPN As Decimal
        Property PPH As Decimal
        Property IsFreePPN As Decimal
        Property IsFreePPH As Decimal
    End Class
End Namespace