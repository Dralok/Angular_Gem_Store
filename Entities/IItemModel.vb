Public Interface IItemModel

    Property RecordId As Integer
    Property Name As String
    Property Description As String
    Property Shine As Short
    Property Price As Decimal
    Property Rarity As Short
    Property Color As String
    Property Faces As Short

    Property Images As IEnumerable(Of IImagePathModel)
    Property Reviews As IEnumerable(Of IItemReviewModel)
End Interface
