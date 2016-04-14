Imports DotNetNuke.ComponentModel.DataAnnotations
Imports Kb.Dnn.Angular_Gem_Store

'<Cacheable("Angular_Gem_Store_Inventory_", CacheItemPriority.Default, 20)>
<TableName("Angular_Gem_Store_Inventory")>
<PrimaryKey("RecordId", AutoIncrement:=True)>
Public Class Item
    Implements IItemModel
    Public Property RecordId As Integer Implements IItemModel.RecordId
    Public Property Name As String Implements IItemModel.Name
    Public Property Description As String Implements IItemModel.Description
    Public Property Shine As Short Implements IItemModel.Shine
    Public Property Price As Decimal Implements IItemModel.Price
    Public Property Rarity As Short Implements IItemModel.Rarity
    Public Property Color As String Implements IItemModel.Color
    Public Property Faces As Short Implements IItemModel.Faces

    <IgnoreColumn>
    Public Property Images As IEnumerable(Of IImagePathModel) Implements IItemModel.Images
    <IgnoreColumn>
    Public Property Reviews As IEnumerable(Of IItemReviewModel) Implements IItemModel.Reviews

End Class
