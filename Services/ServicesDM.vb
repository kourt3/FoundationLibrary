Imports FoundationLibrary.Interfaces.Repository
Imports FoundationLibrary.Interfaces.Service
Imports FoundationLibrary.Interfaces.ValMsg
Imports FoundationLibrary.ValMsg

Namespace Services

    ''' <summary>
    ''' <Title>Service που να μπορεί να παραγει μεσο Mapper Διαφορα Models</Title>
    ''' <Description><para>
    ''' οταν εχεις φτιάξει Ενα Model που δεν περιεχει τα κλειδια απο το Project<br/>
    ''' Και εχεις βάλει εναν εξωτερικο Mapper για να κανει την αντικατασταση Entity Στο δικο σου Model.
    ''' </para></Description>
    ''' <para>
    ''' <em>Για να λειτουργείσει ο Service και να επικοινωνισει με το Αποθετήριο θα πρέπει στην βάση Δεδομένων να υπαρχει στο <typeparamref name="TEntity"/> το αντιστοιχο κλειδι <see cref="Interfaces.Keys.IHasPrimaryKey(Of T)"/></em>
    ''' </para>
    ''' </summary>
    ''' <typeparam name="TKey">Τον Τύπο του PK</typeparam>
    ''' <typeparam name="TModel">Το Model που κανει αντιγραφη απο το Entity</typeparam>
    ''' <typeparam name="TEntity">Το Αρχικο entity</typeparam>
    ''' <typeparam name="TRepository">To Αποθετήριο</typeparam>
    Public MustInherit Class ServicesDiffModels(Of Tkey, TModel, TEntity As Interfaces.Keys.IHasPrimaryKey(Of Tkey), TRepository As Interfaces.Repository.IRepository(Of Tkey, TEntity))
        Implements Interfaces.Service.IService(Of TEntity, TModel)

        Public Delegate Function DelMemberizeClone(Entity As TEntity) As TModel
        Public ReadOnly Property MemberizeClone As DelMemberizeClone

        MustOverride Function ToEntity(Of TDTO)(DTO As TDTO) As TEntity
        MustOverride Function ToEntity(Of TDTO)(DTO As TDTO, Entity As TEntity) As TEntity
        Public Repository As TRepository

        Sub New(LinkRepository As IRepository(Of Tkey, TEntity), AddressOfMemberizeClone As DelMemberizeClone)
            Repository = LinkRepository
            MemberizeClone = AddressOfMemberizeClone
        End Sub

        Public Overridable Function Exist(Ref As TEntity) As IValMsg(Of TModel) Implements IKeysServices(Of TEntity, TModel).Exist
            Dim Result As New ValMsg(Of TModel)
            Dim Entity As TEntity = Repository.Read_Item(Ref.PrimaryKey)

            If Entity Is Nothing Then
                Result.Success = False
                Result.Msg = "Δεν βρέθηκε η Εγραφή!"
                Return Result
            End If

            Result.Model = MemberizeClone.Invoke(Entity)
            Result.Success = True
            Result.Msg = "Βρέθηκε η Εγραφη!"
            Return Result
        End Function

        Public Overridable Function Register(Of DTO)(RegisterDTO As DTO) As IValMsg(Of TModel) Implements IKeysServices(Of TEntity, TModel).Register
            Dim Val As New ValMsg(Of TModel)

            Dim Entity As TEntity = ToEntity(RegisterDTO)
            If Repository.Create(Entity) Then
                Val.Success = True
                Val.Msg = "Επιτυχης Εγραφή !"
                Val.Model = MemberizeClone.Invoke(Entity)
                Return Val
            Else
                Val.Success = False
                Val.Msg = "αποτυχία Εγραφής !"
                Return Val
            End If
        End Function

        Public Overridable Function Change(Of DTO)(Ref As TEntity, ChangeDTO As DTO) As IValMsg Implements IKeysServices(Of TEntity, TModel).Change
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

        Public Overridable Function Remove(Ref As TEntity) As IValMsg Implements IKeysServices(Of TEntity, TModel).Remove
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

        Public Overridable Function Get_All() As IValMsg(Of List(Of TModel)) Implements IKeysServices(Of TEntity, TModel).Get_All
            Dim Val As New ValMsg(Of List(Of TModel))
            Val.Model = New List(Of TModel)
            For Each Entity In Repository.Read_All
                Val.Model.Add(MemberizeClone.Invoke(Entity))
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

