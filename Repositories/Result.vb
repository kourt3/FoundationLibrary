Imports FoundationLibrary.Interfaces.Results

Namespace Repositories.Result
    Public Class Result(Of TEntity)
        Implements Interfaces.Results.IRepResult(Of TEntity)

        Public Property Success As Boolean Implements IRepResult(Of TEntity).Success
        Public Property Msg As String Implements IRepResult(Of TEntity).Msg
        Public Property Entity As TEntity Implements IRepResult(Of TEntity).Entity
    End Class
End Namespace

