Imports FoundationLibrary.Interfaces.Keys
Imports FoundationLibrary.Interfaces.Repository

Namespace Repositories
    ''' <summary>
    ''' <inheritdoc cref=" IRepository(Of Tkey, TEntity)"/><br/><br/>
    ''' Το Repository εκχωρίτε μεσα στην μνημη,
    ''' χρησημοποιειτε κυριος για testing.  <br/>
    ''' θα Πρέπει να περαστει απο μεσο inherits στην class που θέλεις να κανεις αποθητεριο.
    ''' </summary>
    ''' <typeparam name="Tkey">Τύπος κλίδιου</typeparam>
    ''' <typeparam name="TEntity">Βάση δεδομένων</typeparam>
    Public MustInherit Class Repository(Of Tkey, TEntity As IHasPrimaryKey(Of Tkey))
        Implements IRepository(Of Tkey, TEntity)


        Protected Friend Property Rep As New List(Of TEntity)

        Public Overridable Sub RemoveAll() Implements IRepository(Of Tkey, TEntity).RemoveAll
            Rep.Clear()
        End Sub


        Public Overridable Function Create(Entity As TEntity) As Interfaces.Results.IRepResult(Of TEntity) Implements IRepository(Of Tkey, TEntity).Create
            Dim rnd As New Random
            Dim ValResult As New Result.Result(Of TEntity)

