Imports DotNetNuke.ComponentModel.DataAnnotations
Imports Kb.Dnn.Angular_Gem_Store

<TableName("Angular_Gem_Store_Inventory_Reviews")>
<PrimaryKey("RecordId", AutoIncrement:=True)>
<Cacheable("Angular_Gem_Store_Inventory_Reviews_", CacheItemPriority.Default, 20)>
Public Class ItemReview
    Implements IItemReviewModel

    Public Property Author As String Implements IItemReviewModel.Author

    Public Property Body As String Implements IItemReviewModel.Body

    Public Property CreatedOn As Date Implements IItemReviewModel.CreatedOn

    Public Property ItemId As Integer Implements IItemReviewModel.ItemId

    Public Property RecordId As Integer Implements IItemReviewModel.RecordId

    Public Property Stars As Byte Implements IItemReviewModel.Stars

End Class
