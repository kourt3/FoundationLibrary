Namespace ValMsg
    Public Class ValMsg(Of IModel)
        Implements Interfaces.ValMsg.IValMsg(Of IModel)

        Public Property Success As Boolean Implements Interfaces.ValMsg.IValMsg(Of IModel).Success
        Public Property Msg As String Implements Interfaces.ValMsg.IValMsg(Of IModel).Msg
        Public Property Model As IModel Implements Interfaces.ValMsg.IValMsg(Of IModel).Model

        Public Overrides Function ToString() As String
            Return "Success :" & Success & " Msg: " & Msg
        End Function
    End Class


    Public Class ValMsg
        Implements Interfaces.ValMsg.IValMsg

        Public Property Success As Boolean Implements Interfaces.ValMsg.IValMsg.Success
        Public Property Msg As String Implements Interfaces.ValMsg.IValMsg.Msg

        Public Overrides Function ToString() As String
            Return "Success :" & Success & " Msg: " & Msg
        End Function
    End Class
End Namespace