Again:
            Randomize()
            Entity.PrimaryKey = CType(rnd.Next, Object)
            For i = 0 To Rep.Count - 1
                If Equals(Rep(i).PrimaryKey, Entity.PrimaryKey) Then
                    GoTo Again
                    ValResult.Success = False
                    ValResult.Msg = "Δεν μπόρεσε να διμιουργηθει η Data"
                    Return ValResult
                End If
            Next
            Rep.Add(Entity)
            ValResult.Success = True
            ValResult.Msg = "Διμιουργήθηκε με επιτυχεία"
            ValResult.Entity = Entity
            Return ValResult
        End Function

        Public Overridable Function Update(PK As Tkey, Entity As TEntity) As Interfaces.Results.IRepResult(Of TEntity) Implements IRepository(Of Tkey, TEntity).Update
            Dim Result As New Repositories.Result.Result(Of TEntity)
            For i = 0 To Rep.Count - 1
                If Equals(Rep(i).PrimaryKey, PK) Then
                    Rep(i) = Entity
                    Result.Success = True
                    Result.Msg = "Η αλλαγή ήταν επιτυχής!"
                    Result.Entity = Rep(i)
                    Return Result
                End If
            Next
            Result.Success = False
            Result.Msg = "Δεν ήταν επιτυχής η αλλαγή!"
            Return Result
        End Function

        Public Overridable Function Delete(Entity As TEntity) As Interfaces.Results.IRepResult(Of TEntity) Implements IRepository(Of Tkey, TEntity).Delete
            Dim Result As New Repositories.Result.Result(Of TEntity)
            For i = 0 To Rep.Count - 1
                If Rep(i).Equals(Entity) Then
                    Rep.RemoveAt(i)
                    Result.Success = True
                    Result.Msg = "Διαγράφηκε με επιτηχία!"
                    Return Result
                End If
            Next
            Result.Success = False
            Result.Msg = "Δεν μπόρεσε να διαγραφή!"
            Return Result
        End Function

        Public Overridable Function Read_All() As Interfaces.Results.IRepResult(Of List(Of TEntity)) Implements IRepository(Of Tkey, TEntity).Read_All
            Dim Result As New Repositories.Result.Result(Of List(Of TEntity))
            Result.Success = False
            Result.Msg = "Δεν υπάρχει εγραφή!"
            For i = 0 To Rep.Count - 1
                Result.Success = True
                Result.Msg = "Βρέθηκαν εγραφές!"
                Result.Entity.Add(Rep(i))
            Next

            Return Result
        End Function

        Public Overridable Function ReadKey(PK As Tkey) As Interfaces.Results.IRepResult(Of TEntity) Implements IRepository(Of Tkey, TEntity).ReadKey
            Dim Result As New Repositories.Result.Result(Of TEntity)
            Result.Success = False
            Result.Msg = "Δεν Βρέθηκε εγραφή!"
            For i = 0 To Rep.Count - 1
                If Equals(Rep(i).PrimaryKey, PK) Then
                    Result.Success = True
                    Result.Msg = "Βρέθηκε εγραφή!"
                    Result.Entity = Rep(i)
                End If
            Next
            Return Result
        End Function

        Public Overridable Function ReadAT(Index As Integer) As Interfaces.Results.IRepResult(Of TEntity) Implements IRepository(Of Tkey, TEntity).ReadAt
            Dim Result As New Repositories.Result.Result(Of TEntity)
            Result.Success = False
            Result.Msg = "Δεν βρέθηκε η εγραφή!"
            If Rep(Index) IsNot Nothing Then
                Result.Success = True
                Result.Msg = "Βρέθηκε η εγραφή!"
                Result.Entity = Rep(Index)
            End If
            Return Result
        End Function

        Public Function Read(Of TCreteria)(Creteria As TCreteria) As Interfaces.Results.IRepResult(Of TEntity) Implements IRepository(Of Tkey, TEntity).Read
            Dim Result As New Repositories.Result.Result(Of TEntity)
            Result.Success = False
            Result.Msg = "Δεν βρέθηκε η εγραφή!"
            For i = 0 To Rep.Count - 1
                If Match(Rep(i), Creteria) Then
                    Result.Success = True
                    Result.Msg = "Βρέθηκε η εγραφή!"
                    Result.Entity = Rep(i)
                    Return Result
                End If
            Next
            Return Result
        End Function

        Public Function Read(Match As Predicate(Of TEntity)) As Interfaces.Results.IRepResult(Of TEntity) Implements IRepository(Of Tkey, TEntity).Read
            Dim Result As New Repositories.Result.Result(Of TEntity)
            Result.Success = False
            Result.Msg = "Δεν βρέθηκε η εγραφή!"
            For i = 0 To Rep.Count - 1
                If Match(Rep(i)) Then
                    Result.Success = True
                    Result.Msg = "Βρέθηκε η εγραφή!"
                    Result.Entity = Rep(i)
                    Return Result
                End If
            Next
            Return Result
        End Function

        Public Overridable Function UpdateAT(index As Integer, Entity As TEntity) As Interfaces.Results.IRepResult(Of TEntity) Implements IRepository(Of Tkey, TEntity).UpdateAt
            Dim Result As New Repositories.Result.Result(Of TEntity)
            If Rep(index) IsNot Nothing Then
                Rep(index) = Entity
                Result.Entity = Entity
                Result.Success = True
                Result.Msg = "Επιτυχής εγραφή!"
                Return Result
            Else
                Result.Success = False
                Result.Msg = "Δεν ήταν επιτυχης ή εγραφή !"
                Return Result
            End If
        End Function




        Public Overridable Function Delete(PK As Tkey) As Interfaces.Results.IRepResult(Of TEntity) Implements IRepository(Of Tkey, TEntity).Delete
            Dim Result As New Repositories.Result.Result(Of TEntity)
            Result.Success = False
            Result.Msg = "Δεν μπόρεσε να βρεθεί η εγραφή!"
            For i = 0 To Rep.Count - 1
                If Equals(Rep(i).PrimaryKey, PK) Then
                    Rep.RemoveAt(i)
                    Result.Success = True
                    Result.Msg = "Επιτηχής εγραφή!"
                    Return Result
                End If
            Next
            Return Result
        End Function

        Public Overridable Function DeleteAt(Index As Integer) As Interfaces.Results.IRepResult(Of TEntity) Implements IRepository(Of Tkey, TEntity).DeleteAt
            Dim Result As New Repositories.Result.Result(Of TEntity)
            Result.Success = False
            Result.Msg = "Δε μπόρεσε να βραθεί η εγραφή!"
            If Rep(Index) IsNot Nothing Then
                Rep.RemoveAt(Index)
                Result.Success = True
                Result.Msg = "Η διαγραφή ηταν επιτυχής!"
                Return Result
            End If
            Return Result
        End Function

        Public Function GeneredID() As Tkey Implements IRepository(Of Tkey, TEntity).GeneredID
            Dim rnd As New Random
            Dim PK As Tkey = CType(0, Object)
