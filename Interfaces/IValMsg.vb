Namespace Interfaces.ValMsg
    Public Interface IValMsg(Of IModel)
        Property Success As Boolean
        Property Msg As String
        Property Model As IModel
    End Interface
    Public Interface IValMsg
        Property Success As Boolean
        Property Msg As String
    End Interface
End Namespace

