Imports FoundationLibrary.Interfaces.Service
Imports FoundationLibrary.Repositories
Imports FoundationLibrary.Interfaces.Keys
Imports FoundationLibrary.Interfaces.Repository
Imports FoundationLibrary.Interfaces.ValMsg
Imports FoundationLibrary.ValMsg
Imports FoundationLibrary
Namespace Services
    ''' <summary>
    ''' Ο Service επιστρέφει το Model που ειναι ενα αντιγραφο του Entity΄,
    ''' Είναι ποιο ασφάλες και δεν μπορει να αλλαξει το αρχικο entity χώρις να περασει καποια εντολη απο τον Service!
    ''' </summary>
    ''' <typeparam name="TKey">Τον Τύπο του PK</typeparam>
    ''' <typeparam name="TModel">Το Model που κανει αντιγραφη απο το Entity</typeparam>
    ''' <typeparam name="TEntity">Το Αρχικο entity</typeparam>
    ''' <typeparam name="TRepository">To Αποθετήριο</typeparam>
    Public MustInherit Class Service(Of TKey, TModel As IHasPrimaryKey(Of TKey), TEntity As IHasPrimaryKey(Of TKey), TRepository As IRepository(Of TKey, TEntity))
        Implements IService(Of TKey, TModel)

        Public Property Repository As TRepository

        Sub New(RepositoryLink As IRepository(Of TKey, TEntity))
            Repository = RepositoryLink
        End Sub

        MustOverride Function ToModel(Entity As TEntity) As TModel
        MustOverride Function ToEntity(Of DTO)(DTOLink As DTO) As TEntity
        MustOverride Function ToEntity(Of DTO)(DTOLink As DTO, Entity As TEntity) As TEntity

        Overridable Function Exist(Ref As TModel) As IValMsg(Of TModel) Implements IService(Of TKey, TModel).Exist
            Dim Result As New ValMsg(Of TModel)
            Dim Entity As TEntity = Repository.Read_Item(Ref.PrimaryKey)

            If Entity Is Nothing Then
                Result.Success = False
                Result.Msg = "Δεν βρέθηκε η Εγραφή!"
                Return Result
            End If

            Result.Model = ToModel(Entity)
            Result.Success = True
            Result.Msg = "Βρέθηκε η Εγραφη!"
            Return Result
        End Function
        Overridable Function Register(Of DTO)(RegisterDTO As DTO) As IValMsg(Of TModel) Implements IService(Of TKey, TModel).Register
            Dim Val As New ValMsg(Of TModel)

            Dim Entity As TEntity = ToEntity(RegisterDTO)
            If Repository.Create(Entity) Then
                Val.Success = True
                Val.Msg = "Επιτυχης Εγραφή !"
                Val.Model = ToModel(Entity)
                Return Val
            Else
                Val.Success = False
                Val.Msg = "αποτυχία Εγραφής !"
                Return Val
            End If
        End Function
        Overridable Function Change(Of DTO)(Ref As TModel, ChangeDTO As DTO) As IValMsg Implements IService(Of TKey, TModel).Change
            Dim Val As New ValMsg.ValMsg

            Dim Entity As TEntity = Repository.Read_Item(Ref.PrimaryKey)
            Entity = ToEntity(ChangeDTO, Entity)
            If Repository.Update(Ref.PrimaryKey, Entity) Then
                Val.Success = True
                Val.Msg = "Επιτυχής Αλλαγή!"
            Else
                Val.Success = False
                Val.Msg = "Αποτηχία Αλλαγής!"
            End If
            Return Val
        End Function
        Overridable Function Remove(Ref As TModel) As IValMsg Implements IService(Of TKey, TModel).Remove
            Dim Val As New ValMsg.ValMsg
            If Repository.Delete(Ref.PrimaryKey) Then
                Val.Success = True
                Val.Msg = "Επιτυχής Διαγραφής!"
            Else
                Val.Success = False
                Val.Msg = "Αποτυχία Διαγραφής!"
            End If
            Return Val
        End Function
        Overridable Function Get_All() As IValMsg(Of List(Of TModel)) Implements IService(Of TKey, TModel).Get_All
            Dim Val As New ValMsg(Of List(Of TModel))
            Val.Model = New List(Of TModel)
            For Each Entity In Repository.Read_All
                Val.Model.Add(ToModel(Entity))
            Next
            If Val.Model.Count > 0 Then
                Val.Success = True
                Val.Msg = "Βρέθηκε Εγραφή!"
            Else
                Val.Success = False
                Val.Msg = "Δεν Βρέθηκε Εγραφή!"
            End If
            Return Val
        End Function

    End Class
End Namespace