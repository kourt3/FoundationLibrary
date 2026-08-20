Namespace Validation.Exceptions
    Public Class ValidException
        Inherits Exception

        Property NameObj As String
        Property Value As String
        Sub New(ExceptionString As String, NameObjLink As String, ValueStr As String)
            MyBase.New(ExceptionString)
            NameObj = NameObjLink
            Value = ValueStr
        End Sub

        Public Overrides Function ToString() As String
            Return " Name Object: " & NameObj & " Message: " & MyBase.Message & " Value: " & Value
        End Function
    End Class
End Namespace
