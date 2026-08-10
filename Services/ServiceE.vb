Imports FoundationLibrary.Interfaces.Keys
Imports FoundationLibrary.Interfaces.Repository
Imports FoundationLibrary.Interfaces.Service
Imports FoundationLibrary.Interfaces.ValMsg
Imports FoundationLibrary.ValMsg

Namespace Services
    ''' <summary>
    ''' O Service Επιστρέφει το γνησιο αντικειμενο του ENTITY.
    ''' Δεν ειναι και τοσο ασφαλες γιατι η κάθε αλλαγη δεν περναει απο τον Service.
    ''' οι αλλαγες μπορουν να γινουν και χωρις καποιο ελενχο απο το χρηστη εκτως αμα περασεις μεσο αντιγραφει στο service.
    ''' </summary>
    ''' <typeparam name="TKey"></typeparam>
    ''' <typeparam name="TEntity"></typeparam>
    ''' <typeparam name="TRepository"></typeparam>
    Public MustInherit Class ServiceE(Of TKey, TEntity As IHasPrimaryKey(Of TKey), TRepository As IRepository(Of TKey, TEntity))
        Implements IService(Of TKey, TEntity)

        Public Property Repository As TRepository

        Sub New(RepositoryLink As IRepository(Of TKey, TEntity))
            Repository = RepositoryLink
        End Sub

        MustOverride Function ToEntity(Of DTO)(DTOLink As DTO) As TEntity
        MustOverride Function ToEntity(Of DTO)(DTOLink As DTO, Entity As TEntity) As TEntity

        Overridable Function Exist(Ref As TEntity) As IValMsg(Of TEntity) Implements IService(Of TKey, TEntity).Exist
            Dim Result As New ValMsg.ValMsg(Of TEntity)
            Dim Entity As TEntity = Repository.Read_Item(Ref.PrimaryKey)

            If Entity Is Nothing Then
                Result.Success = False
                Result.Msg = "Δεν βρέθηκε η Εγραφή!"
                Return Result
            End If

            Result.Model = Entity
            Result.Success = True
            Result.Msg = "Βρέθηκε η Εγραφη!"
            Return Result
        End Function
        Overridable Function Register(Of DTO)(RegisterDTO As DTO) As IValMsg(Of TEntity) Implements IService(Of TKey, TEntity).Register
            Dim Val As New ValMsg(Of TEntity)

            Dim Entity As TEntity = ToEntity(RegisterDTO)
            If Repository.Create(Entity) Then
                Val.Success = True
                Val.Msg = "Επιτυχης Εγραφή !"
                Val.Model = Entity
                Return Val
            Else
                Val.Success = False
                Val.Msg = "αποτυχία Εγραφής !"
                Return Val
            End If
        End Function
        Overridable Function Change(Of DTO)(Ref As TEntity, ChangeDTO As DTO) As IValMsg Implements IService(Of TKey, TEntity).Change
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
        Overridable Function Remove(Ref As TEntity) As IValMsg Implements IService(Of TKey, TEntity).Remove
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
        Overridable Function Get_All() As IValMsg(Of List(Of TEntity)) Implements IService(Of TKey, TEntity).Get_All
            Dim Val As New ValMsg(Of List(Of TEntity))
            Val.Model = New List(Of TEntity)
            For Each Entity In Repository.Read_All
                Val.Model.Add(Entity)
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

