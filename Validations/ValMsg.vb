Imports FoundationLibrary.Interfaces.Results
Imports FoundationLibrary.Validation.Exceptions

Namespace Validation.ValMsg
    Public Class ValMsg
        Implements IValidExcept

        Public Property Success As Boolean Implements IValidExcept.Success
        Public Property Exception As List(Of ValidException) Implements IValidExcept.Exception
        Sub New()
            Exception = New List(Of ValidException)
        End Sub
    End Class

End Namespace
