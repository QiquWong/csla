<Serializable()> _
Public Class Child
  Inherits BusinessBase

  Private mData As String = ""
  Private mGuid As Guid = Guid.NewGuid

  Private mChildren As GrandChildren = GrandChildren.NewGrandChildren

  Public Property Data() As String
    Get
      Return mData
    End Get
    Set(ByVal Value As String)
      If mData <> Value Then
        mData = Value
        MarkDirty()
      End If
    End Set
  End Property

  Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean

    If obj Is Nothing OrElse Not TypeOf obj Is Child Then
      Return False
    End If

    Return mData = CType(obj, Child).Data

  End Function

  Public ReadOnly Property Guid() As Guid
    Get
      Return mGuid
    End Get
  End Property

  Public ReadOnly Property GrandChildren() As GrandChildren
    Get
      Return mChildren
    End Get
  End Property

  Friend Shared Function NewChild(ByVal Data As String) As Child
    Dim obj As New Child
    obj.mData = Data
    Return obj
  End Function

  Friend Shared Function GetChild(ByVal dr As IDataReader) As Child
    Dim obj As New Child
    obj.Fetch(dr)
    Return obj
  End Function

  Private Sub New()
    ' prevent direct creation
    MarkAsChild()
  End Sub

  Private Sub Fetch(ByVal dr As IDataReader)
    MarkOld()
  End Sub

  Friend Sub Update(ByVal tr As IDbTransaction)
    If IsDeleted Then
      ' we would delete here
      MarkNew()
    Else
      If IsNew Then
        ' we would insert here

      Else
        ' we would update here
      End If
      MarkOld()
    End If
  End Sub

End Class
