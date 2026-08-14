Imports FoundationLibrary.Interfaces.Keys
Imports FoundationLibrary.Interfaces.Service
Imports FoundationLibrary.Interfaces.Repository
Imports FoundationLibrary.Interfaces.ValMsg
Imports FoundationLibrary.ValMsg
Namespace Services

    ''' <summary>
    '''<Title>O Services Επιστρέφει ενα αντιγραφο του Entity</Title>
    '''
    '''<para><em>
    ''' Για να λειτουργείσει ο Service και να επικοινωνισει με το Αποθετήριο θα πρέπει στην βάση Δεδομένων να υπαρχει στο <typeparamref name="TEntity"/> το αντιστοιχο κλειδι <see cref="Interfaces.Keys.IHasPrimaryKey(Of T)"/>
    ''' </em></para>
    ''' 
    ''' <important>
    ''' <b>* Θα χρειαστεί να υλοποιησεις Την <see cref="MemberizeClone">MemberizeClone()</see></b> 
    ''' </important>
    ''' 
    ''' </summary>
    ''' <typeparam name="Tkey"></typeparam>
    ''' <typeparam name="TEntity"></typeparam>
    ''' <typeparam name="TRepository"></typeparam>
    Public MustInherit Class ServiceCloneEntity(Of Tkey, TEntity As IHasPrimaryKey(Of Tkey), TRepository As IRepository(Of Tkey, TEntity))
        Implements IService(Of TEntity)

        Public Property Repository As TRepository

        Sub New(ReposirotyLink As TRepository)
            Repository = ReposirotyLink
        End Sub
        ''' <summary>
        ''' Δημιουργει ενα αντιγραφό του Entity
        ''' </summary>
        ''' <param name="Enity"></param>
        ''' <returns></returns>
        MustOverride Function MemberizeClone(Enity As TEntity) As TEntity
        MustOverride Function ToEntity(Of TDTO)(DTO As TDTO) As TEntity
        MustOverride Function ToEntity(Of TDTO)(DTO As TDTO, Entity As TEntity) As TEntity
        Public Overridable Function Exist(Ref As TEntity) As IValMsg(Of TEntity) Implements IService(Of TEntity).Exist
            Dim Result As New ValMsg(Of TEntity)
            Dim Entity As TEntity = Repository.Read_Item(Ref.PrimaryKey)

            If Entity Is Nothing Then
                Result.Success = False
                Result.Msg = "Δεν βρέθηκε η Εγραφή!"
                Return Result
            End If

            Result.Model = MemberizeClone(Entity)
            Result.Success = True
            Result.Msg = "Βρέθηκε η Εγραφη!"
            Return Result
        End Function

        Public Overridable Function Register(Of DTO)(RegisterDTO As DTO) As IValMsg(Of TEntity) Implements IService(Of TEntity).Register
            Dim Val As New ValMsg(Of TEntity)

            Dim Entity As TEntity = ToEntity(RegisterDTO)
            If Repository.Create(Entity) Then
                Val.Success = True
                Val.Msg = "Επιτυχης Εγραφή !"
                Val.Model = MemberizeClone(Entity)
                Return Val
            Else
                Val.Success = False
                Val.Msg = "αποτυχία Εγραφής !"
                Return Val
            End If
        End Function

        Public Overridable Function Change(Of DTO)(Ref As TEntity, ChangeDTO As DTO) As IValMsg Implements IService(Of TEntity).Change
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

        Public Overridable Function Remove(Ref As TEntity) As IValMsg Implements IService(Of TEntity).Remove
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

        Public Overridable Function Get_All() As IValMsg(Of List(Of TEntity)) Implements IService(Of TEntity).Get_All
            Dim Val As New ValMsg(Of List(Of TEntity))
            Val.Model = New List(Of TEntity)
            For Each Entity In Repository.Read_All
                Val.Model.Add(MemberizeClone(Entity))
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
Public Class ServiceCE

End Class