Again:
            Randomize()
            PK = CType(rnd.Next, Object)

            For i = 0 To Rep.Count - 1
                If Equals(Rep(i).PrimaryKey, PK) Then
                    GoTo Again
                End If
            Next

            Return PK
        End Function

        Public Function TryCreate(Entity As TEntity, PK As Tkey) As Interfaces.Results.IRepResult(Of TEntity) Implements IRepository(Of Tkey, TEntity).TryCreate
            Dim Result As New Repositories.Result.Result(Of TEntity)
            For i = 0 To Rep.Count - 1
                If Equals(Rep(i).PrimaryKey, PK) Then
                    Result.Success = False
                    Result.Msg = "Δεν μπόρει να διμιουργηθει με το ιδιο κλειδί"
                    Return Result
                End If
            Next
            Entity.PrimaryKey = PK
            Rep.Add(Entity)
            Result.Success = True
            Result.Msg = "Διμιουργήθηκε με επιτυχία!"
            Result.Entity = Entity

            Return Result
        End Function

        Public Function UpdateWhere(Match As Predicate(Of TEntity), Update As Func(Of TEntity, TEntity)) As Interfaces.Results.IRepResult(Of TEntity) Implements IRepository(Of Tkey, TEntity).UpdateWhere
            Dim Result As New Repositories.Result.Result(Of TEntity)
            Result.Success = False
            Result.Msg = "Δεν μπόρεσε να γίνει η αλλαγή!"
            For i = 0 To Rep.Count - 1
                If Match(Rep(i)) Then
                    Rep(i) = Update(Rep(i))
                    Result.Success = True
                    Result.Msg = "Επιτυχής αλλαγή!"
                End If
            Next
            Return Result
        End Function

        Public Function Search(Of TCreteria)(Creteria As TCreteria) As Interfaces.Results.IRepResult(Of List(Of TEntity)) Implements IRepository(Of Tkey, TEntity).Search
            Dim Result As New List(Of TEntity)
            For i = 0 To Rep.Count - 1
                If Match(Rep(i), Creteria) Then Result.Add(Rep(i))
            Next
            Return Result
        End Function

        Public Function Search(Match As Predicate(Of TEntity)) As Interfaces.Results.IRepResult(Of List(Of TEntity)) Implements IRepository(Of Tkey, TEntity).Search
            Dim Result As New List(Of TEntity)
            For i = 0 To Rep.Count - 1
                If Match(Rep(i)) Then
                    Result.Add(Rep(i))
                End If
            Next
            Return Result
        End Function

        MustOverride Function Match(Of TCreteria)(Entity As TEntity, Creteria As TCreteria) As Boolean



        Public Function DeleteWhere(Match As Predicate(Of TEntity)) As Interfaces.Results.IRepResult(Of TEntity) Implements IRepository(Of Tkey, TEntity).DeleteWhere
            Dim Result As New Repositories.Result.Result(Of TEntity)
            Result.Success = False
            Result.Msg = "Δεν μπόρεσε να γίνει διαγραφή!"

            For i = 0 To Rep.Count - 1
                If Match(Rep(i)) Then
                    Rep.RemoveAt(i)
                    Result.Success = True
                    Result.Msg = "Επιτυχής Διαγραφή!"
                End If
            Next
            Return Result
        End Function

        Public Function Add(Entity As TEntity) As Interfaces.Results.IRepResult(Of TEntity) Implements IRepository(Of Tkey, TEntity).Add
            Dim Result As New Repositories.Result.Result(Of TEntity) With {.Success = True, .Msg = "Προσθέθηκε με επιτυχία.", .Entity = Entity}
            Rep.Add(Entity)
            Return Result
        End Function
    End Class

End Namespace

