Imports DotNetNuke.ComponentModel.DataAnnotations
Imports Kb.Dnn.Angular_Gem_Store

<TableName("Angular_Gem_Store_Inventory_Images")>
<PrimaryKey("RecordId", AutoIncrement:=True)>
<Cacheable("Angular_Gem_Store_Inventory_Images_", CacheItemPriority.Default, 20)>
Public Class ImagePath
    Implements IImagePathModel

    Public Property ItemId As Integer Implements IImagePathModel.ItemId

    Public Property RecordId As Integer Implements IImagePathModel.RecordId

    Public Property ImagePath As String Implements IImagePathModel.ImagePath

End Class
