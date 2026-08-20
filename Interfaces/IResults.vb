Namespace Interfaces.Results
    Public Interface IValidExcept
        Property Success As Boolean
        Property Exception As List(Of FoundationLibrary.Validation.Exceptions.ValidException)
    End Interface


    Public Interface IServiceResult(Of TModel)
        Property Success As Boolean
        Property Model As TModel
        Property Msg As String
        Property Exceptions As List(Of FoundationLibrary.Validation.Exceptions.ValidException)
    End Interface

    Public Interface IRepResult(Of TEntity)
        Property Success As Boolean
        Property Msg As String
        Property Entity As TEntity
    End Interface

    Public Interface ICaseResult
        Property Success As Boolean
        Property Msg As String
    End Interface

End Namespace

