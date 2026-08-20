Imports FoundationLibrary.Interfaces.Service
Imports FoundationLibrary.Repositories
Imports FoundationLibrary.Interfaces.Keys
Imports FoundationLibrary.Interfaces.Repository
Imports FoundationLibrary.Interfaces.Results
Imports FoundationLibrary
Imports FoundationLibrary.Validation.Exceptions
Namespace Services
    ''' <summary>
    ''' <Title>
    ''' Ο Service επιστρέφει το Model που ειναι ενα αντιγραφο του Entity
    ''' </Title>
    ''' <para>Είναι ποιο ασφάλες και δεν μπορει να αλλαξει το αρχικο entity χώρις να περασει καποια εντολη απο τον Service! </para> 
    '''<para><em>
    ''' Για να λειτουργείσει ο Service και να επικοινωνηση με το Αποθετήριο θα πρέπει στην βάση Δεδομένων να υπαρχει στο <typeparamref name="TEntity"/> το αντιστοιχο κλειδι <see cref="Interfaces.Keys.IHasPrimaryKey(Of T)"/>
    ''' </em></para>
    ''' 
    ''' <important>
    ''' <b>* Θα χρειαστεί να υλοποιησεις Την <see cref="MemberizeClone">MemberizeClone()</see></b> 
    ''' </important>
    ''' 
    ''' </summary>
    ''' <typeparam name="TKey">Τον Τύπο του PK</typeparam>
    ''' <typeparam name="TModel">Το Model που κανει αντιγραφη απο το Entity</typeparam>
    ''' <typeparam name="TEntity">Το Αρχικο entity</typeparam>
    ''' <typeparam name="TRepository">To Αποθετήριο</typeparam>
    Public MustInherit Class Service(Of TKey, TModel, TEntity As IHasPrimaryKey(Of TKey), TRepository As IRepository(Of TKey, TEntity))
        Implements IService(Of TEntity, TModel)

        Public Property Repository As TRepository

        Sub New(RepositoryLink As IRepository(Of TKey, TEntity))
            Repository = RepositoryLink
            AvailableExternalModel = False
        End Sub


        ' ================ Types For external models ================== 
        Public ReadOnly AvailableExternalModel As Boolean = False
        Public Delegate Function DelMemberizeClone(Entity As TEntity) As TModel
        Public ReadOnly Property ExternalModelMemberizeClone As DelMemberizeClone
        Sub New(LinkRepository As IRepository(Of TKey, TEntity), ExternalModelofMemeberizeCloneLink As DelMemberizeClone)
            Repository = LinkRepository
            ExternalModelMemberizeClone = ExternalModelofMemeberizeCloneLink
            AvailableExternalModel = True
        End Sub
        '==============================================================


        ''' <summary>
        ''' Δημιουργει ενα αντιγραφο του Entity και το περναει στο Model
        ''' </summary>
        ''' <param name="Entity">Data</param>
        ''' <returns>Model</returns>
        MustOverride Function MemberizeClone(Entity As TEntity) As TModel
        MustOverride Function ToEntity(Of DTO)(DTOLink As DTO, Optional Entity As TEntity = Nothing)
        MustOverride Function ToValidation(Of DTO)(DTOLink As DTO) As Validation.ValMsg.ValMsg

        Overridable Function Exist(Ref As TEntity) As IServiceResult(Of TModel) Implements IService(Of TEntity, TModel).Exist
            Dim Result As New ServiceResult(Of TModel)
            Dim Entity As TEntity = Repository.ReadKey(Ref.PrimaryKey)

            If Entity Is Nothing Then
                Result.Success = False
                Result.Msg = "Δεν βρέθηκε η Εγραφή!"
                Return Result
            End If
            If AvailableExternalModel = False Then
                Result.Model = MemberizeClone(Entity)
            Else
                Result.Model = ExternalModelMemberizeClone.Invoke(Entity)
            End If
            Result.Success = True
            Result.Msg = "Βρέθηκε η Εγραφη!"
            Return Result
        End Function
        Overridable Function Register(Of DTO)(RegisterDTO As DTO, Optional UseCaseLink As IKeysServices(Of TEntity, TModel).DelUseCase(Of DTO) = Nothing) As IServiceResult(Of TModel) Implements IService(Of TEntity, TModel).Register
            Dim Val As New ServiceResult(Of TModel)

            Dim ValDTO As Validation.ValMsg.ValMsg = ToValidation(Of DTO)(RegisterDTO)

            If ValDTO.Success = False Then
                Val.Success = False
                Val.Msg = "Διμιουργήθηκαν εξερέσεις στα πεδια εγραφής!"
                Val.Exceptions = ValDTO.Exception
                Return Val
            End If

            If UseCaseLink IsNot Nothing Then
                Dim ValUseCase As ICaseResult = UseCaseLink.Invoke(RegisterDTO)
                If ValUseCase.Success = False Then
                    Val.Success = False
                    Val.Msg = ValUseCase.Msg
                    Return Val
                End If
            End If

            Dim Entity As TEntity = ToEntity(RegisterDTO)
            If Repository.Create(Entity).Success Then
                Val.Success = True
                Val.Msg = "Επιτυχης Εγραφή !"

                If AvailableExternalModel = False Then
                    Val.Model = MemberizeClone(Entity)
                Else
                    Val.Model = ExternalModelMemberizeClone.Invoke(Entity)
                End If
                Return Val
            Else
                Val.Success = False
                Val.Msg = "αποτυχία Εγραφής !"
                Return Val
            End If
        End Function
        Overridable Function Change(Of DTO)(Ref As TEntity, ChangeDTO As DTO, Optional UseCaseLink As IKeysServices(Of TEntity, TModel).DelUseCase(Of DTO) = Nothing) As IServiceResult(Of TModel) Implements IService(Of TEntity, TModel).Change
            Dim Val As New Services.ServiceResult(Of TModel)

            Dim ValDTO As Interfaces.Results.IValidExcept = ToValidation(Of DTO)(ChangeDTO)
            If ValDTO.Success = False Then
                Val.Success = False
                Val.Msg = "Διμιουργήθηκαν εξερέσεις στα πεδια!"
                Val.Exceptions = ValDTO.Exception
                Return Val
            End If

            If UseCaseLink IsNot Nothing Then
                Dim ValUseCase As ICaseResult = UseCaseLink.Invoke(ChangeDTO)
                If ValUseCase.Success = False Then
                    Val.Success = False
                    Val.Msg = ValUseCase.Msg
                    Return Val
                End If
            End If



            Dim Entity As TEntity = Repository.ReadKey(Ref.PrimaryKey)
            Entity = ToEntity(ChangeDTO, Entity)
            If Repository.Update(Ref.PrimaryKey, Entity).Success Then
                Val.Success = True
                Val.Msg = "Επιτυχής Αλλαγή!"
            Else
                Val.Success = False
                Val.Msg = "Αποτηχία Αλλαγής!"
            End If
            Return Val
        End Function

        Overridable Function Remove(Ref As TEntity) As IServiceResult(Of TModel) Implements IService(Of TEntity, TModel).Remove
            Dim Val As New Services.ServiceResult(Of TModel)
            If Repository.Delete(Ref.PrimaryKey).Success Then
                Val.Success = True
                Val.Msg = "Επιτυχής Διαγραφής!"
            Else
                Val.Success = False
                Val.Msg = "Αποτυχία Διαγραφής!"
            End If
            Return Val
        End Function
        Overridable Function Get_All() As IServiceResult(Of List(Of TModel)) Implements IService(Of TEntity, TModel).Get_All
            Dim Val As New Services.ServiceResult(Of List(Of TModel))
            Val.Model = New List(Of TModel)
            For Each Entity In Repository.Read_All.Entity
                If AvailableExternalModel = False Then
                    Val.Model.Add(MemberizeClone(Entity))
                Else
                    Val.Model.Add(ExternalModelMemberizeClone.Invoke(Entity))
                End If
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


    Public Class ServiceResult(Of TModel)
        Implements Interfaces.Results.IServiceResult(Of TModel)

        Public Property Success As Boolean Implements IServiceResult(Of TModel).Success
        Public Property Model As TModel Implements IServiceResult(Of TModel).Model
        Public Property Msg As String Implements IServiceResult(Of TModel).Msg
        Public Property Exceptions As List(Of ValidException) Implements IServiceResult(Of TModel).Exceptions

    End Class
End Namespace